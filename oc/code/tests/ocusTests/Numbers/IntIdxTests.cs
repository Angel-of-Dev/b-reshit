// Copyright (c) Angel-of-Dev. All rights reserved.

using angelof.dev.ocus.tests.Experiments.Numbers;

namespace angelof.dev.ocus.tests.Numbers;

public sealed class IntIdxTests : IdxTestsBase<IntIdx, IntIdx.Key>
{
    /// <inheritdoc/>
    public IntIdxTests(ITestOutputHelper testOutputHelper, int? seed = null)
        : base(new IntIdx(), testOutputHelper, seed) { }

    [Theory]
    [InlineData(-1, 0)]
    [InlineData(-2, -1)]
    [InlineData(-3, -2)]
    [InlineData(-4, -3)]
    [InlineData(-5, -4)]
    [InlineData(-6, -5)]
    [InlineData(-7, -6)]
    [InlineData(-8, -7)]
    [InlineData(-9, -8)]
    public void Supports_negative_offsets(int offset, int expectedValue)
    {
        var key = Sut.GetKey(offset);
        Assert.Equal(expectedValue, key.Value);
    }

    [Theory]
    [InlineData(1, 0)]
    [InlineData(2, 1)]
    [InlineData(3, 2)]
    [InlineData(4, 3)]
    [InlineData(5, 4)]
    [InlineData(6, 5)]
    [InlineData(7, 6)]
    [InlineData(8, 7)]
    [InlineData(9, 8)]
    public void Supports_positive_offsets(int offset, int expectedValue)
    {
        var key = Sut.GetKey(offset);
        Assert.Equal(expectedValue, key.Value);
    }
}
