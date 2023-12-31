// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#nullable enable

namespace System.Text.Json.Serialization
{
    /// <summary>
    /// Base class for non-enumerable, non-primitive objects where public properties
    /// are (de)serialized as a JSON object.
    /// </summary>
    internal abstract class JsonObjectConverterS<T> : JsonResumableConverterS<T> where T : struct
    {
        internal sealed override ConverterStrategy ConverterStrategy => ConverterStrategy.Object;
        internal sealed override Type? ElementType => null;
    }
}
