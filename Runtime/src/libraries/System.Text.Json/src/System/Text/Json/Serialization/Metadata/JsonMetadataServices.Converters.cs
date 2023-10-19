// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization.Converters;

namespace System.Text.Json.Serialization.Metadata
{
    public static partial class JsonMetadataServices
    {
        /// <summary>
        /// Returns a <see cref="JsonConverterC{T}"/> instance that converts <see cref="bool"/> values.
        /// </summary>
        public static JsonConverterS<bool> BooleanConverter => s_booleanConverter ??= new BooleanConverter();
        private static JsonConverterS<bool>? s_booleanConverter;

        /// <summary>
        /// Returns a <see cref="JsonConverterC{T}"/> instance that converts byte array values.
        /// </summary>
        public static JsonConverterC<byte[]> ByteArrayConverter => s_byteArrayConverter ??= new ByteArrayConverter();
        private static JsonConverterC<byte[]>? s_byteArrayConverter;

        /// <summary>
        /// Returns a <see cref="JsonConverterC{T}"/> instance that converts <see cref="byte"/> values.
        /// </summary>
        public static JsonConverterS<byte> ByteConverter => s_byteConverter ??= new ByteConverter();
        private static JsonConverterS<byte>? s_byteConverter;

        /// <summary>
        /// Returns a <see cref="JsonConverterC{T}"/> instance that converts <see cref="char"/> values.
        /// </summary>
        public static JsonConverterS<char> CharConverter => s_charConverter ??= new CharConverter();
        private static JsonConverterS<char>? s_charConverter;

        /// <summary>
        /// Returns a <see cref="JsonConverterC{T}"/> instance that converts <see cref="DateTime"/> values.
        /// </summary>
        public static JsonConverterS<DateTime> DateTimeConverter => s_dateTimeConverter ??= new DateTimeConverter();
        private static JsonConverterS<DateTime>? s_dateTimeConverter;

        /// <summary>
        /// Returns a <see cref="JsonConverterC{T}"/> instance that converts <see cref="DateTimeOffset"/> values.
        /// </summary>
        public static JsonConverterS<DateTimeOffset> DateTimeOffsetConverter => s_dateTimeOffsetConverter ??= new DateTimeOffsetConverter();
        private static JsonConverterS<DateTimeOffset>? s_dateTimeOffsetConverter;

        /// <summary>
        /// Returns a <see cref="JsonConverterC{T}"/> instance that converts <see cref="decimal"/> values.
        /// </summary>
        public static JsonConverterS<decimal> DecimalConverter => s_decimalConverter ??= new DecimalConverter();
        private static JsonConverterS<decimal>? s_decimalConverter;

        /// <summary>
        /// Returns a <see cref="JsonConverterC{T}"/> instance that converts <see cref="double"/> values.
        /// </summary>
        public static JsonConverterS<double> DoubleConverter => s_doubleConverter ??= new DoubleConverter();
        private static JsonConverterS<double>? s_doubleConverter;

        /// <summary>
        /// Returns a <see cref="JsonConverterC{T}"/> instance that converts <see cref="Guid"/> values.
        /// </summary>
        public static JsonConverterS<Guid> GuidConverter => s_guidConverter ??= new GuidConverter();
        private static JsonConverterS<Guid>? s_guidConverter;

        /// <summary>
        /// Returns a <see cref="JsonConverterC{T}"/> instance that converts <see cref="short"/> values.
        /// </summary>
        public static JsonConverterS<short> Int16Converter => s_int16Converter ??= new Int16Converter();
        private static JsonConverterS<short>? s_int16Converter;

        /// <summary>
        /// Returns a <see cref="JsonConverterC{T}"/> instance that converts <see cref="int"/> values.
        /// </summary>
        public static JsonConverterS<int> Int32Converter => s_int32Converter ??= new Int32Converter();
        private static JsonConverterS<int>? s_int32Converter;

        /// <summary>
        /// Returns a <see cref="JsonConverterC{T}"/> instance that converts <see cref="long"/> values.
        /// </summary>
        public static JsonConverterS<long> Int64Converter => s_int64Converter ??= new Int64Converter();
        private static JsonConverterS<long>? s_int64Converter;

