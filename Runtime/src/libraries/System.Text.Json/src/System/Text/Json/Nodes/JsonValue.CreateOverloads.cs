// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#nullable enable

using System.Text.Json.Serialization.Metadata;

namespace System.Text.Json.Nodes
{
    public partial class JsonValue
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="JsonValue"/> class that contains the specified value.
        /// </summary>
        /// <param name="value">The underlying value of the new <see cref="JsonValue"/> instance.</param>
        /// <param name="options">Options to control the behavior.</param>
        /// <returns>The new instance of the <see cref="JsonValue"/> class that contains the specified value.</returns>
        public static JsonValue Create(bool value, JsonNodeOptions? options = null) => new JsonValueTrimmableS<bool>(value, JsonMetadataServices.BooleanConverter);

        /// <summary>
        ///   Initializes a new instance of the <see cref="JsonValue"/> class that contains the specified value.
        /// </summary>
        /// <param name="value">The underlying value of the new <see cref="JsonValue"/> instance.</param>
        /// <param name="options">Options to control the behavior.</param>
        /// <returns>The new instance of the <see cref="JsonValue"/> class that contains the specified value.</returns>
        public static JsonValue? Create(bool? value, JsonNodeOptions? options = null) => value.HasValue ? new JsonValueTrimmableS<bool>(value.Value, JsonMetadataServices.BooleanConverter) : null;

        /// <summary>
        ///   Initializes a new instance of the <see cref="JsonValue"/> class that contains the specified value.
        /// </summary>
        /// <param name="value">The underlying value of the new <see cref="JsonValue"/> instance.</param>
        /// <param name="options">Options to control the behavior.</param>
        /// <returns>The new instance of the <see cref="JsonValue"/> class that contains the specified value.</returns>
        public static JsonValue Create(byte value, JsonNodeOptions? options = null) => new JsonValueTrimmableS<byte>(value, JsonMetadataServices.ByteConverter);

        /// <summary>
        ///   Initializes a new instance of the <see cref="JsonValue"/> class that contains the specified value.
        /// </summary>
        /// <param name="value">The underlying value of the new <see cref="JsonValue"/> instance.</param>
        /// <param name="options">Options to control the behavior.</param>
        /// <returns>The new instance of the <see cref="JsonValue"/> class that contains the specified value.</returns>
        public static JsonValue? Create(byte? value, JsonNodeOptions? options = null) => value.HasValue ? new JsonValueTrimmableS<byte>(value.Value, JsonMetadataServices.ByteConverter) : null;

        /// <summary>
        ///   Initializes a new instance of the <see cref="JsonValue"/> class that contains the specified value.
        /// </summary>
        /// <param name="value">The underlying value of the new <see cref="JsonValue"/> instance.</param>
        /// <param name="options">Options to control the behavior.</param>
        /// <returns>The new instance of the <see cref="JsonValue"/> class that contains the specified value.</returns>
        public static JsonValue Create(char value, JsonNodeOptions? options = null) => new JsonValueTrimmableS<char>(value, JsonMetadataServices.CharConverter);

        /// <summary>
        ///   Initializes a new instance of the <see cref="JsonValue"/> class that contains the specified value.
        /// </summary>
        /// <param name="value">The underlying value of the new <see cref="JsonValue"/> instance.</param>
        /// <param name="options">Options to control the behavior.</param>
        /// <returns>The new instance of the <see cref="JsonValue"/> class that contains the specified value.</returns>
        public static JsonValue? Create(char? value, JsonNodeOptions? options = null) => value.HasValue ? new JsonValueTrimmableS<char>(value.Value, JsonMetadataServices.CharConverter) : null;

        /// <summary>
        ///   Initializes a new instance of the <see cref="JsonValue"/> class that contains the specified value.
        /// </summary>
        /// <param name="value">The underlying value of the new <see cref="JsonValue"/> instance.</param>
        /// <param name="options">Options to control the behavior.</param>
        /// <returns>The new instance of the <see cref="JsonValue"/> class that contains the specified value.</returns>
        public static JsonValue Create(DateTime value, JsonNodeOptions? options = null) => new JsonValueTrimmableS<DateTime>(value, JsonMetadataServices.DateTimeConverter);

