// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#nullable enable

using System.Text.Json.Serialization.Converters;

namespace System.Text.Json.Serialization.Metadata
{
    /// <summary>
    /// Creates and initializes serialization metadata for a type.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal sealed class JsonTypeInfoInternalC<T> : JsonTypeInfoC<T> where T : class
    {
        /// <summary>
        /// Creates serialization metadata for a type using a simple converter.
        /// </summary>
        public JsonTypeInfoInternalC(JsonSerializerOptions options)
            : base(typeof(T), options)
        {
        }

        /// <summary>
        /// Creates serialization metadata for an object.
        /// </summary>
        public JsonTypeInfoInternalC(JsonSerializerOptions options, JsonObjectInfoValuesC<T> objectInfo) : base(typeof(T), options)
        {
#pragma warning disable CS8714
            // The type cannot be used as type parameter in the generic type or method.
            // Nullability of type argument doesn't match 'notnull' constraint.
            JsonConverter converter;

            if (objectInfo.ObjectWithParameterizedConstructorCreator != null)
            {
                converter = new JsonMetadataServicesConverterC<T>(
                    () => new LargeObjectWithParameterizedConstructorConverterC<T>(),
                    ConverterStrategy.Object);
                CreateObjectWithArgs = objectInfo.ObjectWithParameterizedConstructorCreator;
                CtorParamInitFunc = objectInfo.ConstructorParameterMetadataInitializer;
            }
            else
            {
                converter = new JsonMetadataServicesConverterC<T>(() => new ObjectDefaultConverterC<T>(), ConverterStrategy.Object);
                SetCreateObjectFunc(objectInfo.ObjectCreator);
            }
#pragma warning restore CS8714

            PropInitFunc = objectInfo.PropertyMetadataInitializer;
            SerializeHandler = objectInfo.SerializeHandler;
            PropertyInfoForTypeInfo = JsonMetadataServices.CreateJsonPropertyInfoForClassInfo(typeof(T), this, converter, Options);
            NumberHandling = objectInfo.NumberHandling;
        }

        /// <summary>
        /// Creates serialization metadata for a collection.
        /// </summary>
        public JsonTypeInfoInternalC(
            JsonSerializerOptions options,
            JsonCollectionInfoValues<T> collectionInfo,
            Func<JsonConverterC<T>> converterCreator,
            object? createObjectWithArgs = null,
            object? addFunc = null)
            : base(typeof(T), options)
        {
            if (collectionInfo == null)
            {
                throw new ArgumentNullException(nameof(collectionInfo));
            }

            ConverterStrategy strategy = collectionInfo.KeyInfo == null ? ConverterStrategy.Enumerable : ConverterStrategy.Dictionary;
            JsonConverterC<T> converter = new JsonMetadataServicesConverterC<T>(converterCreator, strategy);

            KeyType = converter.KeyType;
            ElementType = converter.ElementType;
            KeyTypeInfo = collectionInfo.KeyInfo;
            ElementTypeInfo = collectionInfo.ElementInfo ?? throw new ArgumentNullException(nameof(collectionInfo.ElementInfo));
            NumberHandling = collectionInfo.NumberHandling;
            PropertyInfoForTypeInfo = JsonMetadataServices.CreateJsonPropertyInfoForClassInfo(typeof(T), this, converter, options);
            SerializeHandler = collectionInfo.SerializeHandler;
            CreateObjectWithArgs = createObjectWithArgs;
            AddMethodDelegate = addFunc;
            SetCreateObjectFunc(collectionInfo.ObjectCreator);
        }

        private void SetCreateObjectFunc(Func<T>? createObjectFunc)
        {
            if (createObjectFunc != null)
            {
                CreateObject = () => createObjectFunc();
            }
        }
    }
}