        /// <summary>
        /// Returns a <see cref="JsonConverterC{T}"/> instance that converts <see cref="JsonArray"/> values.
        /// </summary>
        public static JsonConverterC<JsonArray> JsonArrayConverter => s_jsonArrayConverter ??= new JsonArrayConverter();
        private static JsonConverterC<JsonArray>? s_jsonArrayConverter;

        /// <summary>
        /// Returns a <see cref="JsonConverterC{T}"/> instance that converts <see cref="JsonElement"/> values.
        /// </summary>
        public static JsonConverterS<JsonElement> JsonElementConverter => s_jsonElementConverter ??= new JsonElementConverter();
        private static JsonConverterS<JsonElement>? s_jsonElementConverter;

        /// <summary>
        /// Returns a <see cref="JsonConverterC{T}"/> instance that converts <see cref="JsonNode"/> values.
        /// </summary>
        public static JsonConverterC<JsonNode> JsonNodeConverter => s_jsonNodeConverter ??= new JsonNodeConverter();
        private static JsonConverterC<JsonNode>? s_jsonNodeConverter;

        /// <summary>
        /// Returns a <see cref="JsonConverterC{T}"/> instance that converts <see cref="JsonObject"/> values.
        /// </summary>
        public static JsonConverterC<JsonObject> JsonObjectConverter => s_jsonObjectConverter ??= new JsonObjectConverter();
        private static JsonConverterC<JsonObject>? s_jsonObjectConverter;

        /// <summary>
        /// Returns a <see cref="JsonConverterC{T}"/> instance that converts <see cref="JsonArray"/> values.
        /// </summary>
        public static JsonConverterC<JsonValue> JsonValueConverter => s_jsonValueConverter ??= new JsonValueConverter();
        private static JsonConverterC<JsonValue>? s_jsonValueConverter;

        /// <summary>
        /// Returns a <see cref="JsonConverterC{T}"/> instance that converts <see cref="object"/> values.
        /// </summary>
        public static JsonConverterC<object?> ObjectConverter => s_objectConverter ??= new ObjectConverter();
        private static JsonConverterC<object?>? s_objectConverter;

        /// <summary>
        /// Returns a <see cref="JsonConverterC{T}"/> instance that converts <see cref="float"/> values.
        /// </summary>
        public static JsonConverterS<float> SingleConverter => s_singleConverter ??= new SingleConverter();
        private static JsonConverterS<float>? s_singleConverter;

        /// <summary>
        /// Returns a <see cref="JsonConverterC{T}"/> instance that converts <see cref="sbyte"/> values.
        /// </summary>
        [CLSCompliant(false)]
        public static JsonConverterS<sbyte> SByteConverter => s_sbyteConverter ??= new SByteConverter();
        private static JsonConverterS<sbyte>? s_sbyteConverter;

        /// <summary>
        /// Returns a <see cref="JsonConverterC{T}"/> instance that converts <see cref="string"/> values.
        /// </summary>
        public static JsonConverterC<string> StringConverter => s_stringConverter ??= new StringConverter();
        private static JsonConverterC<string>? s_stringConverter;

        /// <summary>
        /// Returns a <see cref="JsonConverterC{T}"/> instance that converts <see cref="TimeSpan"/> values.
        /// </summary>
        public static JsonConverterS<TimeSpan> TimeSpanConverter => s_timeSpanConverter ??= new TimeSpanConverter();
        private static JsonConverterS<TimeSpan>? s_timeSpanConverter;

        /// <summary>
        /// Returns a <see cref="JsonConverterC{T}"/> instance that converts <see cref="ushort"/> values.
        /// </summary>
        [CLSCompliant(false)]
        public static JsonConverterS<ushort> UInt16Converter => s_uint16Converter ??= new UInt16Converter();
        private static JsonConverterS<ushort>? s_uint16Converter;

