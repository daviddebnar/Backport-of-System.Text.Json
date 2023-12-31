// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Diagnostics;

namespace System.Text.Json.Serialization.Converters
{
    internal sealed class ObjectConverter : JsonConverterC<object?>
    {
        public override object? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (options.UnknownTypeHandling == JsonUnknownTypeHandling.JsonElement)
            {
                return JsonElement.ParseValue(ref reader);
            }

            return JsonNodeConverter.Instance.Read(ref reader, typeToConvert, options);
        }

        public override void Write(Utf8JsonWriter writer, object? value, JsonSerializerOptions options)
        {
            Debug.Assert(value?.GetType() == typeof(object));

            writer.WriteStartObject();
            writer.WriteEndObject();
        }

        internal override object ReadAsPropertyNameCore(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            ThrowHelper.ThrowNotSupportedException_DictionaryKeyTypeNotSupported(TypeToConvert, this);
            return null!;
        }

        internal override void WriteAsPropertyNameCore(Utf8JsonWriter writer, object? value, JsonSerializerOptions options, bool isWritingExtensionDataProperty)
        {
            // This converter does not handle nulls.
            Debug.Assert(value != null);

            Type runtimeType = value.GetType();
            JsonConverter runtimeConverter = options.GetConverterInternal(runtimeType);
            if (runtimeConverter == this)
            {
                ThrowHelper.ThrowNotSupportedException_DictionaryKeyTypeNotSupported(runtimeType, this);
            }

            runtimeConverter.WriteAsPropertyNameCoreAsObject(writer, value, options, isWritingExtensionDataProperty);
        }
    }
}
