﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#nullable enable

using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json.Reflection;
using System.Text.Json.Serialization.Converters;

namespace System.Text.Json.Serialization
{
    /*
    /// <summary>
    /// Converter for streaming <see cref="IAsyncEnumerable{T}" /> values.
    /// </summary>
    internal sealed class IAsyncEnumerableConverterFactory : JsonConverterFactory
    {
        public override bool CanConvert(Type typeToConvert) => !(GetAsyncEnumerableInterface(typeToConvert) is null);

        public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            Type? asyncEnumerableInterface = GetAsyncEnumerableInterface(typeToConvert);
            Debug.Assert(asyncEnumerableInterface is not null, $"{typeToConvert} not supported by converter.");

            Type elementType = asyncEnumerableInterface.GetGenericArguments()[0];
            Type converterType = typeof(IAsyncEnumerableOfTConverter<,>).MakeGenericType(typeToConvert, elementType);
            return (JsonConverter)Activator.CreateInstance(converterType)!;
        }

        private static Type? GetAsyncEnumerableInterface(Type type)
            => type.GetCompatibleGenericInterface(typeof(IAsyncEnumerable<>));
    }
    */
}
