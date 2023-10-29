// Copyright (c) Angel-of-Dev. All rights reserved.

using angelof.dev.ocus.tests.Experiments.Numbers;

namespace angelof.dev.ocus.tests.Numbers;

public sealed class OddIdxTests : IdxTestsBase<OddIdx, OddIdx.Key>
{
    /// <inheritdoc/>
    public OddIdxTests(ITestOutputHelper testOutputHelper, int? seed = null)
        : base(new OddIdx(), testOutputHelper, seed) { }

    [Theory]
    [InlineData(-1, -1)]
    [InlineData(-2, -3)]
    [InlineData(-3, -5)]
    [InlineData(-4, -7)]
    [InlineData(-5, -9)]
    [InlineData(-6, -11)]
    [InlineData(-7, -13)]
    [InlineData(-8, -15)]
    [InlineData(-9, -17)]
    public void Supports_negative_offsets(int offset, int expectedValue)
    {
        var key = Sut.GetKey(offset);
        Assert.Equal(expectedValue, key.Value);
    }

    [Theory]
    [InlineData(1, 1)]
    [InlineData(2, 3)]
    [InlineData(3, 5)]
    [InlineData(4, 7)]
    [InlineData(5, 9)]
    [InlineData(6, 11)]
    [InlineData(7, 13)]
    [InlineData(8, 15)]
    [InlineData(9, 17)]
    public void Supports_positive_offsets(int offset, int expectedValue)
    {
        var key = Sut.GetKey(offset);
        Assert.Equal(expectedValue, key.Value);
    }
}
