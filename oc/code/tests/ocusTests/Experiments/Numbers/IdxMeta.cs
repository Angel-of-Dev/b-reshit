// Copyright (c) Angel-of-Dev. All rights reserved.

namespace angelof.dev.ocus.tests.Experiments.Numbers;

/// <summary> Provides metadata for <see cref="Idx{TKey}"/>. </summary>
public sealed record IdxMeta
{
    /// <summary/>
    public int A { get; init; }

    /// <summary/>
    public int B { get; init; }

    /// <summary/>
    public int C { get; init; }

    /// <summary/>
    public int D { get; init; }

    /// <summary> Computes metadata of an index. </summary>
    /// <param name="idx"> The index to compute metadata for. </param>
    public static IdxMeta Compute(Idx idx)
    {
        Guard.Argument.NotNull(idx);

        var a = idx.GetIdxKey(3).ToInt32();
        var b = idx.GetIdxKey(4).ToInt32();
        var c = idx.GetIdxKey(5).ToInt32();

        a *= a;
        b *= b;
        c *= c;
        return new IdxMeta
        {
            A = a,
            B = b,
            C = c,
            D = c - (a + b)
        };
    }
}
