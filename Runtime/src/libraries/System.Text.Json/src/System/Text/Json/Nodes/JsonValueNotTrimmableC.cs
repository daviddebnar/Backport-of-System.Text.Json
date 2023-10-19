// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#nullable enable

using System.Diagnostics.CodeAnalysis;

namespace System.Text.Json.Nodes
{
    /// <summary>
    /// Not trim-safe since it calls JsonSerializer.Serialize(JsonSerializerOptions).
    /// </summary>
    internal sealed partial class JsonValueNotTrimmableC<TValue> : JsonValueC<TValue> where TValue : class
    {
        [RequiresUnreferencedCode(JsonSerializer.SerializationUnreferencedCodeMessage)]
        public JsonValueNotTrimmableC(TValue value, JsonNodeOptions? options = null) : base(value, options) { }

        [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode",
            Justification = "The ctor is marked with RequiresUnreferencedCode.")]
        public override void WriteTo(Utf8JsonWriter writer, JsonSerializerOptions? options = null)
        {
            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }

            JsonSerializer.Serialize(writer, _value, _value.GetType(), options);
        }

        public override bool TryGetValue<T>(out T? value)
        {
            throw new NotImplementedException();
        }
    }
}
