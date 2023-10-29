// Copyright (c) Angel-of-Dev. All rights reserved.

using System.Diagnostics.CodeAnalysis;
using angelof.dev.ocus.tests.Experiments.Navigation;
using oe.testing;
using static angelof.dev.ocus.tests.Experiments.Navigation.SHIFT.ShiftType;

namespace angelof.dev.ocus.tests.Navigation;

[SuppressMessage("ReSharper", "InconsistentNaming")]
public sealed class PATHTests : TestsBase
{
    /// <inheritdoc/>
    public PATHTests(ITestOutputHelper testOutputHelper, int? seed = null)
        : base(testOutputHelper, seed) { }

    [Fact]
    public void Mixed_sequence()
    {
        var p = new PATH().Add(1).Exp(2).Add(3).Exp(4);
        Assert.Collection(p.Segments,
                          x => IsAdd(x, val: 1),
                          x => IsExp(x, val: 2),
                          x => IsAdd(x, val: 3),
                          x => IsExp(x, val: 4));
    }

    [Theory]
    [InlineData(1, 2, 3)]
    public void Sequence_of_adds(int a, int b, int c)
    {
        var p = new PATH().Add(a).Add(b).Add(c);
        Assert.Collection(p.Segments,
                          x => IsAdd(x, a),
                          x => IsAdd(x, b),
                          x => IsAdd(x, c));
    }

    [Theory]
    [InlineData(1, 2, 3)]
    public void Sequence_of_exps(int a, int b, int c)
    {
        var p = new PATH().Exp(a).Exp(b).Exp(c);
        Assert.Collection(p.Segments,
                          x => IsExp(x, a),
                          x => IsExp(x, b),
                          x => IsExp(x, c));
    }

    private static void IsAdd(SHIFT o, int val)
    {
        Assert.Equal(Add, o.Type);
        Assert.Equal(val, o.Val);
    }

    private static void IsExp(SHIFT o, int val)
    {
        Assert.Equal(Exp, o.Type);
        Assert.Equal(val, o.Val);
    }
}
