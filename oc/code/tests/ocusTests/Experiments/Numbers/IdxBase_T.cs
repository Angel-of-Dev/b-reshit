// Copyright (c) Angel-of-Dev. All rights reserved.

namespace angelof.dev.ocus.tests.Experiments.Numbers;

/// <summary> Provides a base type for number indexes. </summary>
/// <typeparam name="TKey"> The type of key used by this index. </typeparam>
public abstract class Idx<TKey> : Idx where TKey : IIdxKey
{
    /// <summary> Gets the key identified by a non-zero offset. </summary>
    /// <param name="offset"> The offset of the key to get. Must be non-zero. </param>
    /// <exception cref="ArgumentOutOfRangeException"> <paramref name="offset"/> is zero. </exception>
    public TKey this[int offset] => GetKey(offset);

    /// <summary> Gets the key identified by a non-zero offset. </summary>
    /// <param name="offset"> The offset of the key to get. Must be non-zero. </param>
    /// <exception cref="ArgumentOutOfRangeException"> <paramref name="offset"/> is zero. </exception>
    public TKey GetKey(int offset)
    {
        Guard.Argument.Condition(offset, offset != 0);
        return GetCore(offset);
    }

    /// <inheritdoc/>
    internal override IIdxKey GetIdxKey(int offset) => GetKey(offset);

    /// <summary> Gets the key identified by the non-zero offset. </summary>
    /// <param name="offset"> The non-zero offset of the key to get. </param>
    protected abstract TKey GetCore(int offset);
}
