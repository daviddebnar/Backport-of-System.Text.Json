// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#nullable enable

namespace System.Text.Json.Serialization.Metadata
{
    /// <summary>
    /// Provides serialization metadata about a property or field.
    /// </summary>
    /// <typeparam name="T">The type to convert of the <see cref="JsonConverterC{T}"/> for the property.</typeparam>
    public sealed class JsonPropertyInfoValuesS<T> where T : struct
    {
        /// <summary>
        /// If <see langword="true"/>, indicates that the member is a property, otherwise indicates the member is a field.
        /// </summary>
        public bool IsProperty { get; }

        /// <summary>
        /// Whether the property or field is public.
        /// </summary>
        public bool IsPublic { get; }

        /// <summary>
        /// Whether the property or field is a virtual property.
        /// </summary>
        public bool IsVirtual { get; }

        /// <summary>
        /// The declaring type of the property or field.
        /// </summary>
        public Type DeclaringType { get; } = null!;

        /// <summary>
        /// The <see cref="JsonTypeInfo"/> info for the property or field's type.
        /// </summary>
        public JsonTypeInfo PropertyTypeInfo { get; } = null!;

        /// <summary>
        /// A <see cref="JsonConverter"/> for the property or field, specified by <see cref="JsonConverterAttribute"/>.
        /// </summary>
        public JsonConverterS<T>? Converter { get; }

        /// <summary>
        /// Provides a mechanism to get the property or field's value.
        /// </summary>
        public Func<object, T>? Getter { get; }

        /// <summary>
        /// Provides a mechanism to set the property or field's value.
        /// </summary>
        public Action<object, T>? Setter { get; }

        /// <summary>
        /// Specifies a condition for the member to be ignored.
        /// </summary>
        public JsonIgnoreCondition? IgnoreCondition { get; }

        /// <summary>
        /// Whether the property was annotated with <see cref="JsonIncludeAttribute"/>.
        /// </summary>
        public bool HasJsonInclude { get; }

        /// <summary>
        /// Whether the property was annotated with <see cref="JsonExtensionDataAttribute"/>.
        /// </summary>
        public bool IsExtensionData { get; }

        /// <summary>
        /// If the property or field is a number, specifies how it should processed when serializing and deserializing.
        /// </summary>
        public JsonNumberHandling? NumberHandling { get; }

        /// <summary>
        /// The name of the property or field.
        /// </summary>
        public string PropertyName { get; } = null!;

        /// <summary>
        /// The name to be used when processing the property or field, specified by <see cref="JsonPropertyNameAttribute"/>.
        /// </summary>
        public string? JsonPropertyName { get; }
        
        public JsonPropertyInfoValuesS(
            bool isProperty,
            bool isPublic,
            bool isVirtual,
            Type declaringType,
            JsonTypeInfo propertyTypeInfo,
            JsonConverterS<T>? converter,
            Func<object, T>? getter,
            Action<object, T>? setter,
            JsonIgnoreCondition? ignoreCondition,
            bool hasJsonInclude,
            bool isExtensionData,
            JsonNumberHandling? numberHandling,
            string propertyName,
            string? jsonPropertyName)
        {
            IsProperty = isProperty;
            IsPublic = isPublic;
            IsVirtual = isVirtual;
            DeclaringType = declaringType;
            PropertyTypeInfo = propertyTypeInfo;
            Converter = converter;
            Getter = getter;
            Setter = setter;
            IgnoreCondition = ignoreCondition;
            HasJsonInclude = hasJsonInclude;
            IsExtensionData = isExtensionData;
            NumberHandling = numberHandling;
            PropertyName = propertyName;
            JsonPropertyName = jsonPropertyName;
        }
    }
}