        /// <summary>
        /// Returns a <see cref="JsonConverterC{T}"/> instance that converts <see cref="uint"/> values.
        /// </summary>
        [CLSCompliant(false)]
        public static JsonConverterS<uint> UInt32Converter => s_uint32Converter ??= new UInt32Converter();
        private static JsonConverterS<uint>? s_uint32Converter;

        /// <summary>
        /// Returns a <see cref="JsonConverterC{T}"/> instance that converts <see cref="ulong"/> values.
        /// </summary>
        [CLSCompliant(false)]
        public static JsonConverterS<ulong> UInt64Converter => s_uint64Converter ??= new UInt64Converter();
        private static JsonConverterS<ulong>? s_uint64Converter;

        /// <summary>
        /// Returns a <see cref="JsonConverterC{T}"/> instance that converts <see cref="Uri"/> values.
        /// </summary>
        public static JsonConverterC<Uri> UriConverter => s_uriConverter ??= new UriConverter();
        private static JsonConverterC<Uri>? s_uriConverter;

        /// <summary>
        /// Returns a <see cref="JsonConverterC{T}"/> instance that converts <see cref="Version"/> values.
        /// </summary>
        public static JsonConverterC<Version> VersionConverter => s_versionConverter ??= new VersionConverter();
        private static JsonConverterC<Version>? s_versionConverter;

        /// <summary>
        /// Creates a <see cref="JsonConverterC{T}"/> instance that throws <see cref="NotSupportedException"/>.
        /// </summary>
        /// <typeparam name="T">The generic definition for the type.</typeparam>
        /// <returns>A <see cref="JsonConverterC{T}"/> instance that throws <see cref="NotSupportedException"/></returns>
        public static JsonConverterC<T> GetUnsupportedTypeConverterC<T>() where T : class
            => new UnsupportedTypeConverterC<T>();
        
        /// <summary>
        /// Creates a <see cref="JsonConverterC{T}"/> instance that throws <see cref="NotSupportedException"/>.
        /// </summary>
        /// <typeparam name="T">The generic definition for the type.</typeparam>
        /// <returns>A <see cref="JsonConverterC{T}"/> instance that throws <see cref="NotSupportedException"/></returns>
        public static JsonConverterS<T> GetUnsupportedTypeConverterS<T>() where T : struct
            => new UnsupportedTypeConverterS<T>();

        /// <summary>
        /// Creates a <see cref="JsonConverterC{T}"/> instance that converts <typeparamref name="T"/> values.
        /// </summary>
        /// <typeparam name="T">The generic definition for the enum type.</typeparam>
        /// <param name="options">The <see cref="JsonSerializerOptions"/> to use for serialization and deserialization.</param>
        /// <returns>A <see cref="JsonConverterC{T}"/> instance that converts <typeparamref name="T"/> values.</returns>
        public static JsonConverterS<T> GetEnumConverter<T>(JsonSerializerOptions options) where T : struct, Enum
            => new EnumConverter<T>(EnumConverterOptions.AllowNumbers, options ?? throw new ArgumentNullException(nameof(options)));

        /// <summary>
        /// Creates a <see cref="JsonConverterC{T}"/> instance that converts <typeparamref name="T?"/> values.
        /// </summary>
        /// <typeparam name="T">The generic definition for the underlying nullable type.</typeparam>
        /// <param name="underlyingTypeInfo">Serialization metadata for the underlying nullable type.</param>
        /// <returns>A <see cref="JsonConverterC{T}"/> instance that converts <typeparamref name="T?"/> values</returns>
        public static JsonConverterS<T> GetNullableConverter<T>(JsonTypeInfoS<T> underlyingTypeInfo) where T : struct
        {
            if (underlyingTypeInfo == null)
            {
                throw new ArgumentNullException(nameof(underlyingTypeInfo));
            }

            JsonConverterS<T>? underlyingConverter = underlyingTypeInfo.PropertyInfoForTypeInfo?.ConverterBase as JsonConverterS<T>;
            if (underlyingConverter == null)
            {
                throw new InvalidOperationException(SR.Format(SR.SerializationConverterNotCompatible, underlyingConverter, typeof(T)));
            }

            return new NullableConverter<T>(underlyingConverter);
        }
    }
}
