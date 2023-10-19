﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#nullable enable

using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace System.Text.Json
{
    public static partial class JsonSerializer
    {
        /// <summary>
        /// Converts the <see cref="JsonElement"/> representing a single JSON value into a <typeparamref name="TValue"/>.
        /// </summary>
        /// <returns>A <typeparamref name="TValue"/> representation of the JSON value.</returns>
        /// <param name="element">The <see cref="JsonElement"/> to convert.</param>
        /// <param name="options">Options to control the behavior during parsing.</param>
        /// <exception cref="JsonException">
        /// <typeparamref name="TValue" /> is not compatible with the JSON.
        /// </exception>
        /// <exception cref="NotSupportedException">
        /// There is no compatible <see cref="System.Text.Json.Serialization.JsonConverter"/>
        /// for <typeparamref name="TValue"/> or its serializable members.
        /// </exception>
        [RequiresUnreferencedCode(SerializationUnreferencedCodeMessage)]
        public static TValue? DeserializeC<TValue>(this JsonElement element, JsonSerializerOptions? options = null) where TValue : class
        {
            JsonTypeInfo jsonTypeInfo = GetTypeInfo(options, typeof(TValue));
            return ReadUsingMetadataC<TValue>(element, jsonTypeInfo);
        }
        
        /// <summary>
        /// Converts the <see cref="JsonElement"/> representing a single JSON value into a <typeparamref name="TValue"/>.
        /// </summary>
        /// <returns>A <typeparamref name="TValue"/> representation of the JSON value.</returns>
        /// <param name="element">The <see cref="JsonElement"/> to convert.</param>
        /// <param name="options">Options to control the behavior during parsing.</param>
        /// <exception cref="JsonException">
        /// <typeparamref name="TValue" /> is not compatible with the JSON.
        /// </exception>
        /// <exception cref="NotSupportedException">
        /// There is no compatible <see cref="System.Text.Json.Serialization.JsonConverter"/>
        /// for <typeparamref name="TValue"/> or its serializable members.
        /// </exception>
        [RequiresUnreferencedCode(SerializationUnreferencedCodeMessage)]
        public static TValue? DeserializeS<TValue>(this JsonElement element, JsonSerializerOptions? options = null) where TValue : struct
        {
            JsonTypeInfo jsonTypeInfo = GetTypeInfo(options, typeof(TValue));
            return ReadUsingMetadataS<TValue>(element, jsonTypeInfo);
        }

        /// <summary>
        /// Converts the <see cref="JsonElement"/> representing a single JSON value into a <paramref name="returnType"/>.
        /// </summary>
        /// <returns>A <paramref name="returnType"/> representation of the JSON value.</returns>
        /// <param name="element">The <see cref="JsonElement"/> to convert.</param>
        /// <param name="returnType">The type of the object to convert to and return.</param>
        /// <param name="options">Options to control the behavior during parsing.</param>
        /// <exception cref="System.ArgumentNullException">
        /// <paramref name="returnType"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="JsonException">
        /// <paramref name="returnType"/> is not compatible with the JSON.
        /// </exception>
        /// <exception cref="NotSupportedException">
        /// There is no compatible <see cref="System.Text.Json.Serialization.JsonConverter"/>
        /// for <paramref name="returnType"/> or its serializable members.
        /// </exception>
        [RequiresUnreferencedCode(SerializationUnreferencedCodeMessage)]
        public static object? Deserialize(this JsonElement element, Type returnType, JsonSerializerOptions? options = null)
        {
            if (returnType == null)
            {
                throw new ArgumentNullException(nameof(returnType));
            }

            JsonTypeInfo jsonTypeInfo = GetTypeInfo(options, returnType);
            return ReadUsingMetadataC<object?>(element, jsonTypeInfo);
        }

        /// <summary>
        /// Converts the <see cref="JsonElement"/> representing a single JSON value into a <typeparamref name="TValue"/>.
        /// </summary>
        /// <returns>A <typeparamref name="TValue"/> representation of the JSON value.</returns>
        /// <param name="element">The <see cref="JsonElement"/> to convert.</param>
        /// <param name="jsonTypeInfo">Metadata about the type to convert.</param>
        /// <exception cref="System.ArgumentNullException">
        /// <paramref name="jsonTypeInfo"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="JsonException">
        /// <typeparamref name="TValue" /> is not compatible with the JSON.
        /// </exception>
        /// <exception cref="NotSupportedException">
        /// There is no compatible <see cref="System.Text.Json.Serialization.JsonConverter"/>
        /// for <typeparamref name="TValue"/> or its serializable members.
        /// </exception>
        public static TValue? DeserializeC<TValue>(this JsonElement element, JsonTypeInfoC<TValue> jsonTypeInfo) where TValue : class
        {
            if (jsonTypeInfo == null)
            {
                throw new ArgumentNullException(nameof(jsonTypeInfo));
            }

            return ReadUsingMetadataC<TValue>(element, jsonTypeInfo);
        }
        

        /// <summary>
        /// Converts the <see cref="JsonElement"/> representing a single JSON value into a <typeparamref name="TValue"/>.
        /// </summary>
        /// <returns>A <typeparamref name="TValue"/> representation of the JSON value.</returns>
        /// <param name="element">The <see cref="JsonElement"/> to convert.</param>
        /// <param name="jsonTypeInfo">Metadata about the type to convert.</param>
        /// <exception cref="System.ArgumentNullException">
        /// <paramref name="jsonTypeInfo"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="JsonException">
        /// <typeparamref name="TValue" /> is not compatible with the JSON.
        /// </exception>
        /// <exception cref="NotSupportedException">
        /// There is no compatible <see cref="System.Text.Json.Serialization.JsonConverter"/>
        /// for <typeparamref name="TValue"/> or its serializable members.
        /// </exception>
        public static TValue? DeserializeS<TValue>(this JsonElement element, JsonTypeInfoS<TValue> jsonTypeInfo) where TValue : struct
        {
            if (jsonTypeInfo == null)
            {
                throw new ArgumentNullException(nameof(jsonTypeInfo));
            }

            return ReadUsingMetadataS<TValue>(element, jsonTypeInfo);
        }

        /// <summary>
        /// Converts the <see cref="JsonElement"/> representing a single JSON value into a <paramref name="returnType"/>.
        /// </summary>
        /// <returns>A <paramref name="returnType"/> representation of the JSON value.</returns>
        /// <param name="element">The <see cref="JsonElement"/> to convert.</param>
        /// <param name="returnType">The type of the object to convert to and return.</param>
        /// <param name="context">A metadata provider for serializable types.</param>
        /// <exception cref="System.ArgumentNullException">
        /// <paramref name="returnType"/> is <see langword="null"/>.
        ///
        /// -or-
        ///
        /// <paramref name="context"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="JsonException">
        /// The JSON is invalid.
        ///
        /// -or-
        ///
        /// <paramref name="returnType" /> is not compatible with the JSON.
        ///
        /// -or-
        ///
        /// There is remaining data in the string beyond a single JSON value.</exception>
        /// <exception cref="NotSupportedException">
        /// There is no compatible <see cref="System.Text.Json.Serialization.JsonConverter"/>
        /// for <paramref name="returnType"/> or its serializable members.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// The <see cref="JsonSerializerContext.GetTypeInfo(Type)"/> method of the provided
        /// <paramref name="context"/> returns <see langword="null"/> for the type to convert.
        /// </exception>
        public static object? Deserialize(this JsonElement element, Type returnType, JsonSerializerContext context)
        {
            if (returnType == null)
            {
                throw new ArgumentNullException(nameof(returnType));
            }

            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            JsonTypeInfo jsonTypeInfo = GetTypeInfo(context, returnType);
            return ReadUsingMetadataC<object?>(element, jsonTypeInfo);
        }

        private static TValue? ReadUsingMetadataC<TValue>(JsonElement element, JsonTypeInfo jsonTypeInfo) where TValue : class
        {
            ReadOnlySpan<byte> utf8Json = element.GetRawValue().Span;
            return ReadFromSpanC<TValue>(utf8Json, jsonTypeInfo);
        }
        

        private static TValue? ReadUsingMetadataS<TValue>(JsonElement element, JsonTypeInfo jsonTypeInfo) where TValue : struct
        {
            ReadOnlySpan<byte> utf8Json = element.GetRawValue().Span;
            return ReadFromSpanS<TValue>(utf8Json, jsonTypeInfo);
        }
    }
}