// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace System.Text.Json.Serialization.Metadata
{
    /// <summary>
    /// Provides information about a constructor parameter required for JSON deserialization.
    /// </summary>
    public sealed class JsonParameterInfoValues
    {
        /// <summary>
        /// The name of the parameter.
        /// </summary>
        public string Name { get; } = null!;

        /// <summary>
        /// The type of the parameter.
        /// </summary>
        public Type ParameterType { get; } = null!;

        /// <summary>
        /// The zero-based position of the parameter in the formal parameter list.
        /// </summary>
        public int Position { get; }

        /// <summary>
        /// Whether a default value was specified for the parameter.
        /// </summary>
        public bool HasDefaultValue { get; }

        /// <summary>
        /// The default value of the parameter.
        /// </summary>
        public object? DefaultValue { get; }
        
        public JsonParameterInfoValues(string name, Type parameterType, int position, bool hasDefaultValue, object? defaultValue)
        {
            Name = name;
            ParameterType = parameterType;
            Position = position;
            HasDefaultValue = hasDefaultValue;
            DefaultValue = defaultValue;
        }
    }
}
