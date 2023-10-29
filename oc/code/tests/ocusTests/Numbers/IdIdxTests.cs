// Copyright (c) Angel-of-Dev. All rights reserved.

using angelof.dev.ocus.tests.Experiments.Numbers;

namespace angelof.dev.ocus.tests.Numbers;

public sealed class IdIdxTests : IdxTestsBase<IdIdx, IdIdx.Key>
{
    /// <inheritdoc/>
    public IdIdxTests(ITestOutputHelper testOutputHelper, int? seed = null)
        : base(new IdIdx(), testOutputHelper, seed) { }

    [Theory]
    [InlineData(-1, -1)]
    [InlineData(-2, -2)]
    [InlineData(-3, -3)]
    [InlineData(-4, -4)]
    [InlineData(-5, -5)]
    [InlineData(-6, -6)]
    [InlineData(-7, -7)]
    [InlineData(-8, -8)]
    [InlineData(-9, -9)]
    public void Supports_negative_offsets(int offset, int expectedValue)
    {
        var key = Sut.GetKey(offset);
        Assert.Equal(expectedValue, key.Value);
    }

    [Theory]
    [InlineData(1, 1)]
    [InlineData(2, 2)]
    [InlineData(3, 3)]
    [InlineData(4, 4)]
    [InlineData(5, 5)]
    [InlineData(6, 6)]
    [InlineData(7, 7)]
    [InlineData(8, 8)]
    [InlineData(9, 9)]
    public void Supports_positive_offsets(int offset, int expectedValue)
    {
        var key = Sut.GetKey(offset);
        Assert.Equal(expectedValue, key.Value);
    }
}
