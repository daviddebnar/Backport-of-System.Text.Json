// Licensed to the .NET Foundation under one or more agreements.
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
        /// Converts the provided value into a <see cref="byte"/> array.
        /// </summary>
        /// <returns>A UTF-8 representation of the value.</returns>
        /// <param name="value">The value to convert.</param>
        /// <param name="options">Options to control the conversion behavior.</param>
        /// <exception cref="NotSupportedException">
        /// There is no compatible <see cref="System.Text.Json.Serialization.JsonConverter"/>
        /// for <typeparamref name="TValue"/> or its serializable members.
        /// </exception>
        [RequiresUnreferencedCode(SerializationUnreferencedCodeMessage)]
        public static byte[] SerializeToUtf8BytesC<TValue>(
            TValue value,
            JsonSerializerOptions? options = null) where TValue : class
        {
            Type runtimeType = GetRuntimeType(value);
            JsonTypeInfo jsonTypeInfo = GetTypeInfo(options, runtimeType);
            return WriteBytesUsingSerializerC(value, jsonTypeInfo);
        }
        
        /// <summary>
        /// Converts the provided value into a <see cref="byte"/> array.
        /// </summary>
        /// <returns>A UTF-8 representation of the value.</returns>
        /// <param name="value">The value to convert.</param>
        /// <param name="options">Options to control the conversion behavior.</param>
        /// <exception cref="NotSupportedException">
        /// There is no compatible <see cref="System.Text.Json.Serialization.JsonConverter"/>
        /// for <typeparamref name="TValue"/> or its serializable members.
        /// </exception>
        [RequiresUnreferencedCode(SerializationUnreferencedCodeMessage)]
        public static byte[] SerializeToUtf8BytesS<TValue>(
            TValue value,
            JsonSerializerOptions? options = null) where TValue : struct
        {
            Type runtimeType = GetRuntimeType(value);
            JsonTypeInfo jsonTypeInfo = GetTypeInfo(options, runtimeType);
            return WriteBytesUsingSerializerS(value, jsonTypeInfo);
        }

        /// <summary>
        /// Converts the provided value into a <see cref="byte"/> array.
        /// </summary>
        /// <returns>A UTF-8 representation of the value.</returns>
        /// <param name="value">The value to convert.</param>
        /// <param name="inputType">The type of the <paramref name="value"/> to convert.</param>
        /// <param name="options">Options to control the conversion behavior.</param>
        /// <exception cref="ArgumentException">
        /// <paramref name="inputType"/> is not compatible with <paramref name="value"/>.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// <paramref name="inputType"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="NotSupportedException">
        /// There is no compatible <see cref="System.Text.Json.Serialization.JsonConverter"/>
        /// for <paramref name="inputType"/>  or its serializable members.
        /// </exception>
        [RequiresUnreferencedCode(SerializationUnreferencedCodeMessage)]
        public static byte[] SerializeToUtf8Bytes(
            object? value,
            Type inputType,
            JsonSerializerOptions? options = null)
        {
            Type runtimeType = GetRuntimeTypeAndValidateInputType(value, inputType);
            JsonTypeInfo jsonTypeInfo = GetTypeInfo(options, runtimeType);
            return WriteBytesUsingSerializerC(value, jsonTypeInfo);
        }

        /// <summary>
        /// Converts the provided value into a <see cref="byte"/> array.
        /// </summary>
        /// <returns>A UTF-8 representation of the value.</returns>
        /// <param name="value">The value to convert.</param>
        /// <param name="jsonTypeInfo">Metadata about the type to convert.</param>
        /// <exception cref="NotSupportedException">
        /// There is no compatible <see cref="System.Text.Json.Serialization.JsonConverter"/>
        /// for <typeparamref name="TValue"/> or its serializable members.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="jsonTypeInfo"/> is <see langword="null"/>.
        /// </exception>
        public static byte[] SerializeToUtf8BytesC<TValue>(TValue value, JsonTypeInfoC<TValue> jsonTypeInfo) where TValue : class
        {
            if (jsonTypeInfo == null)
            {
                throw new ArgumentNullException(nameof(jsonTypeInfo));
            }

            return WriteBytesUsingGeneratedSerializerC(value, jsonTypeInfo);
        }
        

        /// <summary>
        /// Converts the provided value into a <see cref="byte"/> array.
        /// </summary>
        /// <returns>A UTF-8 representation of the value.</returns>
        /// <param name="value">The value to convert.</param>
        /// <param name="jsonTypeInfo">Metadata about the type to convert.</param>
        /// <exception cref="NotSupportedException">
        /// There is no compatible <see cref="System.Text.Json.Serialization.JsonConverter"/>
        /// for <typeparamref name="TValue"/> or its serializable members.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="jsonTypeInfo"/> is <see langword="null"/>.
        /// </exception>
        public static byte[] SerializeToUtf8BytesS<TValue>(TValue value, JsonTypeInfoS<TValue> jsonTypeInfo) where TValue : struct
        {
            if (jsonTypeInfo == null)
            {
                throw new ArgumentNullException(nameof(jsonTypeInfo));
            }

            return WriteBytesUsingGeneratedSerializerS(value, jsonTypeInfo);
        }

        /// <summary>
        /// Converts the provided value into a <see cref="byte"/> array.
        /// </summary>
        /// <returns>A UTF-8 representation of the value.</returns>
        /// <param name="value">The value to convert.</param>
        /// <param name="inputType">The type of the <paramref name="value"/> to convert.</param>
        /// <param name="context">A metadata provider for serializable types.</param>
        /// <exception cref="ArgumentException">
        /// <paramref name="inputType"/> is not compatible with <paramref name="value"/>.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// <paramref name="inputType"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="NotSupportedException">
        /// There is no compatible <see cref="System.Text.Json.Serialization.JsonConverter"/>
        /// for <paramref name="inputType"/>  or its serializable members.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// The <see cref="JsonSerializerContext.GetTypeInfo(Type)"/> method of the provided
        /// <paramref name="context"/> returns <see langword="null"/> for the type to convert.
        /// </exception>
        public static byte[] SerializeToUtf8Bytes(object? value, Type inputType, JsonSerializerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            Type runtimeType = GetRuntimeTypeAndValidateInputType(value, inputType);
            JsonTypeInfo jsonTypeInfo = GetTypeInfo(context, runtimeType);
            return WriteBytesUsingGeneratedSerializerC(value!, jsonTypeInfo);
        }

        private static byte[] WriteBytesUsingGeneratedSerializerC<TValue>(in TValue value, JsonTypeInfo jsonTypeInfo) where TValue : class
        {
            JsonSerializerOptions options = jsonTypeInfo.Options;

            using var output = new PooledByteBufferWriter(options.DefaultBufferSize);
            using (var writer = new Utf8JsonWriter(output, options.GetWriterOptions()))
            {
                WriteUsingGeneratedSerializerC(writer, value, jsonTypeInfo);
            }

            return output.WrittenMemory.ToArray();
        }
        
        private static byte[] WriteBytesUsingGeneratedSerializerS<TValue>(in TValue value, JsonTypeInfo jsonTypeInfo) where TValue : struct
        {
            JsonSerializerOptions options = jsonTypeInfo.Options;

            using var output = new PooledByteBufferWriter(options.DefaultBufferSize);
            using (var writer = new Utf8JsonWriter(output, options.GetWriterOptions()))
            {
                WriteUsingGeneratedSerializerS(writer, value, jsonTypeInfo);
            }

            return output.WrittenMemory.ToArray();
        }

        private static byte[] WriteBytesUsingSerializerC<TValue>(in TValue value, JsonTypeInfo jsonTypeInfo) where TValue : class
        {
            JsonSerializerOptions options = jsonTypeInfo.Options;

            using var output = new PooledByteBufferWriter(options.DefaultBufferSize);
            using (var writer = new Utf8JsonWriter(output, options.GetWriterOptions()))
            {
                WriteUsingSerializerC(writer, value, jsonTypeInfo);
            }

            return output.WrittenMemory.ToArray();
        }

        private static byte[] WriteBytesUsingSerializerS<TValue>(in TValue value, JsonTypeInfo jsonTypeInfo) where TValue : struct
        {
            JsonSerializerOptions options = jsonTypeInfo.Options;

            using var output = new PooledByteBufferWriter(options.DefaultBufferSize);
            using (var writer = new Utf8JsonWriter(output, options.GetWriterOptions()))
            {
                WriteUsingSerializerS(writer, value, jsonTypeInfo);
            }

            return output.WrittenMemory.ToArray();
        }
    }
}
