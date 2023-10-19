// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#nullable enable

using System.ComponentModel;
using System.Diagnostics;

namespace System.Text.Json.Serialization.Metadata
{
    /// <summary>
    /// Provides JSON serialization-related metadata about a type.
    /// </summary>
    /// <typeparam name="T">The generic definition of the type.</typeparam>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract class JsonTypeInfoC<T> : JsonTypeInfo where T : class
    {
        private Action<Utf8JsonWriter, T>? _serialize;

        internal JsonTypeInfoC(Type type, JsonSerializerOptions options) :
            base(type, options, dummy: false)
        { }

        internal JsonTypeInfoC()
        {
            Debug.Assert(false, "This constructor should not be called.");
        }

        /// <summary>
        /// Serializes an instance of <typeparamref name="T"/> using
        /// <see cref="JsonSourceGenerationOptionsAttribute"/> values specified at design time.
        /// </summary>
        /// <remarks>The writer is not flushed after writing.</remarks>
        public Action<Utf8JsonWriter, T>? SerializeHandler
        {
            get
            {
                return _serialize;
            }
            private protected set
            {
                _serialize = value;
                HasSerialize = value != null;
            }
        }
    }
}
