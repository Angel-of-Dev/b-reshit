// Copyright (c) Angel-of-Dev. All rights reserved.

using System.Numerics;
using angelof.dev.ocus.Primitives;

namespace angelof.dev.ocus.Numbers;

/// <summary/>
public readonly record struct EVN
    : IMultiplyOperators<EVN, EVN, EVN>, IDivisionOperators<EVN, ODD, DIVREM>, IDivisionOperators<EVN, EVN, DIVREM>, IMultiplyOperators<EVN, ODD, ODD>,
      ISubtractionOperators<EVN, EVN, EVN>
{
    /// <summary/>
    public EVN()
        : this(1) { }

    internal EVN(IDX idx) { Idx = idx; }

    /// <inheritdoc/>
    public static DIVREM operator /(EVN left, ODD right) => DIVREM.Compute(left.Val, right.Val);

    /// <inheritdoc/>
    public static DIVREM operator /(EVN left, EVN right) => DIVREM.Compute(left.Val, right.Val);

    /// <inheritdoc/>
    public static EVN operator *(EVN left, EVN right) => FromValue(left.Val * right.Val);

    /// <inheritdoc/>
    public static ODD operator *(EVN left, ODD right) => ODD.FromValue(left.Val * right.Val);

    /// <inheritdoc/>
    public static EVN operator -(EVN left, EVN right) => FromValue(left.Val - right.Val);

    /// <summary/>
    public IDX Idx { get; }

    /// <summary/>
    public int Val => 2 * Idx.Val * Sign;

    /// <summary> Gets the sign of this number. </summary>
    public SIGN Sign => new(Idx.Val);

    /// <summary/>
    public static EVN FromIdx(IDX idx) => new(idx);

    /// <summary/>
    public static EVN FromSeq(SEQ seq) => new(seq.Val);

    /// <summary/>
    public static EVN FromValue(int evenValue)
    {
        Guard.Argument.Condition(evenValue, evenValue % 2 == 0);

        return new EVN(evenValue / 2);
    }
}