        /// <summary>
        ///   Initializes a new instance of the <see cref="JsonValue"/> class that contains the specified value.
        /// </summary>
        /// <param name="value">The underlying value of the new <see cref="JsonValue"/> instance.</param>
        /// <param name="options">Options to control the behavior.</param>
        /// <returns>The new instance of the <see cref="JsonValue"/> class that contains the specified value.</returns>
        public static JsonValue? Create(DateTime? value, JsonNodeOptions? options = null) => value.HasValue ? new JsonValueTrimmableS<DateTime>(value.Value, JsonMetadataServices.DateTimeConverter) : null;

        /// <summary>
        ///   Initializes a new instance of the <see cref="JsonValue"/> class that contains the specified value.
        /// </summary>
        /// <param name="value">The underlying value of the new <see cref="JsonValue"/> instance.</param>
        /// <param name="options">Options to control the behavior.</param>
        /// <returns>The new instance of the <see cref="JsonValue"/> class that contains the specified value.</returns>
        public static JsonValue Create(DateTimeOffset value, JsonNodeOptions? options = null) => new JsonValueTrimmableS<DateTimeOffset>(value, JsonMetadataServices.DateTimeOffsetConverter);

        /// <summary>
        ///   Initializes a new instance of the <see cref="JsonValue"/> class that contains the specified value.
        /// </summary>
        /// <param name="value">The underlying value of the new <see cref="JsonValue"/> instance.</param>
        /// <param name="options">Options to control the behavior.</param>
        /// <returns>The new instance of the <see cref="JsonValue"/> class that contains the specified value.</returns>
        public static JsonValue? Create(DateTimeOffset? value, JsonNodeOptions? options = null) => value.HasValue ? new JsonValueTrimmableS<DateTimeOffset>(value.Value, JsonMetadataServices.DateTimeOffsetConverter) : null;

        /// <summary>
        ///   Initializes a new instance of the <see cref="JsonValue"/> class that contains the specified value.
        /// </summary>
        /// <param name="value">The underlying value of the new <see cref="JsonValue"/> instance.</param>
        /// <param name="options">Options to control the behavior.</param>
        /// <returns>The new instance of the <see cref="JsonValue"/> class that contains the specified value.</returns>
        public static JsonValue Create(decimal value, JsonNodeOptions? options = null) => new JsonValueTrimmableS<decimal>(value, JsonMetadataServices.DecimalConverter);

        /// <summary>
        ///   Initializes a new instance of the <see cref="JsonValue"/> class that contains the specified value.
        /// </summary>
        /// <param name="value">The underlying value of the new <see cref="JsonValue"/> instance.</param>
        /// <param name="options">Options to control the behavior.</param>
        /// <returns>The new instance of the <see cref="JsonValue"/> class that contains the specified value.</returns>
        public static JsonValue? Create(decimal? value, JsonNodeOptions? options = null) => value.HasValue ? new JsonValueTrimmableS<decimal>(value.Value, JsonMetadataServices.DecimalConverter) : null;

        /// <summary>
        ///   Initializes a new instance of the <see cref="JsonValue"/> class that contains the specified value.
        /// </summary>
        /// <param name="value">The underlying value of the new <see cref="JsonValue"/> instance.</param>
        /// <param name="options">Options to control the behavior.</param>
        /// <returns>The new instance of the <see cref="JsonValue"/> class that contains the specified value.</returns>
        public static JsonValue Create(double value, JsonNodeOptions? options = null) => new JsonValueTrimmableS<double>(value, JsonMetadataServices.DoubleConverter);

        /// <summary>
        ///   Initializes a new instance of the <see cref="JsonValue"/> class that contains the specified value.
        /// </summary>
        /// <param name="value">The underlying value of the new <see cref="JsonValue"/> instance.</param>
        /// <param name="options">Options to control the behavior.</param>
        /// <returns>The new instance of the <see cref="JsonValue"/> class that contains the specified value.</returns>
        public static JsonValue? Create(double? value, JsonNodeOptions? options = null) => value.HasValue ? new JsonValueTrimmableS<double>(value.Value, JsonMetadataServices.DoubleConverter) : null;

