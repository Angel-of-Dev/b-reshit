// Copyright (c) Angel-of-Dev. All rights reserved.

using System.Diagnostics.CodeAnalysis;
using System.Text;
using angelof.dev.ocus.Numbers;
using angelof.dev.ocus.tests.Experiments;
using oe.testing;

namespace angelof.dev.ocus.tests;

[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("Globalization", "CA1305:Specify IFormatProvider")]
public sealed class ODDTests : TestsBase
{
    /// <inheritdoc/>
    public ODDTests(ITestOutputHelper testOutputHelper, int? seed = null)
        : base(testOutputHelper, seed) { }

    [Theory]
    [InlineData(0, 1)]
    [InlineData(1, 3)]
    [InlineData(2, 5)]
    [InlineData(3, 7)]
    public void Can_get_by_idx(int idx, int val)
    {
        var o = ODD.FromIdx(idx);
        Assert.Equal(val, o.Val);
    }

    [Theory]
    [InlineData(1, 1)]
    [InlineData(2, 3)]
    [InlineData(3, 5)]
    [InlineData(4, 7)]
    public void Can_get_by_seq(int idx, int val)
    {
        var o = ODD.FromSeq(idx);
        Assert.Equal(val, o.Val);
    }

    [Theory]
    [InlineData(1, 0, 1)]
    [InlineData(3, 1, 2)]
    [InlineData(5, 2, 3)]
    [InlineData(7, 3, 4)]
    public void Can_get_value(int val, int idx, int seq)
    {
        var o = ODD.FromValue(val);
        Assert.Equal(val, o.Val);
        Assert.Equal(idx, o.Stem.Idx.Val);
        Assert.Equal(seq, o.Stem.Seq.Val);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    public void List(int oddIdx)
    {
        var sb = new StringBuilder();

        var o = ODD.FromIdx(oddIdx);
        sb = TheScribe.Describe(o, sb: sb);
        sb.AppendLine();
        sb.AppendLine("---");
        sb.AppendLine();
        sb = TheScribe.Check(o, out var isSuccessful, sb);
        Log($"{oddIdx}", sb.ToString());

        Assert.True(isSuccessful);
    }
}
