// Copyright (c) Angel-of-Dev. All rights reserved.

using System.Diagnostics.CodeAnalysis;
using CAE = System.Runtime.CompilerServices.CallerArgumentExpressionAttribute;

namespace angelof.dev;

/// <summary> Provides run-time argument validation logic. </summary>
/// <remarks>
///     <para> All methods MUST throw exceptions derived from <see cref="ArgumentException"/> when argument validation fails. </para>
///     <para> All methods MUST return <c> void </c> when argument validation succeeds. This is to encourage visual separation of argument
///         validation code from other logic, improving code readability. </para>
/// </remarks>
[SuppressMessage("Performance", "CA1822:Mark members as static")]
[SuppressMessage("ReSharper", "MemberCanBeMadeStatic.Global")]
public sealed class ArgumentGuard
{
    /// <summary> Throws <see cref="ArgumentOutOfRangeException"/> when <paramref name="condition"/> evaluates to <c> false </c>. </summary>
    /// <param name="arg"> The argument used in <paramref name="condition"/> check. </param>
    /// <param name="condition"> The condition that evaluates <paramref name="arg"/>. </param>
    /// <param name="parameterName"> The name of the argument used in exception message when validation fails. </param>
    /// <param name="conditionDescription"> The description of the condition used in exception message when validation fails. </param>
    public void Condition<T>(T arg,
                             bool condition,
                             [CAE(nameof(arg))] string? parameterName = null,
                             [CAE(nameof(condition))] string? conditionDescription = null)
    {
        if (!condition)
        {
            throw new ArgumentOutOfRangeException(parameterName, arg, $"MUST satisfy condition `{conditionDescription}`");
        }
    }

    /// <summary> Returns <see cref="ArgumentOutOfRangeException"/> indicating an invalid switch case value. </summary>
    /// <param name="arg"> The invalid switch case value. </param>
    /// <param name="parameterName"> The name of the argument used in exception message. </param>
    public ArgumentOutOfRangeException InvalidSwitchCase<T>(T arg, [CAE(nameof(arg))] string? parameterName = null) => new(parameterName, arg, "[Switch Case, Invalid Fallback]");

    /// <summary> Throws <see cref="ArgumentNullException"/> when <paramref name="arg"/> is <c> null </c>. </summary>
    /// <param name="arg"> The argument to validate. </param>
    /// <param name="parameterName"> Optionally, the name of the argument used in exception message when validation fails. </param>
    /// <typeparam name="T"> The type of argument to validate. </typeparam>
    /// <exception cref="ArgumentNullException"> <paramref name="arg"/> is <c> null </c>. </exception>
    public void NotNull<T>([NotNull] T? arg, [CAE(nameof(arg))] string? parameterName = null)
    {
        if (arg is null)
        {
            throw new ArgumentNullException(parameterName);
        }
    }

    /// <summary> Throws <see cref="ArgumentNullException"/> when <paramref name="arg"/> is <c> null </c> or
    ///     <see cref="ArgumentOutOfRangeException"/> when <paramref name="arg"/> is empty or consists only of white-space characters. </summary>
    /// <param name="arg"> The argument to validate. </param>
    /// <param name="parameterName"> Optionally, the name of the argument used in exception message when validation fails. </param>
    /// <param name="message"> Optionally, a custom message used in exception when validation fails. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="arg"/> is <c> null </c>. </exception>
    /// <exception cref="ArgumentOutOfRangeException"> <paramref name="arg"/> is empty or consists only of white-space characters. </exception>
    public void NotNullOrWhiteSpace(string? arg,
                                    [CAE(nameof(arg))] string? parameterName = null,
                                    string? message = "must not be null, empty or consist only of white-space characters")
    {
        if (arg is null)
        {
            throw new ArgumentNullException(parameterName);
        }

        if (string.IsNullOrWhiteSpace(arg))
        {
            throw new ArgumentOutOfRangeException(parameterName, arg, message);
        }
    }
}