        /// <summary>
        ///   Initializes a new instance of the <see cref="JsonValue"/> class that contains the specified value.
        /// </summary>
        /// <param name="value">The underlying value of the new <see cref="JsonValue"/> instance.</param>
        /// <param name="options">Options to control the behavior.</param>
        /// <returns>The new instance of the <see cref="JsonValue"/> class that contains the specified value.</returns>
        public static JsonValue Create(Guid value, JsonNodeOptions? options = null) => new JsonValueTrimmableS<Guid>(value, JsonMetadataServices.GuidConverter);

        /// <summary>
        ///   Initializes a new instance of the <see cref="JsonValue"/> class that contains the specified value.
        /// </summary>
        /// <param name="value">The underlying value of the new <see cref="JsonValue"/> instance.</param>
        /// <param name="options">Options to control the behavior.</param>
        /// <returns>The new instance of the <see cref="JsonValue"/> class that contains the specified value.</returns>
        public static JsonValue? Create(Guid? value, JsonNodeOptions? options = null) => value.HasValue ? new JsonValueTrimmableS<Guid>(value.Value, JsonMetadataServices.GuidConverter) : null;

        /// <summary>
        ///   Initializes a new instance of the <see cref="JsonValue"/> class that contains the specified value.
        /// </summary>
        /// <param name="value">The underlying value of the new <see cref="JsonValue"/> instance.</param>
        /// <param name="options">Options to control the behavior.</param>
        /// <returns>The new instance of the <see cref="JsonValue"/> class that contains the specified value.</returns>
        public static JsonValue Create(short value, JsonNodeOptions? options = null) => new JsonValueTrimmableS<short>(value, JsonMetadataServices.Int16Converter);

        /// <summary>
        ///   Initializes a new instance of the <see cref="JsonValue"/> class that contains the specified value.
        /// </summary>
        /// <param name="value">The underlying value of the new <see cref="JsonValue"/> instance.</param>
        /// <param name="options">Options to control the behavior.</param>
        /// <returns>The new instance of the <see cref="JsonValue"/> class that contains the specified value.</returns>
        public static JsonValue? Create(short? value, JsonNodeOptions? options = null) => value.HasValue ? new JsonValueTrimmableS<short>(value.Value, JsonMetadataServices.Int16Converter) : null;

        /// <summary>
        ///   Initializes a new instance of the <see cref="JsonValue"/> class that contains the specified value.
        /// </summary>
        /// <param name="value">The underlying value of the new <see cref="JsonValue"/> instance.</param>
        /// <param name="options">Options to control the behavior.</param>
        /// <returns>The new instance of the <see cref="JsonValue"/> class that contains the specified value.</returns>
        public static JsonValue Create(int value, JsonNodeOptions? options = null) => new JsonValueTrimmableS<int>(value, JsonMetadataServices.Int32Converter);

        /// <summary>
        ///   Initializes a new instance of the <see cref="JsonValue"/> class that contains the specified value.
        /// </summary>
        /// <param name="value">The underlying value of the new <see cref="JsonValue"/> instance.</param>
        /// <param name="options">Options to control the behavior.</param>
        /// <returns>The new instance of the <see cref="JsonValue"/> class that contains the specified value.</returns>
        public static JsonValue? Create(int? value, JsonNodeOptions? options = null) => value.HasValue ? new JsonValueTrimmableS<int>(value.Value, JsonMetadataServices.Int32Converter) : null;

        /// <summary>
        ///   Initializes a new instance of the <see cref="JsonValue"/> class that contains the specified value.
        /// </summary>
        /// <param name="value">The underlying value of the new <see cref="JsonValue"/> instance.</param>
        /// <param name="options">Options to control the behavior.</param>
        /// <returns>The new instance of the <see cref="JsonValue"/> class that contains the specified value.</returns>
        public static JsonValue Create(long value, JsonNodeOptions? options = null) => new JsonValueTrimmableS<long>(value, JsonMetadataServices.Int64Converter);

