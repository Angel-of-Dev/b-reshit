// Copyright (c) Angel-of-Dev. All rights reserved.

using System.Diagnostics.CodeAnalysis;
using CAE = System.Runtime.CompilerServices.CallerArgumentExpressionAttribute;

namespace angelof.dev;

/// <summary> Provides run-time condition check logic. </summary>
/// <remarks>
///     <para> All methods MUST throw exceptions derived from <see cref="ExpectationException"/> when condition check fails. </para>
///     <para> Methods MAY return a value when condition check succeeds. This is to allow their use in `inline` scenarios, where separation
///         from other program logic may not be convenient (e.g. in linq queries). </para>
/// </remarks>
[SuppressMessage("ReSharper", "ParameterOnlyUsedForPreconditionCheck.Global", Justification = "This type uses parameters for precondition checks.")]
[SuppressMessage("Performance", "CA1822:Mark members as static")]
[SuppressMessage("ReSharper", "MemberCanBeMadeStatic.Global")]
public sealed class ExpectGuard
{
    /// <summary> Throws <see cref="ExpectationException"/> when <paramref name="condition"/> evaluates to <c> false </c>. </summary>
    /// <param name="condition"> The condition. </param>
    /// <param name="conditionDescription"> Optionally, the description of the condition. </param>
    /// <exception cref="ExpectationException"> <paramref name="condition"/> evaluates to <c> false </c>. </exception>
    public void Condition(bool condition, [CAE(nameof(condition))] string? conditionDescription = null)
    {
        if (!condition)
        {
            throw new ExpectationException($"{conditionDescription} => true", $"{conditionDescription} => false");
        }
    }

    /// <summary> Throws <see cref="ExpectationException"/> when <paramref name="condition"/> evaluates to <c> false </c>. </summary>
    /// <param name="condition"> The condition. </param>
    /// <param name="context"> The object representing additional context to include in exception message. </param>
    /// <param name="conditionDescription"> Optionally, the description of the condition. </param>
    /// <param name="contextDescription"> Optionally, the description of the additional context. </param>
    /// <exception cref="ExpectationException"> <paramref name="condition"/> evaluates to <c> false </c>. </exception>
    /// <returns> The <paramref name="context"/>. </returns>
    public T Condition<T>(T context,
                          bool condition,
                          [CAE(nameof(condition))] string? conditionDescription = null,
                          [CAE(nameof(context))] string? contextDescription = null)
    {
        if (!condition)
        {
            throw new ExpectationException($"{conditionDescription} => true",
                                           $"{conditionDescription} => false",
                                           new
                                           {
                                               context,
                                               contextDescription
                                           });
        }

        return context;
    }

    /// <summary> Throws <see cref="ExpectationException"/> when <paramref name="arg"/> is <c> null </c>. </summary>
    /// <param name="arg"> The argument to validate. </param>
    /// <param name="parameterName"> Optionally, the name of the argument. </param>
    /// <typeparam name="T"> The type of argument to validate. </typeparam>
    /// <exception cref="ExpectationException"> <paramref name="arg"/> is <c> null </c>. </exception>
    /// <returns> The <paramref name="arg"/>. </returns>
    public T NotNull<T>([NotNull] T? arg, [CAE(nameof(arg))] string? parameterName = null)
    {
        if (arg is null)
        {
            throw new ExpectationException($"{parameterName} is not null",
                                           $"{parameterName} is null",
                                           new
                                           {
                                               parameterName,
                                               arg
                                           });
        }

        return arg;
    }
}
