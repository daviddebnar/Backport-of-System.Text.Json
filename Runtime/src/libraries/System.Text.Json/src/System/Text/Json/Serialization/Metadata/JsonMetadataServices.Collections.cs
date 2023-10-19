// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text.Json.Serialization.Converters;

namespace System.Text.Json.Serialization.Metadata
{
    public static partial class JsonMetadataServices
    {
        /// <summary>
        /// Creates serialization metadata for an array.
        /// </summary>
        /// <typeparam name="TElement">The generic definition of the element type.</typeparam>
        /// <param name="options">The <see cref="JsonSerializerOptions"/> to use.</param>
        /// <param name="collectionInfo">Provides serialization metadata about the collection type.</param>
        /// <returns>Serialization metadata for the given type.</returns>
        public static JsonTypeInfoC<TElement[]> CreateArrayInfo<TElement>(JsonSerializerOptions options, JsonCollectionInfoValues<TElement[]> collectionInfo)
            where TElement : class
            => new JsonTypeInfoInternalC<TElement[]>(
                options,
                collectionInfo,
                () => new ArrayConverter<TElement[], TElement>());

        /// <summary>
        /// Creates serialization metadata for types assignable to <see cref="List{T}"/>.
        /// </summary>
        /// <typeparam name="TCollection">The generic definition of the type.</typeparam>
        /// <typeparam name="TElement">The generic definition of the element type.</typeparam>
        /// <param name="options">The <see cref="JsonSerializerOptions"/> to use.</param>
        /// <param name="collectionInfo">Provides serialization metadata about the collection type.</param>
        /// <returns>Serialization metadata for the given type.</returns>
        public static JsonTypeInfoC<TCollection> CreateListInfo<TCollection, TElement>(
            JsonSerializerOptions options,
            JsonCollectionInfoValues<TCollection> collectionInfo)
            where TCollection : List<TElement>
            where TElement : class
            => new JsonTypeInfoInternalC<TCollection>(
                options,
                collectionInfo,
                () => new ListOfTConverter<TCollection, TElement>());

        /// <summary>
        /// Creates serialization metadata for types assignable to <see cref="Dictionary{TKey, TValue}"/>.
        /// </summary>
        /// <typeparam name="TCollection">The generic definition of the type.</typeparam>
        /// <typeparam name="TKey">The generic definition of the key type.</typeparam>
        /// <typeparam name="TValue">The generic definition of the value type.</typeparam>
        /// <param name="options"></param>
        /// <param name="collectionInfo">Provides serialization metadata about the collection type.</param>
        /// <returns>Serialization metadata for the given type.</returns>
        public static JsonTypeInfoC<TCollection> CreateDictionaryInfo<TCollection, TKey, TValue>(
            JsonSerializerOptions options,
            JsonCollectionInfoValues<TCollection> collectionInfo)
            where TCollection : Dictionary<TKey, TValue>
            where TKey : class
            where TValue : class
            => new JsonTypeInfoInternalC<TCollection>(
                options,
                collectionInfo,
                () => new DictionaryOfTKeyTValueConverter<TCollection, TKey, TValue>());


#pragma warning disable CS1574 // XML comment has cref attribute that could not be resolved
        /// <summary>
        /// Creates serialization metadata for <see cref="System.Collections.Immutable.ImmutableDictionary{TKey, TValue}"/> and
        /// types assignable to <see cref="System.Collections.Immutable.IImmutableDictionary{TKey, TValue}"/>.
        /// </summary>
        /// <typeparam name="TCollection">The generic definition of the type.</typeparam>
        /// <typeparam name="TKey">The generic definition of the key type.</typeparam>
        /// <typeparam name="TValue">The generic definition of the value type.</typeparam>
        /// <param name="options"></param>
        /// <param name="collectionInfo">Provides serialization metadata about the collection type.</param>
        /// <param name="createRangeFunc">A method to create an immutable dictionary instance.</param>
        /// <returns>Serialization metadata for the given type.</returns>
#pragma warning restore CS1574 // XML comment has cref attribute that could not be resolved
        public static JsonTypeInfoC<TCollection> CreateImmutableDictionaryInfo<TCollection, TKey, TValue>(
            JsonSerializerOptions options,
            JsonCollectionInfoValues<TCollection> collectionInfo,
            Func<IEnumerable<KeyValuePair<TKey, TValue>>, TCollection> createRangeFunc)
            where TCollection : class, IReadOnlyDictionary<TKey, TValue>
            where TKey : class
            where TValue : class
            => new JsonTypeInfoInternalC<TCollection>(
                options,
                collectionInfo,
                () => new ImmutableDictionaryOfTKeyTValueConverter<TCollection, TKey, TValue>(),
                createObjectWithArgs: createRangeFunc ?? throw new ArgumentNullException(nameof(createRangeFunc)));

