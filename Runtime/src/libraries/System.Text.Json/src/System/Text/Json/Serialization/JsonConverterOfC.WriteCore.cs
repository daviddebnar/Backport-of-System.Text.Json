// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#nullable enable

namespace System.Text.Json.Serialization
{
    public partial class JsonConverterC<T> where T : class
    {
        internal sealed override bool WriteCoreAsObject(
            Utf8JsonWriter writer,
            object? value,
            JsonSerializerOptions options,
            ref WriteStack state)
        {
            if (IsValueType)
            {
                // Value types can never have a null except for Nullable<T>.
                if (value == null && Nullable.GetUnderlyingType(TypeToConvert) == null)
                {
                    ThrowHelper.ThrowJsonException_DeserializeUnableToConvertValue(TypeToConvert);
                }

                // Root object is a boxed value type, we need to push it to the reference stack before it gets unboxed here.
                if (options.ReferenceHandlingStrategy == ReferenceHandlingStrategy.IgnoreCycles && value != null)
                {
                    state.ReferenceResolver.PushReferenceForCycleDetection(value);
                }
            }

            T actualValue = (T)value!;
            return WriteCore(writer, actualValue, options, ref state);
        }

        internal bool WriteCore(
            Utf8JsonWriter writer,
            in T value,
            JsonSerializerOptions options,
            ref WriteStack state)
        {
            try
            {
                return TryWrite(writer, value, options, ref state);
            }
            catch (InvalidOperationException ex) when (ex.Source == ThrowHelper.ExceptionSourceValueToRethrowAsJsonException)
            {
                ThrowHelper.ReThrowWithPath(ref state, ex);
                throw;
            }
            catch (JsonException ex) when (ex.Path == null)
            {
                // JsonExceptions where the Path property is already set
                // typically originate from nested calls to JsonSerializer;
                // treat these cases as any other exception type and do not
                // overwrite any exception information.

                ThrowHelper.AddJsonExceptionInformation(ref state, ex);
                throw;
            }
            catch (NotSupportedException ex)
            {
                // If the message already contains Path, just re-throw. This could occur in serializer re-entry cases.
                // To get proper Path semantics in re-entry cases, APIs that take 'state' need to be used.
                if (ex.Message.Contains(" Path: "))
                {
                    throw;
                }

                ThrowHelper.ThrowNotSupportedException(ref state, ex);
                return default;
            }
        }
    }
}
