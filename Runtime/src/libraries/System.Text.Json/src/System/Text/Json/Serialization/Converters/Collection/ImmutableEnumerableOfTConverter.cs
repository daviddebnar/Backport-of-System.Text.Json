// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#nullable enable

using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json.Serialization.Metadata;

namespace System.Text.Json.Serialization.Converters
{
    internal class ImmutableEnumerableOfTConverter<TCollection, TElement>
        : IEnumerableDefaultConverterC<TCollection, TElement>
        where TCollection : class, IEnumerable<TElement>
        where TElement : class
    {
        protected sealed override void Add(in TElement value, ref ReadStack state)
        {
            ((List<TElement>)state.Current.ReturnValue!).Add(value);
        }

        internal sealed override bool CanHaveIdMetadata => false;

        protected sealed override void CreateCollection(ref Utf8JsonReader reader, ref ReadStack state, JsonSerializerOptions options)
        {
            state.Current.ReturnValue = new List<TElement>();
        }

        protected sealed override void ConvertCollection(ref ReadStack state, JsonSerializerOptions options)
        {
            JsonTypeInfo typeInfo = state.Current.JsonTypeInfo;

            Func<IEnumerable<TElement>, TCollection>? creator = (Func<IEnumerable<TElement>, TCollection>?)typeInfo.CreateObjectWithArgs;
            Debug.Assert(creator != null);
            state.Current.ReturnValue = creator((List<TElement>)state.Current.ReturnValue!);
        }
    }
}