        /// <summary>
        /// Creates serialization metadata for types assignable to <see cref="IDictionary{TKey, TValue}"/>.
        /// </summary>
        /// <typeparam name="TCollection">The generic definition of the type.</typeparam>
        /// <typeparam name="TKey">The generic definition of the key type.</typeparam>
        /// <typeparam name="TValue">The generic definition of the value type.</typeparam>
        /// <param name="options"></param>
        /// <param name="collectionInfo">Provides serialization metadata about the collection type.</param>
        /// <returns>Serialization metadata for the given type.</returns>
        public static JsonTypeInfoC<TCollection> CreateIDictionaryInfo<TCollection, TKey, TValue>(
            JsonSerializerOptions options,
            JsonCollectionInfoValues<TCollection> collectionInfo)
            where TCollection : class, IDictionary<TKey, TValue>
            where TKey : class
            where TValue : class
            => new JsonTypeInfoInternalC<TCollection>(
                options,
                collectionInfo,
                () => new IDictionaryOfTKeyTValueConverter<TCollection, TKey, TValue>());

        /// <summary>
        /// Creates serialization metadata for types assignable to <see cref="IReadOnlyDictionary{TKey, TValue}"/>.
        /// </summary>
        /// <typeparam name="TCollection">The generic definition of the type.</typeparam>
        /// <typeparam name="TKey">The generic definition of the key type.</typeparam>
        /// <typeparam name="TValue">The generic definition of the value type.</typeparam>
        /// <param name="options"></param>
        /// <param name="collectionInfo">Provides serialization metadata about the collection type.</param>
        /// <returns>Serialization metadata for the given type.</returns>
        public static JsonTypeInfoC<TCollection> CreateIReadOnlyDictionaryInfo<TCollection, TKey, TValue>(
            JsonSerializerOptions options,
            JsonCollectionInfoValues<TCollection> collectionInfo)
            where TCollection : class, IReadOnlyDictionary<TKey, TValue>
            where TKey : class
            where TValue : class
            => new JsonTypeInfoInternalC<TCollection>(
                options,
                collectionInfo,
                () => new IReadOnlyDictionaryOfTKeyTValueConverter<TCollection, TKey, TValue>());

#pragma warning disable CS1574 // XML comment has cref attribute that could not be resolved
        /// <summary>
        /// Creates serialization metadata for non-dictionary immutable collection types.
        /// </summary>
        /// <typeparam name="TCollection">The generic definition of the type.</typeparam>
        /// <typeparam name="TElement">The generic definition of the element type.</typeparam>
        /// <param name="options"></param>
        /// <param name="collectionInfo">Provides serialization metadata about the collection type.</param>
        /// <param name="createRangeFunc">A method to create an immutable dictionary instance.</param>
        /// <returns>Serialization metadata for the given type.</returns>
#pragma warning restore CS1574 // XML comment has cref attribute that could not be resolved
        public static JsonTypeInfoC<TCollection> CreateImmutableEnumerableInfo<TCollection, TElement>(
            JsonSerializerOptions options,
            JsonCollectionInfoValues<TCollection> collectionInfo,
            Func<IEnumerable<TElement>, TCollection> createRangeFunc)
            where TCollection : class, IEnumerable<TElement>
            where TElement : class
            => new JsonTypeInfoInternalC<TCollection>(
                options,
                collectionInfo,
                () => new ImmutableEnumerableOfTConverter<TCollection, TElement>(),
                createObjectWithArgs: createRangeFunc ?? throw new ArgumentNullException(nameof(createRangeFunc)));

