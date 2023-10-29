// Copyright (c) Angel-of-Dev. All rights reserved.

using System.Diagnostics.CodeAnalysis;
using CAE = System.Runtime.CompilerServices.CallerArgumentExpressionAttribute;

namespace angelof.dev.ocus.Validation;

[SuppressMessage("Performance", "CA1822:Mark members as static")]
[SuppressMessage("ReSharper", "EntityNameCapturedOnly.Local")]
[SuppressMessage("ReSharper", "InconsistentNaming")]
internal abstract class Check<TSut>
{
    protected Check(TSut o)
    {
        Guard.Argument.NotNull(o);

        this.o = o;
        SutString = Guard.Expect.NotNull(o.ToString());
    }

    public string SutString { get; }
    protected TSut o { get; }
    internal IEnumerable<CheckOutcome> GetAllRules() => GetAllRulesCore();

    protected CheckOutcome Condition(bool condition,
                                     bool shouldRun = true,
                                     [CAE(nameof(condition))] string? conditionDescription = null,
                                     [CAE(nameof(shouldRun))] string? shouldRunDescription = null)
    {
        Guard.Argument.NotNull(conditionDescription);

        return new CheckOutcome(SutString,
                                conditionDescription,
                                condition,
                                shouldRun,
                                shouldRunDescription);
    }

    protected CheckOutcome Equality(int expected,
                                    int actual,
                                    bool shouldRun = true,
                                    [CAE(nameof(actual))] string? actualSumDescription = null,
                                    [CAE(nameof(expected))] string? expectedDescription = null,
                                    [CAE(nameof(shouldRun))] string? shouldRunDescription = null)
    {
        Guard.Argument.NotNull(actualSumDescription);

        const int expectedWidth = 20;
        const int actualWidth = 60;

        var success = actual == expected;
        return new CheckOutcome(SutString,
                                ($"{expectedDescription}".PadRight(expectedWidth) +
                                 $"{(success
                                         ? " == "
                                         : $" == {expected} != ")} {actualSumDescription}").PadRight(actualWidth) +
                                $"== {actual}",
                                success,
                                shouldRun,
                                shouldRunDescription);
    }

    protected abstract IEnumerable<CheckOutcome> GetAllRulesCore();

    protected CheckOutcome Inequality(int a,
                                      int b,
                                      bool shouldRun = true,
                                      [CAE(nameof(b))] string? actualSumDescription = null,
                                      [CAE(nameof(a))] string? expectedDescription = null,
                                      [CAE(nameof(shouldRun))] string? shouldRunDescription = null)
    {
        Guard.Argument.NotNull(actualSumDescription);

        const int expectedWidth = 20;
        const int actualWidth = 60;

        var success = b != a;
        return new CheckOutcome(SutString,
                                ($"{expectedDescription}".PadRight(expectedWidth) +
                                 $"{(success
                                         ? " != "
                                         : " == ")} {actualSumDescription}").PadRight(actualWidth) +
                                $"   {a} 𝚫 {b} = {a - b}",
                                success,
                                shouldRun,
                                shouldRunDescription);
    }
}
