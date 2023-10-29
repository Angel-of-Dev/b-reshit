// Copyright (c) Angel-of-Dev. All rights reserved.

namespace angelof.dev.ocus.tests.Experiments.Numbers;

/// <summary> Provides a base type for number indexes. </summary>
public abstract class Idx
{
    /// <summary/>
    protected Idx() { Meta = IdxMeta.Compute(this); }

    /// <summary> Gets metadata of this index. </summary>
    public IdxMeta Meta { get; }

    /// <summary> Gets the key identified by a non-zero offset. </summary>
    /// <param name="offset"> The offset of the key to get. Must be non-zero. </param>
    /// <exception cref="ArgumentOutOfRangeException"> <paramref name="offset"/> is zero. </exception>
    internal abstract IIdxKey GetIdxKey(int offset);
}
