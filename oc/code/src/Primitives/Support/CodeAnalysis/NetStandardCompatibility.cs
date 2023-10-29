// Copyright (c) Angel-of-Dev. All rights reserved.

// ReSharper disable CheckNamespace

#if NETSTANDARD2_0
namespace System.Diagnostics.CodeAnalysis
{
    [AttributeUsage(AttributeTargets.Parameter)]
    [SuppressMessage("ReSharper", "RedundantTypeDeclarationBody")]
    internal sealed class NotNullAttribute : Attribute { }

    [AttributeUsage(AttributeTargets.Parameter)]
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    internal sealed class DoesNotReturnIfAttribute : Attribute
    {
        public DoesNotReturnIfAttribute(bool parameterValue) { ParameterValue = parameterValue; }
        public bool ParameterValue { get; }
    }
}
#endif