        /// <summary>
        /// Creates serialization metadata for types assignable to <see cref="IList"/>.
        /// </summary>
        /// <typeparam name="TCollection">The generic definition of the type.</typeparam>
        /// <param name="options"></param>
        /// <param name="collectionInfo">Provides serialization metadata about the collection type.</param>
        /// <returns>Serialization metadata for the given type.</returns>
        public static JsonTypeInfoC<TCollection> CreateIListInfo<TCollection>(
            JsonSerializerOptions options,
            JsonCollectionInfoValues<TCollection> collectionInfo)
            where TCollection : class, IList
            => new JsonTypeInfoInternalC<TCollection>(
                options,
                collectionInfo,
                () => new IListConverter<TCollection>());

        /// <summary>
        /// Creates serialization metadata for types assignable to <see cref="IList{T}"/>.
        /// </summary>
        /// <typeparam name="TCollection">The generic definition of the type.</typeparam>
        /// <typeparam name="TElement">The generic definition of the element type.</typeparam>
        /// <param name="options"></param>
        /// <param name="collectionInfo">Provides serialization metadata about the collection type.</param>
        /// <returns>Serialization metadata for the given type.</returns>
        public static JsonTypeInfoC<TCollection> CreateIListInfo<TCollection, TElement>(
            JsonSerializerOptions options,
            JsonCollectionInfoValues<TCollection> collectionInfo)
            where TCollection : class, IList<TElement>
            where TElement : class
            => new JsonTypeInfoInternalC<TCollection>(
                options,
                collectionInfo,
                () => new IListOfTConverter<TCollection, TElement>());

        /// <summary>
        /// Creates serialization metadata for types assignable to <see cref="ISet{T}"/>.
        /// </summary>
        /// <typeparam name="TCollection">The generic definition of the type.</typeparam>
        /// <typeparam name="TElement">The generic definition of the element type.</typeparam>
        /// <param name="options"></param>
        /// <param name="collectionInfo">Provides serialization metadata about the collection type.</param>
        /// <returns>Serialization metadata for the given type.</returns>
        public static JsonTypeInfoC<TCollection> CreateISetInfo<TCollection, TElement>(
            JsonSerializerOptions options,
            JsonCollectionInfoValues<TCollection> collectionInfo)
            where TCollection : class, ISet<TElement>
            where TElement : class
            => new JsonTypeInfoInternalC<TCollection>(
                options,
                collectionInfo,
                () => new ISetOfTConverter<TCollection, TElement>());

        /// <summary>
        /// Creates serialization metadata for types assignable to <see cref="ICollection{T}"/>.
        /// </summary>
        /// <typeparam name="TCollection">The generic definition of the type.</typeparam>
        /// <typeparam name="TElement">The generic definition of the element type.</typeparam>
        /// <param name="options"></param>
        /// <param name="collectionInfo">Provides serialization metadata about the collection type.</param>
        /// <returns>Serialization metadata for the given type.</returns>
        public static JsonTypeInfoC<TCollection> CreateICollectionInfo<TCollection, TElement>(
            JsonSerializerOptions options,
            JsonCollectionInfoValues<TCollection> collectionInfo)
            where TCollection : class, ICollection<TElement>
            where TElement : class
            => new JsonTypeInfoInternalC<TCollection>(
                options,
                collectionInfo,
                () => new ICollectionOfTConverter<TCollection, TElement>());

        /// <summary>
        /// Creates serialization metadata for types assignable to <see cref="Stack{T}"/>.
        /// </summary>
        /// <typeparam name="TCollection">The generic definition of the type.</typeparam>
        /// <typeparam name="TElement">The generic definition of the element type.</typeparam>
        /// <param name="options"></param>
        /// <param name="collectionInfo">Provides serialization metadata about the collection type.</param>
        /// <returns>Serialization metadata for the given type.</returns>
        public static JsonTypeInfoC<TCollection> CreateStackInfo<TCollection, TElement>(
            JsonSerializerOptions options,
            JsonCollectionInfoValues<TCollection> collectionInfo)
            where TCollection : Stack<TElement>
            where TElement : class
            => new JsonTypeInfoInternalC<TCollection>(
                options,
                collectionInfo,
                () => new StackOfTConverter<TCollection, TElement>());