        /// <summary>
        ///   Initializes a new instance of the <see cref="JsonValue"/> class that contains the specified value.
        /// </summary>
        /// <param name="value">The underlying value of the new <see cref="JsonValue"/> instance.</param>
        /// <param name="options">Options to control the behavior.</param>
        /// <returns>The new instance of the <see cref="JsonValue"/> class that contains the specified value.</returns>
        public static JsonValue? Create(long? value, JsonNodeOptions? options = null) => value.HasValue ? new JsonValueTrimmableS<long>(value.Value, JsonMetadataServices.Int64Converter) : null;

        /// <summary>
        ///   Initializes a new instance of the <see cref="JsonValue"/> class that contains the specified value.
        /// </summary>
        /// <param name="value">The underlying value of the new <see cref="JsonValue"/> instance.</param>
        /// <param name="options">Options to control the behavior.</param>
        /// <returns>The new instance of the <see cref="JsonValue"/> class that contains the specified value.</returns>
        [CLSCompliantAttribute(false)]
        public static JsonValue Create(sbyte value, JsonNodeOptions? options = null) => new JsonValueTrimmableS<sbyte>(value, JsonMetadataServices.SByteConverter);

        /// <summary>
        ///   Initializes a new instance of the <see cref="JsonValue"/> class that contains the specified value.
        /// </summary>
        /// <param name="value">The underlying value of the new <see cref="JsonValue"/> instance.</param>
        /// <param name="options">Options to control the behavior.</param>
        /// <returns>The new instance of the <see cref="JsonValue"/> class that contains the specified value.</returns>
        [CLSCompliantAttribute(false)]
        public static JsonValue? Create(sbyte? value, JsonNodeOptions? options = null) => value.HasValue ? new JsonValueTrimmableS<sbyte>(value.Value, JsonMetadataServices.SByteConverter) : null;

        /// <summary>
        ///   Initializes a new instance of the <see cref="JsonValue"/> class that contains the specified value.
        /// </summary>
        /// <param name="value">The underlying value of the new <see cref="JsonValue"/> instance.</param>
        /// <param name="options">Options to control the behavior.</param>
        /// <returns>The new instance of the <see cref="JsonValue"/> class that contains the specified value.</returns>
        public static JsonValue Create(float value, JsonNodeOptions? options = null) => new JsonValueTrimmableS<float>(value, JsonMetadataServices.SingleConverter);

        /// <summary>
        ///   Initializes a new instance of the <see cref="JsonValue"/> class that contains the specified value.
        /// </summary>
        /// <param name="value">The underlying value of the new <see cref="JsonValue"/> instance.</param>
        /// <param name="options">Options to control the behavior.</param>
        /// <returns>The new instance of the <see cref="JsonValue"/> class that contains the specified value.</returns>
        public static JsonValue? Create(float? value, JsonNodeOptions? options = null) => value.HasValue ? new JsonValueTrimmableS<float>(value.Value, JsonMetadataServices.SingleConverter) : null;

        /// <summary>
        ///   Initializes a new instance of the <see cref="JsonValue"/> class that contains the specified value.
        /// </summary>
        /// <param name="value">The underlying value of the new <see cref="JsonValue"/> instance.</param>
        /// <param name="options">Options to control the behavior.</param>
        /// <returns>The new instance of the <see cref="JsonValue"/> class that contains the specified value.</returns>
        public static JsonValue? Create(string? value, JsonNodeOptions? options = null) => value != null ? new JsonValueTrimmableC<string>(value, JsonMetadataServices.StringConverter) : null;

        /// <summary>
        ///   Initializes a new instance of the <see cref="JsonValue"/> class that contains the specified value.
        /// </summary>
        /// <param name="value">The underlying value of the new <see cref="JsonValue"/> instance.</param>
        /// <param name="options">Options to control the behavior.</param>
        /// <returns>The new instance of the <see cref="JsonValue"/> class that contains the specified value.</returns>
        [CLSCompliantAttribute(false)]
        public static JsonValue Create(ushort value, JsonNodeOptions? options = null) => new JsonValueTrimmableS<ushort>(value, JsonMetadataServices.UInt16Converter);

