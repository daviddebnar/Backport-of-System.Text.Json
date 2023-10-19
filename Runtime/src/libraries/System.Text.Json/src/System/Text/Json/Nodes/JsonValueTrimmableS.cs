// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#nullable enable

using System.Diagnostics;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace System.Text.Json.Nodes
{
    /// <summary>
    /// Trim-safe since it either calls the converter directly or calls the JsonSerializer.Serialize(JsonTypeInfo{TValue}).
    /// </summary>
    internal sealed partial class JsonValueTrimmableS<TValue> : JsonValueS<TValue> where TValue : struct
    {
        private readonly JsonTypeInfoS<TValue>? _jsonTypeInfo;
        private readonly JsonConverterS<TValue>? _converter;

        public JsonValueTrimmableS(TValue value, JsonTypeInfoS<TValue> jsonTypeInfo, JsonNodeOptions? options = null) : base(value, options)
        {
            _jsonTypeInfo = jsonTypeInfo;
        }

        public JsonValueTrimmableS(TValue value, JsonConverterS<TValue> converter, JsonNodeOptions? options = null) : base(value, options)
        {
            _converter = converter;
        }

        public override void WriteTo(Utf8JsonWriter writer, JsonSerializerOptions? options = null)
        {
            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }

            if (_converter != null)
            {
                options ??= JsonSerializerOptions.s_defaultOptions;

                if (_converter.IsInternalConverterForNumberType)
                {
                    _converter.WriteNumberWithCustomHandling(writer, _value, options.NumberHandling);
                }
                else
                {
                    _converter.Write(writer, _value, options);
                }
            }
            else
            {
                Debug.Assert(_jsonTypeInfo != null);
                JsonSerializer.Serialize(writer, _value, _jsonTypeInfo!.ElementType!);
            }
        }

        public override bool TryGetValue<T>(out T? value)
        {
            throw new NotImplementedException();
        }
    }
}
