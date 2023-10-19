﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#nullable enable

using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace System.Text.Json.Serialization.Metadata
{
    // Recognizing types emitted by the F# compiler requires consuming APIs from the FSharp.Core runtime library.
    // Every F# application ships with a copy of FSharp.Core, however it is not available statically to System.Text.Json.
    // The following class uses reflection to access the relevant APIs required to detect the various F# types we are looking to support.

    /// <summary>
    /// Proxy class used to access FSharp.Core metadata and reflection APIs that are not statically available to System.Text.Json.
    /// </summary>
    internal sealed class FSharpCoreReflectionProxy
    {
        /// <summary>
        /// The various categories of F# types that System.Text.Json supports.
        /// </summary>
        public enum FSharpKind
        {
            Unrecognized,
            Option,
            ValueOption,
            List,
            Set,
            Map,
            Record,
            Union
        }

        // Binding a struct getter method to a delegate requires that the struct parameter is passed byref.
        public delegate TResult StructGetter<TStruct, TResult>(ref TStruct @this) where TStruct : struct;

        public const string FSharpCoreUnreferencedCodeMessage = "Uses Reflection to access FSharp.Core components at runtime.";

        private static FSharpCoreReflectionProxy? s_singletonInstance;

        // Every type generated by the F# compiler is annotated with the CompilationMappingAttribute
        // containing all relevant metadata required to determine its kind:
        // https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-compilationmappingattribute.html#SourceConstructFlags
        private const string CompilationMappingAttributeTypeName = "Microsoft.FSharp.Core.CompilationMappingAttribute";
        private readonly Type _compilationMappingAttributeType;
        private readonly MethodInfo? _sourceConstructFlagsGetter;

        private readonly Type? _fsharpOptionType;
        private readonly Type? _fsharpValueOptionType;
        private readonly Type? _fsharpListType;
        private readonly Type? _fsharpSetType;
        private readonly Type? _fsharpMapType;

        private readonly MethodInfo? _fsharpListCtor;
        private readonly MethodInfo? _fsharpSetCtor;
        private readonly MethodInfo? _fsharpMapCtor;

        /// <summary>
        /// Checks if the provided System.Type instance is emitted by the F# compiler.
        /// If true, also initializes the proxy singleton for future by other F# types.
        /// </summary>
        [RequiresUnreferencedCode(FSharpCoreUnreferencedCodeMessage)]
        public static bool IsFSharpType(Type type)
        {
            if (s_singletonInstance is null)
            {
                if (GetFSharpCoreAssembly(type) is Assembly fsharpCoreAssembly)
                {
                    // Type is F# type, initialize the singleton instance.
                    s_singletonInstance ??= new FSharpCoreReflectionProxy(fsharpCoreAssembly);

                    return true;
                }

                return false;
            }

            return !(s_singletonInstance.GetFSharpCompilationMappingAttribute(type) is null);
        }

        /// <summary>
        /// Gets the singleton proxy instance; prerequires a successful IsFSharpType call for proxy initialization.
        /// </summary>
        public static FSharpCoreReflectionProxy Instance
        {
            get
            {
                Debug.Assert(!(s_singletonInstance is null), "should be initialized via a successful IsFSharpType call.");
                return s_singletonInstance;
            }
        }

        [RequiresUnreferencedCode(FSharpCoreUnreferencedCodeMessage)]
        private FSharpCoreReflectionProxy(Assembly fsharpCoreAssembly)
        {
            Debug.Assert(fsharpCoreAssembly.GetName().Name == "FSharp.Core");

            Type compilationMappingAttributeType = fsharpCoreAssembly.GetType(CompilationMappingAttributeTypeName)!;
            _sourceConstructFlagsGetter = compilationMappingAttributeType.GetMethod("get_SourceConstructFlags", BindingFlags.Public | BindingFlags.Instance);
            _compilationMappingAttributeType = compilationMappingAttributeType;

            _fsharpOptionType = fsharpCoreAssembly.GetType("Microsoft.FSharp.Core.FSharpOption`1");
            _fsharpValueOptionType = fsharpCoreAssembly.GetType("Microsoft.FSharp.Core.FSharpValueOption`1");
            _fsharpListType = fsharpCoreAssembly.GetType("Microsoft.FSharp.Collections.FSharpList`1");
            _fsharpSetType = fsharpCoreAssembly.GetType("Microsoft.FSharp.Collections.FSharpSet`1");
            _fsharpMapType = fsharpCoreAssembly.GetType("Microsoft.FSharp.Collections.FSharpMap`2");

            _fsharpListCtor = fsharpCoreAssembly.GetType("Microsoft.FSharp.Collections.ListModule")?.GetMethod("OfSeq", BindingFlags.Public | BindingFlags.Static);
            _fsharpSetCtor = fsharpCoreAssembly.GetType("Microsoft.FSharp.Collections.SetModule")?.GetMethod("OfSeq", BindingFlags.Public | BindingFlags.Static);
            _fsharpMapCtor = fsharpCoreAssembly.GetType("Microsoft.FSharp.Collections.MapModule")?.GetMethod("OfSeq", BindingFlags.Public | BindingFlags.Static);
        }

        [RequiresUnreferencedCode(FSharpCoreUnreferencedCodeMessage)]
        public FSharpKind DetectFSharpKind(Type type)
        {
            Attribute? compilationMappingAttribute = GetFSharpCompilationMappingAttribute(type);

            if (compilationMappingAttribute is null)
            {
                return FSharpKind.Unrecognized;
            }

            if (type.IsGenericType)
            {
                Type genericType = type.GetGenericTypeDefinition();
                if (genericType == _fsharpOptionType) return FSharpKind.Option;
                if (genericType == _fsharpValueOptionType) return FSharpKind.ValueOption;
                if (genericType == _fsharpListType) return FSharpKind.List;
                if (genericType == _fsharpSetType) return FSharpKind.Set;
                if (genericType == _fsharpMapType) return FSharpKind.Map;
            }

            return (GetSourceConstructFlags(compilationMappingAttribute) & SourceConstructFlags.KindMask) switch
            {
                SourceConstructFlags.RecordType => FSharpKind.Record,
                SourceConstructFlags.SumType => FSharpKind.Union,
                _ => FSharpKind.Unrecognized
            };
        }

        [RequiresUnreferencedCode(FSharpCoreUnreferencedCodeMessage)]
        public Func<TFSharpOption, T> CreateFSharpOptionValueGetter<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)] TFSharpOption, T>()
        {
            Debug.Assert(typeof(TFSharpOption).GetGenericTypeDefinition() == _fsharpOptionType);
            MethodInfo valueGetter = EnsureMemberExists(typeof(TFSharpOption).GetMethod("get_Value", BindingFlags.Public | BindingFlags.Instance), "Microsoft.FSharp.Core.FSharpOption<T>.get_Value()");
            return CreateDelegate<Func<TFSharpOption, T>>(valueGetter);
        }

        [RequiresUnreferencedCode(FSharpCoreUnreferencedCodeMessage)]
        public Func<TElement?, TFSharpOption> CreateFSharpOptionSomeConstructor<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)] TFSharpOption, TElement>() where TElement : class
        {
            Debug.Assert(typeof(TFSharpOption).GetGenericTypeDefinition() == _fsharpOptionType);
            MethodInfo methodInfo = EnsureMemberExists(typeof(TFSharpOption).GetMethod("Some", BindingFlags.Public | BindingFlags.Static), "Microsoft.FSharp.Core.FSharpOption<T>.Some(T value)");
            return CreateDelegate<Func<TElement?, TFSharpOption>>(methodInfo);
        }

        [RequiresUnreferencedCode(FSharpCoreUnreferencedCodeMessage)]
        public StructGetter<TFSharpValueOption, TElement> CreateFSharpValueOptionValueGetter<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)] TFSharpValueOption, TElement>()
            where TFSharpValueOption : struct
        {
            Debug.Assert(typeof(TFSharpValueOption).GetGenericTypeDefinition() == _fsharpValueOptionType);
            MethodInfo valueGetter = EnsureMemberExists(typeof(TFSharpValueOption).GetMethod("get_Value", BindingFlags.Public | BindingFlags.Instance), "Microsoft.FSharp.Core.FSharpValueOption<T>.get_Value()");
            return CreateDelegate<StructGetter<TFSharpValueOption, TElement>>(valueGetter);
        }

        [RequiresUnreferencedCode(FSharpCoreUnreferencedCodeMessage)]
        public Func<TElement?, TFSharpOption> CreateFSharpValueOptionSomeConstructorC<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)] TFSharpOption, TElement>() where TElement : class
        {
            Debug.Assert(typeof(TFSharpOption).GetGenericTypeDefinition() == _fsharpValueOptionType);
            MethodInfo methodInfo = EnsureMemberExists(typeof(TFSharpOption).GetMethod("Some", BindingFlags.Public | BindingFlags.Static), "Microsoft.FSharp.Core.FSharpValueOption<T>.ValueSome(T value)");
            return CreateDelegate<Func<TElement?, TFSharpOption>>(methodInfo);
        }
        
        [RequiresUnreferencedCode(FSharpCoreUnreferencedCodeMessage)]
        public Func<TElement?, TFSharpOption> CreateFSharpValueOptionSomeConstructorS<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)] TFSharpOption, TElement>() where TElement : struct
        {
            Debug.Assert(typeof(TFSharpOption).GetGenericTypeDefinition() == _fsharpValueOptionType);
            MethodInfo methodInfo = EnsureMemberExists(typeof(TFSharpOption).GetMethod("Some", BindingFlags.Public | BindingFlags.Static), "Microsoft.FSharp.Core.FSharpValueOption<T>.ValueSome(T value)");
            return CreateDelegate<Func<TElement?, TFSharpOption>>(methodInfo);
        }

        [RequiresUnreferencedCode(FSharpCoreUnreferencedCodeMessage)]
        public Func<IEnumerable<TElement>, TFSharpList> CreateFSharpListConstructor<TFSharpList, TElement>()
        {
            Debug.Assert(typeof(TFSharpList).GetGenericTypeDefinition() == _fsharpListType);
            return CreateDelegate<Func<IEnumerable<TElement>, TFSharpList>>(EnsureMemberExists(_fsharpListCtor, "Microsoft.FSharp.Collections.ListModule.OfSeq<T>(IEnumerable<T> source)").MakeGenericMethod(typeof(TElement)));
        }

        [RequiresUnreferencedCode(FSharpCoreUnreferencedCodeMessage)]
        public Func<IEnumerable<TElement>, TFSharpSet> CreateFSharpSetConstructor<TFSharpSet, TElement>()
        {
            Debug.Assert(typeof(TFSharpSet).GetGenericTypeDefinition() == _fsharpSetType);
            return CreateDelegate<Func<IEnumerable<TElement>, TFSharpSet>>(EnsureMemberExists(_fsharpSetCtor, "Microsoft.FSharp.Collections.SetModule.OfSeq<T>(IEnumerable<T> source)").MakeGenericMethod(typeof(TElement)));
        }

        [RequiresUnreferencedCode(FSharpCoreUnreferencedCodeMessage)]
        public Func<IEnumerable<Tuple<TKey, TValue>>, TFSharpMap> CreateFSharpMapConstructor<TFSharpMap, TKey, TValue>()
        {
            Debug.Assert(typeof(TFSharpMap).GetGenericTypeDefinition() == _fsharpMapType);
            return CreateDelegate<Func<IEnumerable<Tuple<TKey, TValue>>, TFSharpMap>>(EnsureMemberExists(_fsharpMapCtor, "Microsoft.FSharp.Collections.MapModule.OfSeq<TKey, TValue>(IEnumerable<Tuple<TKey, TValue>> source)").MakeGenericMethod(typeof(TKey), typeof(TValue)));
        }

        private Attribute? GetFSharpCompilationMappingAttribute(Type type)
            => type.GetCustomAttribute(_compilationMappingAttributeType, inherit: true);

        private SourceConstructFlags GetSourceConstructFlags(Attribute compilationMappingAttribute)
            => _sourceConstructFlagsGetter is null ? SourceConstructFlags.None : (SourceConstructFlags)_sourceConstructFlagsGetter.Invoke(compilationMappingAttribute, null)!;

        // If the provided type is generated by the F# compiler, returns the runtime FSharp.Core assembly.
        private static Assembly? GetFSharpCoreAssembly(Type type)
        {
            foreach (Attribute attr in type.GetCustomAttributes(inherit: true))
            {
                Type attributeType = attr.GetType();
                if (attributeType.FullName == CompilationMappingAttributeTypeName)
                {
                    return attributeType.Assembly;
                }
            }

            return null;
        }

        private static TDelegate CreateDelegate<TDelegate>(MethodInfo methodInfo) where TDelegate : Delegate
            => (TDelegate)Delegate.CreateDelegate(typeof(TDelegate), methodInfo, throwOnBindFailure: true)!;

        private TMemberInfo EnsureMemberExists<TMemberInfo>(TMemberInfo? memberInfo, string memberName) where TMemberInfo : MemberInfo
        {
            if (memberInfo is null)
            {
                ThrowHelper.ThrowMissingMemberException_MissingFSharpCoreMember(memberName);
            }

            return memberInfo;
        }

        // Replicates the F# source construct flags enum
        // https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-sourceconstructflags.html
        private enum SourceConstructFlags
        {
            None = 0,
            SumType = 1,
            RecordType = 2,
            ObjectType = 3,
            Field = 4,
            Exception = 5,
            Closure = 6,
            Module = 7,
            UnionCase = 8,
            Value = 9,
            KindMask = 31,
            NonPublicRepresentation = 32
        }
    }
}
