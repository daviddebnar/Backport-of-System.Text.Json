// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#nullable enable

using System.Collections.Concurrent;
using System.Collections.Generic;

namespace System.Text.Json.Serialization.Converters
{
    internal sealed class ConcurrentStackOfTConverter<TCollection, TElement>
        : IEnumerableDefaultConverterC<TCollection, TElement>
        where TCollection : ConcurrentStack<TElement>
        where TElement : class
    {
        protected override void Add(in TElement value, ref ReadStack state)
        {
            ((TCollection)state.Current.ReturnValue!).Push(value);
        }

        protected override void CreateCollection(ref Utf8JsonReader reader, ref ReadStack state, JsonSerializerOptions options)
        {
            if (state.Current.JsonTypeInfo.CreateObject == null)
            {
                ThrowHelper.ThrowNotSupportedException_SerializationNotSupported(state.Current.JsonTypeInfo.Type);
            }

            state.Current.ReturnValue = state.Current.JsonTypeInfo.CreateObject();
        }
    }
}