        /// <summary>
        /// Creates serialization metadata for types assignable to <see cref="Queue{T}"/>.
        /// </summary>
        /// <typeparam name="TCollection">The generic definition of the type.</typeparam>
        /// <typeparam name="TElement">The generic definition of the element type.</typeparam>
        /// <param name="options"></param>
        /// <param name="collectionInfo">Provides serialization metadata about the collection type.</param>
        /// <returns>Serialization metadata for the given type.</returns>
        public static JsonTypeInfoC<TCollection> CreateQueueInfo<TCollection, TElement>(
            JsonSerializerOptions options,
            JsonCollectionInfoValues<TCollection> collectionInfo)
            where TCollection : Queue<TElement>
            where TElement : class
            => new JsonTypeInfoInternalC<TCollection>(
                options,
                collectionInfo,
                () => new QueueOfTConverter<TCollection, TElement>());

        /// <summary>
        /// Creates serialization metadata for types assignable to <see cref="ConcurrentStack{T}"/>.
        /// </summary>
        /// <typeparam name="TCollection">The generic definition of the type.</typeparam>
        /// <typeparam name="TElement">The generic definition of the element type.</typeparam>
        /// <param name="options"></param>
        /// <param name="collectionInfo">Provides serialization metadata about the collection type.</param>
        /// <returns>Serialization metadata for the given type.</returns>
        public static JsonTypeInfoC<TCollection> CreateConcurrentStackInfo<TCollection, TElement>(
            JsonSerializerOptions options,
            JsonCollectionInfoValues<TCollection> collectionInfo)
            where TCollection : ConcurrentStack<TElement>
            where TElement : class
            => new JsonTypeInfoInternalC<TCollection>(
                options,
                collectionInfo,
                () => new ConcurrentStackOfTConverter<TCollection, TElement>());

        /// <summary>
        /// Creates serialization metadata for types assignable to <see cref="Queue{T}"/>.
        /// </summary>
        /// <typeparam name="TCollection">The generic definition of the type.</typeparam>
        /// <typeparam name="TElement">The generic definition of the element type.</typeparam>
        /// <param name="options"></param>
        /// <param name="collectionInfo">Provides serialization metadata about the collection type.</param>
        /// <returns>Serialization metadata for the given type.</returns>
        public static JsonTypeInfoC<TCollection> CreateConcurrentQueueInfo<TCollection, TElement>(
            JsonSerializerOptions options,
            JsonCollectionInfoValues<TCollection> collectionInfo)
            where TCollection : ConcurrentQueue<TElement>
            where TElement : class
            => new JsonTypeInfoInternalC<TCollection>(
                options,
                collectionInfo,
                () => new ConcurrentQueueOfTConverter<TCollection, TElement>());

        /// <summary>
        /// Creates serialization metadata for types assignable to <see cref="IEnumerable{T}"/>.
        /// </summary>
        /// <typeparam name="TCollection">The generic definition of the type.</typeparam>
        /// <typeparam name="TElement">The generic definition of the element type.</typeparam>
        /// <param name="options"></param>
        /// <param name="collectionInfo">Provides serialization metadata about the collection type.</param>
        /// <returns>Serialization metadata for the given type.</returns>
        public static JsonTypeInfoC<TCollection> CreateIEnumerableInfo<TCollection, TElement>(
            JsonSerializerOptions options,
            JsonCollectionInfoValues<TCollection> collectionInfo)
            where TCollection : class, IEnumerable<TElement>
            where TElement : class
            => new JsonTypeInfoInternalC<TCollection>(
                options,
                collectionInfo,
                () => new IEnumerableOfTConverter<TCollection, TElement>());

