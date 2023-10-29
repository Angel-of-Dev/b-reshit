// Copyright (c) Angel-of-Dev. All rights reserved.

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using CAE = System.Runtime.CompilerServices.CallerArgumentExpressionAttribute;

namespace angelof.dev.tests;

public sealed class GuardTests
{
    [Fact]
    [SuppressMessage("Maintainability", "CA1508:Avoid dead conditional code")]
    [SuppressMessage("ReSharper", "ConditionIsAlwaysTrueOrFalse")]
    public void CanExtendGuardWithExtensionMethods()
    {
        const string obj = "abc";
        Guard.Argument.CustomArgumentValidation(obj);
        Guard.Expect.CustomExpectation(obj != null);
    }
}

internal static class GuardExtensions
{
    public static void CustomArgumentValidation<T>(this ArgumentGuard _, T arg, [CAE(nameof(arg))] string? parameterName = null)
        => Debug.WriteLine($"Custom argument validation logic for {arg} ({parameterName}).");

    public static void CustomExpectation(this ExpectGuard _, bool condition, [CAE(nameof(condition))] string? conditionDescription = null)
        => Debug.WriteLine($"Custom expectation validation logic {conditionDescription} => {condition}.");
}
