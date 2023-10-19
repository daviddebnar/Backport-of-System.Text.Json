// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace System.Text.Json
{
    public static partial class JsonSerializer
    {
        /// <summary>
        /// Converts the provided value into a <see cref="string"/>.
        /// </summary>
        /// <returns>A <see cref="string"/> representation of the value.</returns>
        /// <param name="value">The value to convert.</param>
        /// <param name="options">Options to control the conversion behavior.</param>
        /// <exception cref="NotSupportedException">
        /// There is no compatible <see cref="System.Text.Json.Serialization.JsonConverter"/>
        /// for <typeparamref name="TValue"/> or its serializable members.
        /// </exception>
        /// <remarks>Using a <see cref="string"/> is not as efficient as using UTF-8
        /// encoding since the implementation internally uses UTF-8. See also <see cref="SerializeToUtf8Bytes{TValue}(TValue, JsonSerializerOptions?)"/>
        /// and <see cref="SerializeAsync{TValue}(IO.Stream, TValue, JsonSerializerOptions?, Threading.CancellationToken)"/>.
        /// </remarks>
        [RequiresUnreferencedCode(SerializationUnreferencedCodeMessage)]
        public static string SerializeC<TValue>(TValue value, JsonSerializerOptions? options = null) where TValue : class
        {
            Type runtimeType = GetRuntimeType(value);
            JsonTypeInfo jsonTypeInfo = GetTypeInfo(options, runtimeType);
            return WriteStringUsingSerializerC(value, jsonTypeInfo);
        }
        
        /// <summary>
        /// Converts the provided value into a <see cref="string"/>.
        /// </summary>
        /// <returns>A <see cref="string"/> representation of the value.</returns>
        /// <param name="value">The value to convert.</param>
        /// <param name="options">Options to control the conversion behavior.</param>
        /// <exception cref="NotSupportedException">
        /// There is no compatible <see cref="System.Text.Json.Serialization.JsonConverter"/>
        /// for <typeparamref name="TValue"/> or its serializable members.
        /// </exception>
        /// <remarks>Using a <see cref="string"/> is not as efficient as using UTF-8
        /// encoding since the implementation internally uses UTF-8. See also <see cref="SerializeToUtf8Bytes{TValue}(TValue, JsonSerializerOptions?)"/>
        /// and <see cref="SerializeAsync{TValue}(IO.Stream, TValue, JsonSerializerOptions?, Threading.CancellationToken)"/>.
        /// </remarks>
        [RequiresUnreferencedCode(SerializationUnreferencedCodeMessage)]
        public static string SerializeS<TValue>(TValue value, JsonSerializerOptions? options = null) where TValue : struct
        {
            Type runtimeType = GetRuntimeType(value);
            JsonTypeInfo jsonTypeInfo = GetTypeInfo(options, runtimeType);
            return WriteStringUsingSerializerS(value, jsonTypeInfo);
        }

        /// <summary>
        /// Converts the provided value into a <see cref="string"/>.
        /// </summary>
        /// <returns>A <see cref="string"/> representation of the value.</returns>
        /// <param name="value">The value to convert.</param>
        /// <param name="inputType">The type of the <paramref name="value"/> to convert.</param>
        /// <param name="options">Options to control the conversion behavior.</param>
        /// <exception cref="ArgumentException">
        /// <paramref name="inputType"/> is not compatible with <paramref name="value"/>.
        /// </exception>
        /// <exception cref="NotSupportedException">
        /// There is no compatible <see cref="System.Text.Json.Serialization.JsonConverter"/>
        /// for <paramref name="inputType"/>  or its serializable members.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="inputType"/> is <see langword="null"/>.
        /// </exception>
        /// <remarks>Using a <see cref="string"/> is not as efficient as using UTF-8
        /// encoding since the implementation internally uses UTF-8. See also <see cref="SerializeToUtf8Bytes(object?, Type, JsonSerializerOptions?)"/>
        /// and <see cref="SerializeAsync(IO.Stream, object?, Type, JsonSerializerOptions?, Threading.CancellationToken)"/>.
        /// </remarks>
        [RequiresUnreferencedCode(SerializationUnreferencedCodeMessage)]
        public static string Serialize(
            object? value,
            Type inputType,
            JsonSerializerOptions? options = null)
        {
            Type runtimeType = GetRuntimeTypeAndValidateInputType(value, inputType);
            JsonTypeInfo jsonTypeInfo = GetTypeInfo(options, runtimeType);
            return WriteStringUsingSerializerC(value, jsonTypeInfo);
        }

        /// <summary>
        /// Converts the provided value into a <see cref="string"/>.
        /// </summary>
        /// <returns>A <see cref="string"/> representation of the value.</returns>
        /// <param name="value">The value to convert.</param>
        /// <param name="jsonTypeInfo">Metadata about the type to convert.</param>
        /// <exception cref="NotSupportedException">
        /// There is no compatible <see cref="Serialization.JsonConverter"/>
        /// for <typeparamref name="TValue"/> or its serializable members.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="jsonTypeInfo"/> is <see langword="null"/>.
        /// </exception>
        /// <remarks>Using a <see cref="string"/> is not as efficient as using UTF-8
        /// encoding since the implementation internally uses UTF-8. See also <see cref="SerializeToUtf8Bytes{TValue}(TValue, JsonTypeInfo{TValue})"/>
        /// and <see cref="SerializeAsync{TValue}(IO.Stream, TValue, JsonTypeInfo{TValue}, Threading.CancellationToken)"/>.
        /// </remarks>
        public static string SerializeC<TValue>(TValue value, JsonTypeInfoC<TValue> jsonTypeInfo) where TValue : class
        {
            return WriteStringUsingGeneratedSerializerC(value, jsonTypeInfo);
        }

        /// <summary>
        /// Converts the provided value into a <see cref="string"/>.
        /// </summary>
        /// <returns>A <see cref="string"/> representation of the value.</returns>
        /// <param name="value">The value to convert.</param>
        /// <param name="jsonTypeInfo">Metadata about the type to convert.</param>
        /// <exception cref="NotSupportedException">
        /// There is no compatible <see cref="Serialization.JsonConverter"/>
        /// for <typeparamref name="TValue"/> or its serializable members.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="jsonTypeInfo"/> is <see langword="null"/>.
        /// </exception>
        /// <remarks>Using a <see cref="string"/> is not as efficient as using UTF-8
        /// encoding since the implementation internally uses UTF-8. See also <see cref="SerializeToUtf8Bytes{TValue}(TValue, JsonTypeInfo{TValue})"/>
        /// and <see cref="SerializeAsync{TValue}(IO.Stream, TValue, JsonTypeInfo{TValue}, Threading.CancellationToken)"/>.
        /// </remarks>
        public static string SerializeS<TValue>(TValue value, JsonTypeInfoS<TValue> jsonTypeInfo) where TValue : struct
        {
            return WriteStringUsingGeneratedSerializerS(value, jsonTypeInfo);
        }

        /// <summary>
        /// Converts the provided value into a <see cref="string"/>.
        /// </summary>
        /// <returns>A <see cref="string"/> representation of the value.</returns>
        /// <param name="value">The value to convert.</param>
        /// <param name="inputType">The type of the <paramref name="value"/> to convert.</param>
        /// <param name="context">A metadata provider for serializable types.</param>
        /// <exception cref="NotSupportedException">
        /// There is no compatible <see cref="System.Text.Json.Serialization.JsonConverter"/>
        /// for <paramref name="inputType"/> or its serializable members.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// The <see cref="JsonSerializerContext.GetTypeInfo(Type)"/> method of the provided
        /// <paramref name="context"/> returns <see langword="null"/> for the type to convert.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="inputType"/> or <paramref name="context"/> is <see langword="null"/>.
        /// </exception>
        /// <remarks>Using a <see cref="string"/> is not as efficient as using UTF-8
        /// encoding since the implementation internally uses UTF-8. See also <see cref="SerializeToUtf8Bytes(object?, Type, JsonSerializerContext)"/>
        /// and <see cref="SerializeAsync(IO.Stream, object?, Type, JsonSerializerContext, Threading.CancellationToken)"/>.
        /// </remarks>
        public static string Serialize(object? value, Type inputType, JsonSerializerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            Type type = GetRuntimeTypeAndValidateInputType(value, inputType);
            JsonTypeInfo jsonTypeInfo = GetTypeInfo(context, type);
            return WriteStringUsingGeneratedSerializerC(value, jsonTypeInfo);
        }

        private static string WriteStringUsingGeneratedSerializerC<TValue>(in TValue value, JsonTypeInfo? jsonTypeInfo) where TValue : class
        {
            if (jsonTypeInfo == null)
            {
                throw new ArgumentNullException(nameof(jsonTypeInfo));
            }

            JsonSerializerOptions options = jsonTypeInfo.Options;

            using (var output = new PooledByteBufferWriter(options.DefaultBufferSize))
            {
                using (var writer = new Utf8JsonWriter(output, options.GetWriterOptions()))
                {
                    WriteUsingGeneratedSerializerC(writer, value, jsonTypeInfo);
                }

                return JsonReaderHelper.TranscodeHelper(output.WrittenMemory.Span);
            }
        }

        private static string WriteStringUsingGeneratedSerializerS<TValue>(in TValue value, JsonTypeInfo? jsonTypeInfo) where TValue : struct
        {
            if (jsonTypeInfo == null)
            {
                throw new ArgumentNullException(nameof(jsonTypeInfo));
            }

            JsonSerializerOptions options = jsonTypeInfo.Options;

            using (var output = new PooledByteBufferWriter(options.DefaultBufferSize))
            {
                using (var writer = new Utf8JsonWriter(output, options.GetWriterOptions()))
                {
                    WriteUsingGeneratedSerializerS(writer, value, jsonTypeInfo);
                }

                return JsonReaderHelper.TranscodeHelper(output.WrittenMemory.Span);
            }
        }

        private static string WriteStringUsingSerializerC<TValue>(in TValue value, JsonTypeInfo? jsonTypeInfo) where TValue : class
        {
            if (jsonTypeInfo == null)
            {
                throw new ArgumentNullException(nameof(jsonTypeInfo));
            }

            JsonSerializerOptions options = jsonTypeInfo.Options;

            using (var output = new PooledByteBufferWriter(options.DefaultBufferSize))
            {
                using (var writer = new Utf8JsonWriter(output, options.GetWriterOptions()))
                {
                    WriteUsingSerializerC(writer, value, jsonTypeInfo);
                }

                return JsonReaderHelper.TranscodeHelper(output.WrittenMemory.Span);
            }
        }

        private static string WriteStringUsingSerializerS<TValue>(in TValue value, JsonTypeInfo? jsonTypeInfo) where TValue : struct
        {
            if (jsonTypeInfo == null)
            {
                throw new ArgumentNullException(nameof(jsonTypeInfo));
            }

            JsonSerializerOptions options = jsonTypeInfo.Options;

            using (var output = new PooledByteBufferWriter(options.DefaultBufferSize))
            {
                using (var writer = new Utf8JsonWriter(output, options.GetWriterOptions()))
                {
                    WriteUsingSerializerS(writer, value, jsonTypeInfo);
                }

                return JsonReaderHelper.TranscodeHelper(output.WrittenMemory.Span);
            }
        }
    }
}
