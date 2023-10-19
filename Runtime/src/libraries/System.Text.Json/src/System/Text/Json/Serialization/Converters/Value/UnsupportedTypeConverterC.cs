// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#nullable enable

namespace System.Text.Json.Serialization.Converters
{
    internal sealed class UnsupportedTypeConverterC<T> : JsonConverterC<T> where T : class
    {
        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
            throw new NotSupportedException(SR.Format(SR.SerializeTypeInstanceNotSupported, typeof(T).FullName));

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options) =>
            throw new NotSupportedException(SR.Format(SR.SerializeTypeInstanceNotSupported, typeof(T).FullName));
    }
}