        /// <summary>
        /// Creates serialization metadata for types assignable to <see cref="IDictionary"/>.
        /// </summary>
        /// <typeparam name="TCollection">The generic definition of the type.</typeparam>
        /// <param name="options"></param>
        /// <param name="collectionInfo">Provides serialization metadata about the collection type.</param>
        /// <returns>Serialization metadata for the given type.</returns>
        public static JsonTypeInfoC<TCollection> CreateIDictionaryInfo<TCollection>(
            JsonSerializerOptions options,
            JsonCollectionInfoValues<TCollection> collectionInfo)
            where TCollection : class, IDictionary
            => new JsonTypeInfoInternalC<TCollection>(
                options,
                collectionInfo,
                () => new IDictionaryConverter<TCollection>());

#pragma warning disable CS1574 // XML comment has cref attribute that could not be resolved
        /// <summary>
        /// Creates serialization metadata for <see cref="System.Collections.Stack"/> types.
        /// </summary>
        /// <typeparam name="TCollection">The generic definition of the type.</typeparam>
        /// <param name="options"></param>
        /// <param name="collectionInfo">Provides serialization metadata about the collection type.</param>
        /// <param name="addFunc">A method for adding elements to the collection when using the serializer's code-paths.</param>
        /// <returns>Serialization metadata for the given type.</returns>
#pragma warning restore CS1574 // XML comment has cref attribute that could not be resolved
        public static JsonTypeInfoC<TCollection> CreateStackInfo<TCollection>(
            JsonSerializerOptions options,
            JsonCollectionInfoValues<TCollection> collectionInfo,
            Action<TCollection, object?> addFunc)
            where TCollection : class, IEnumerable
            => CreateStackOrQueueInfo(options, collectionInfo, addFunc);

#pragma warning disable CS1574 // XML comment has cref attribute that could not be resolved
        /// <summary>
        /// Creates serialization metadata for <see cref="System.Collections.Queue"/> types.
        /// </summary>
        /// <typeparam name="TCollection">The generic definition of the type.</typeparam>
        /// <param name="options"></param>
        /// <param name="collectionInfo">Provides serialization metadata about the collection type.</param>
        /// <param name="addFunc">A method for adding elements to the collection when using the serializer's code-paths.</param>
        /// <returns>Serialization metadata for the given type.</returns>
#pragma warning restore CS1574 // XML comment has cref attribute that could not be resolved
        public static JsonTypeInfoC<TCollection> CreateQueueInfo<TCollection>(
            JsonSerializerOptions options,
            JsonCollectionInfoValues<TCollection> collectionInfo,
            Action<TCollection, object?> addFunc)
            where TCollection : class, IEnumerable
            => CreateStackOrQueueInfo(options, collectionInfo, addFunc);

        private static JsonTypeInfoC<TCollection> CreateStackOrQueueInfo<TCollection>(
            JsonSerializerOptions options,
            JsonCollectionInfoValues<TCollection> collectionInfo,
            Action<TCollection, object?> addFunc)
            where TCollection : class, IEnumerable
            => new JsonTypeInfoInternalC<TCollection>(
                options,
                collectionInfo,
                () => new StackOrQueueConverter<TCollection>(),
                createObjectWithArgs: null,
                addFunc: addFunc ?? throw new ArgumentNullException(nameof(addFunc)));

        /// <summary>
        /// Creates serialization metadata for types assignable to <see cref="IList"/>.
        /// </summary>
        /// <typeparam name="TCollection">The generic definition of the type.</typeparam>
        /// <param name="options"></param>
        /// <param name="collectionInfo">Provides serialization metadata about the collection type.</param>
        /// <returns>Serialization metadata for the given type.</returns>
        public static JsonTypeInfoC<TCollection> CreateIEnumerableInfo<TCollection>(
            JsonSerializerOptions options,
            JsonCollectionInfoValues<TCollection> collectionInfo)
            where TCollection : class, IEnumerable
            => new JsonTypeInfoInternalC<TCollection>(
                options,
                collectionInfo,
                () => new IEnumerableConverter<TCollection>());
    }
}