        /// <summary>
        ///   Initializes a new instance of the <see cref="JsonValue"/> class that contains the specified value.
        /// </summary>
        /// <param name="value">The underlying value of the new <see cref="JsonValue"/> instance.</param>
        /// <param name="options">Options to control the behavior.</param>
        /// <returns>The new instance of the <see cref="JsonValue"/> class that contains the specified value.</returns>
        [CLSCompliantAttribute(false)]
        public static JsonValue? Create(ushort? value, JsonNodeOptions? options = null) => value.HasValue ? new JsonValueTrimmableS<ushort>(value.Value, JsonMetadataServices.UInt16Converter) : null;

        /// <summary>
        ///   Initializes a new instance of the <see cref="JsonValue"/> class that contains the specified value.
        /// </summary>
        /// <param name="value">The underlying value of the new <see cref="JsonValue"/> instance.</param>
        /// <param name="options">Options to control the behavior.</param>
        /// <returns>The new instance of the <see cref="JsonValue"/> class that contains the specified value.</returns>
        [CLSCompliantAttribute(false)]
        public static JsonValue Create(uint value, JsonNodeOptions? options = null) => new JsonValueTrimmableS<uint>(value, JsonMetadataServices.UInt32Converter);

        /// <summary>
        ///   Initializes a new instance of the <see cref="JsonValue"/> class that contains the specified value.
        /// </summary>
        /// <param name="value">The underlying value of the new <see cref="JsonValue"/> instance.</param>
        /// <param name="options">Options to control the behavior.</param>
        /// <returns>The new instance of the <see cref="JsonValue"/> class that contains the specified value.</returns>
        [CLSCompliantAttribute(false)]
        public static JsonValue? Create(uint? value, JsonNodeOptions? options = null) => value.HasValue ? new JsonValueTrimmableS<uint>(value.Value, JsonMetadataServices.UInt32Converter) : null;

        /// <summary>
        ///   Initializes a new instance of the <see cref="JsonValue"/> class that contains the specified value.
        /// </summary>
        /// <param name="value">The underlying value of the new <see cref="JsonValue"/> instance.</param>
        /// <param name="options">Options to control the behavior.</param>
        /// <returns>The new instance of the <see cref="JsonValue"/> class that contains the specified value.</returns>
        [CLSCompliantAttribute(false)]
        public static JsonValue Create(ulong value, JsonNodeOptions? options = null) => new JsonValueTrimmableS<ulong>(value, JsonMetadataServices.UInt64Converter);

        /// <summary>
        ///   Initializes a new instance of the <see cref="JsonValue"/> class that contains the specified value.
        /// </summary>
        /// <param name="value">The underlying value of the new <see cref="JsonValue"/> instance.</param>
        /// <param name="options">Options to control the behavior.</param>
        /// <returns>The new instance of the <see cref="JsonValue"/> class that contains the specified value.</returns>
        [CLSCompliantAttribute(false)]
        public static JsonValue? Create(ulong? value, JsonNodeOptions? options = null) => value.HasValue ? new JsonValueTrimmableS<ulong>(value.Value, JsonMetadataServices.UInt64Converter) : null;

        /// <summary>
        ///   Initializes a new instance of the <see cref="JsonValue"/> class that contains the specified value.
        /// </summary>
        /// <param name="value">The underlying value of the new <see cref="JsonValue"/> instance.</param>
        /// <param name="options">Options to control the behavior.</param>
        /// <returns>The new instance of the <see cref="JsonValue"/> class that contains the specified value.</returns>
        public static JsonValue? Create(JsonElement value, JsonNodeOptions? options = null)
        {
            if (value.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            VerifyJsonElementIsNotArrayOrObject(ref value);

            return new JsonValueTrimmableS<JsonElement>(value, JsonMetadataServices.JsonElementConverter);
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="JsonValue"/> class that contains the specified value.
        /// </summary>
        /// <param name="value">The underlying value of the new <see cref="JsonValue"/> instance.</param>
        /// <param name="options">Options to control the behavior.</param>
        /// <returns>The new instance of the <see cref="JsonValue"/> class that contains the specified value.</returns>
        public static JsonValue? Create(JsonElement? value, JsonNodeOptions? options = null)
        {
            if (value == null)
            {
                return null;
            }

            JsonElement element = value.Value;
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            VerifyJsonElementIsNotArrayOrObject(ref element);

            return new JsonValueTrimmableS<JsonElement>(element, JsonMetadataServices.JsonElementConverter);
        }
    }
}
