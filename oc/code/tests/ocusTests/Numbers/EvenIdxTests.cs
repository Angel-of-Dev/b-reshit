// Copyright (c) Angel-of-Dev. All rights reserved.

using angelof.dev.ocus.tests.Experiments.Numbers;

namespace angelof.dev.ocus.tests.Numbers;

public sealed class EvenIdxTests : IdxTestsBase<EvenIdx, EvenIdx.Key>
{
    /// <inheritdoc/>
    public EvenIdxTests(ITestOutputHelper testOutputHelper, int? seed = null)
        : base(new EvenIdx(), testOutputHelper, seed) { }

    [Theory]
    [InlineData(-1, -2)]
    [InlineData(-2, -4)]
    [InlineData(-3, -6)]
    [InlineData(-4, -8)]
    [InlineData(-5, -10)]
    [InlineData(-6, -12)]
    [InlineData(-7, -14)]
    [InlineData(-8, -16)]
    [InlineData(-9, -18)]
    public void Supports_negative_offsets(int offset, int expectedValue)
    {
        var key = Sut.GetKey(offset);
        Assert.Equal(expectedValue, key.Value);
    }

    [Theory]
    [InlineData(1, 2)]
    [InlineData(2, 4)]
    [InlineData(3, 6)]
    [InlineData(4, 8)]
    [InlineData(5, 10)]
    [InlineData(6, 12)]
    [InlineData(7, 14)]
    [InlineData(8, 16)]
    [InlineData(9, 18)]
    public void Supports_positive_offsets(int offset, int expectedValue)
    {
        var key = Sut.GetKey(offset);
        Assert.Equal(expectedValue, key.Value);
    }
}
