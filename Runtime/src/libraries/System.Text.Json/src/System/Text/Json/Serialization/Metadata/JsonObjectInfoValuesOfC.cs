// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#nullable enable

namespace System.Text.Json.Serialization.Metadata
{
    /// <summary>
    /// Provides serialization metadata about an object type with constructors, properties, and fields.
    /// </summary>
    /// <typeparam name="T">The object type to serialize or deserialize.</typeparam>
    public sealed class JsonObjectInfoValuesC<T> where T : class
    {
        /// <summary>
        /// Provides a mechanism to create an instance of the class or struct when deserializing, using a parameterless constructor.
        /// </summary>
        public Func<T>? ObjectCreator { get; }

        /// <summary>
        /// Provides a mechanism to create an instance of the class or struct when deserializing, using a parameterized constructor.
        /// </summary>
        public Func<object[], T>? ObjectWithParameterizedConstructorCreator { get; }

        /// <summary>
        /// Provides a mechanism to initialize metadata for properties and fields of the class or struct.
        /// </summary>
        public Func<JsonSerializerContext, JsonPropertyInfo[]>? PropertyMetadataInitializer { get; }

        /// <summary>
        /// Provides a mechanism to initialize metadata for a parameterized constructor of the class or struct to be used when deserializing.
        /// </summary>
        public Func<JsonParameterInfoValues[]>? ConstructorParameterMetadataInitializer { get; }

        /// <summary>
        /// Specifies how number properties and fields should be processed when serializing and deserializing.
        /// </summary>
        public JsonNumberHandling NumberHandling { get; }

        /// <summary>
        /// Provides a serialization implementation for instances of the class or struct which assumes options specified by <see cref="JsonSourceGenerationOptionsAttribute"/>.
        /// </summary>
        public Action<Utf8JsonWriter, T>? SerializeHandler { get; }
        
        public JsonObjectInfoValuesC(
            Func<T>? objectCreator,
            Func<object[], T>? objectWithParameterizedConstructorCreator,
            Func<JsonSerializerContext, JsonPropertyInfo[]>? propertyMetadataInitializer,
            Func<JsonParameterInfoValues[]>? constructorParameterMetadataInitializer,
            JsonNumberHandling numberHandling,
            Action<Utf8JsonWriter, T>? serializeHandler)
        {
            ObjectCreator = objectCreator;
            ObjectWithParameterizedConstructorCreator = objectWithParameterizedConstructorCreator;
            PropertyMetadataInitializer = propertyMetadataInitializer;
            ConstructorParameterMetadataInitializer = constructorParameterMetadataInitializer;
            NumberHandling = numberHandling;
            SerializeHandler = serializeHandler;
        }
    }
}
