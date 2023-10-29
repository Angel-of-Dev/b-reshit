// Copyright (c) Angel-of-Dev. All rights reserved.

using angelof.dev.ocus.tests.Experiments.Numbers;
using oe.testing;

namespace angelof.dev.ocus.tests.Numbers;

public abstract class IdxTestsBase<TIdx, TKey> : TestsBase where TIdx : Idx<TKey>
                                                           where TKey : IIdxKey
{
    /// <inheritdoc/>
    protected IdxTestsBase(TIdx sut, ITestOutputHelper testOutputHelper, int? seed = null)
        : base(testOutputHelper, seed)
    {
        Sut = sut;
    }

    protected TIdx Sut { get; }

    [Fact]
    public void Throws_on_zero_offset()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => Sut[0]);
        Assert.Throws<ArgumentOutOfRangeException>(() => Sut.GetKey(0));
    }
}
