// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#nullable enable

using System.Diagnostics;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace System.Text.Json
{
    public static partial class JsonSerializer
    {
        private static bool WriteCoreC<TValue>(
            JsonConverter jsonConverter,
            Utf8JsonWriter writer,
            in TValue value,
            JsonSerializerOptions options,
            ref WriteStack state) where TValue : class
        {
            Debug.Assert(writer != null);

            bool success;

            if (jsonConverter is JsonConverterC<TValue> converter)
            {
                // Call the strongly-typed WriteCore that will not box structs.
                success = converter.WriteCore(writer, value, options, ref state);
            }
            else
            {
                // The non-generic API was called or we have a polymorphic case where TValue is not equal to the T in JsonConverter<T>.
                success = jsonConverter.WriteCoreAsObject(writer, value, options, ref state);
            }

            writer.Flush();
            return success;
        }
        
        private static bool WriteCoreS<TValue>(
            JsonConverter jsonConverter,
            Utf8JsonWriter writer,
            in TValue value,
            JsonSerializerOptions options,
            ref WriteStack state) where TValue : struct
        {
            // Debug.Assert(writer != null);

            bool success;

            if (jsonConverter is JsonConverterS<TValue> converter)
            {
                // Call the strongly-typed WriteCore that will not box structs.
                success = converter.WriteCore(writer, value, options, ref state);
            }
            else
            {
                // The non-generic API was called or we have a polymorphic case where TValue is not equal to the T in JsonConverter<T>.
                success = jsonConverter.WriteCoreAsObject(writer, value, options, ref state);
            }

            writer.Flush();
            return success;
        }

        private static void WriteUsingGeneratedSerializerC<TValue>(Utf8JsonWriter writer, in TValue value, JsonTypeInfo jsonTypeInfo) where TValue : class
        {
            Debug.Assert(writer != null);

            if (jsonTypeInfo.HasSerialize &&
                jsonTypeInfo is JsonTypeInfoC<TValue> typedInfo &&
                typedInfo.Options._context?.CanUseSerializationLogic == true)
            {
                Debug.Assert(typedInfo.SerializeHandler != null);
                typedInfo.SerializeHandler(writer, value);
                writer.Flush();
            }
            else
            {
                WriteUsingSerializerC(writer, value, jsonTypeInfo);
            }
        }

        private static void WriteUsingGeneratedSerializerS<TValue>(Utf8JsonWriter writer, in TValue value, JsonTypeInfo jsonTypeInfo) where TValue : struct
        {
            Debug.Assert(writer != null);

            if (jsonTypeInfo.HasSerialize &&
                jsonTypeInfo is JsonTypeInfoS<TValue> typedInfo &&
                typedInfo.Options._context?.CanUseSerializationLogic == true)
            {
                Debug.Assert(typedInfo.SerializeHandler != null);
                typedInfo.SerializeHandler(writer, value);
                writer.Flush();
            }
            else
            {
                WriteUsingSerializerS(writer, value, jsonTypeInfo);
            }
        }

        private static void WriteUsingSerializerC<TValue>(Utf8JsonWriter writer, in TValue value, JsonTypeInfo jsonTypeInfo) where TValue : class
        {
            Debug.Assert(writer != null);

            Debug.Assert(!jsonTypeInfo.HasSerialize ||
                         !(jsonTypeInfo is JsonTypeInfoC<TValue>) ||
                         jsonTypeInfo.Options._context == null ||
                         !jsonTypeInfo.Options._context.CanUseSerializationLogic,
                "Incorrect method called. WriteUsingGeneratedSerializer() should have been called instead.");

            WriteStack state = default;
            state.Initialize(jsonTypeInfo, supportContinuation: false);

            JsonConverter converter = jsonTypeInfo.PropertyInfoForTypeInfo.ConverterBase;
            Debug.Assert(converter != null);
            Debug.Assert(jsonTypeInfo.Options != null);

            // For performance, the code below is a lifted WriteCore() above.
            if (converter is JsonConverterC<TValue> typedConverter)
            {
                // Call the strongly-typed WriteCore that will not box structs.
                typedConverter.WriteCore(writer, value, jsonTypeInfo.Options, ref state);
            }
            else
            {
                // The non-generic API was called or we have a polymorphic case where TValue is not equal to the T in JsonConverter<T>.
                converter.WriteCoreAsObject(writer, value, jsonTypeInfo.Options, ref state);
            }

            writer.Flush();
        }

        private static void WriteUsingSerializerS<TValue>(Utf8JsonWriter writer, in TValue value, JsonTypeInfo jsonTypeInfo) where TValue : struct
        {
            Debug.Assert(writer != null);

            Debug.Assert(!jsonTypeInfo.HasSerialize ||
                         !(jsonTypeInfo is JsonTypeInfoS<TValue>) ||
                         jsonTypeInfo.Options._context == null ||
                         !jsonTypeInfo.Options._context.CanUseSerializationLogic,
                "Incorrect method called. WriteUsingGeneratedSerializer() should have been called instead.");

            WriteStack state = default;
            state.Initialize(jsonTypeInfo, supportContinuation: false);

            JsonConverter converter = jsonTypeInfo.PropertyInfoForTypeInfo.ConverterBase;
            Debug.Assert(converter != null);
            Debug.Assert(jsonTypeInfo.Options != null);

            // For performance, the code below is a lifted WriteCore() above.
            if (converter is JsonConverterS<TValue> typedConverter)
            {
                // Call the strongly-typed WriteCore that will not box structs.
                typedConverter.WriteCore(writer, value, jsonTypeInfo.Options, ref state);
            }
            else
            {
                // The non-generic API was called or we have a polymorphic case where TValue is not equal to the T in JsonConverter<T>.
                converter.WriteCoreAsObject(writer, value, jsonTypeInfo.Options, ref state);
            }

            writer.Flush();
        }

        private static Type GetRuntimeType<TValue>(in TValue value)
        {
            Type type = typeof(TValue);
            if (type == JsonTypeInfo.ObjectType && !(value is null))
            {
                type = value.GetType();
            }

            return type;
        }

        private static Type GetRuntimeTypeAndValidateInputType(object? value, Type inputType)
        {
            if (inputType is null)
            {
                throw new ArgumentNullException(nameof(inputType));
            }

            if (!(value is null))
            {
                Type runtimeType = value.GetType();
                if (!inputType.IsAssignableFrom(runtimeType))
                {
                    ThrowHelper.ThrowArgumentException_DeserializeWrongType(inputType, value);
                }

                if (inputType == JsonTypeInfo.ObjectType)
                {
                    return runtimeType;
                }
            }

            return inputType;
        }
    }
}
