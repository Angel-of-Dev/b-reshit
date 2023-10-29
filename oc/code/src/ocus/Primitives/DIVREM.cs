// Copyright (c) Angel-of-Dev. All rights reserved.

namespace angelof.dev.ocus.Primitives;

/// <summary/>
public readonly record struct DIVREM
{
    private DIVREM(int n,
                   int p,
                   int q,
                   int r)
    {
        N = n;
        P = p;
        Q = q;
        R = r;
    }

    /// <summary/>
    public IDX N { get; }

    /// <summary/>
    public IDX Q { get; }

    /// <summary/>
    public IDX R { get; }

    /// <summary/>
    public SEQ P { get; }

    /// <inheritdoc/>
    public override string ToString() => $"{N.Val}={P.Val}*{Q.Val}+{R.Val}";

    /// <summary/>
    public static DIVREM Compute(IDX left, SEQ right)
    {
        var q = left.Val / right.Val;
        var r = left.Val - q * right.Val;

        return new DIVREM(left.Val,
                          right.Val,
                          q,
                          r);
    }
}
