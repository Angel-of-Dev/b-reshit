// Copyright (c) Angel-of-Dev. All rights reserved.

// ReSharper disable CheckNamespace

#if NETSTANDARD2_1 || NETSTANDARD2_0
using System.Diagnostics.CodeAnalysis;

namespace System.Runtime.CompilerServices
{
    [AttributeUsage(AttributeTargets.Parameter)]
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    internal sealed class CallerArgumentExpressionAttribute : Attribute
    {
        public CallerArgumentExpressionAttribute(string parameterName) { ParameterName = parameterName; }
        public string ParameterName { get; }
    }
}
#endif
