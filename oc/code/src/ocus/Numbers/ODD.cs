// Copyright (c) Angel-of-Dev. All rights reserved.

using System.Numerics;
using angelof.dev.ocus.Primitives;

namespace angelof.dev.ocus.Numbers;

/// <summary> Represents an odd integer. </summary>
public readonly partial record struct ODD
    : IMultiplyOperators<ODD, ODD, ODD>, IAdditionOperators<ODD, SEQ, ODD>, ISubtractionOperators<ODD, ODD, EVN>, IAdditionOperators<ODD, EVN, ODD>,
      IAdditionOperators<ODD, ODD, EVN>
{
    /// <summary/>
    public ODD()
        : this(idx: 0, seq: 1) { }

    internal ODD(IDX idx, SEQ seq) { Stem = new STEM(idx, seq); }

    /// <inheritdoc/>
    public static ODD operator +(ODD left, SEQ right) => FromSeq(left.Stem.Seq + right);

    /// <inheritdoc/>
    public static ODD operator +(ODD left, EVN right) => FromValue(left.Val + right.Val);

    /// <inheritdoc/>
    public static EVN operator +(ODD left, ODD right) => EVN.FromValue(left.Val + right.Val);

    /// <inheritdoc/>
    public static ODD operator *(ODD left, ODD right) => FromValue(left.Val * right.Val);

    /// <inheritdoc/>
    public static EVN operator -(ODD left, ODD right) => EVN.FromValue(left.Val - right.Val);

    /// <summary/>
    public IDX Idx => Stem.Idx;

    /// <summary/>
    public int Val => 2 * Stem.Idx + SIGN.PositiveValue;

    /// <summary/>
    public SEQ Seq => Stem.Seq;

    /// <summary> Gets the square of this number. </summary>
    internal ODD Sqr => Formulas.SqrFromRootStem(Stem);

    /// <summary/>
    internal STEM Stem { get; }

    /// <inheritdoc/>
    public override string ToString() => $"{Val}";

    /// <summary/>
    public static ODD FromValue(int oddValue)
    {
        Guard.Argument.Condition(oddValue, oddValue == 0 || oddValue % 2 != 0);

        if (oddValue == 0)
        {
            return FromIdx(0);
        }

        var seq = oddValue > 0
                      ? (oddValue + 1) / 2
                      : (oddValue - 1) / 2;
        var gap = oddValue - seq;
        return new ODD(gap, seq);
    }

    internal static ODD FromIdx(int idx) => FromIdx(new IDX(idx));
    internal static ODD FromIdx(IDX idx) => new(idx, idx.Val + 1);
    internal static ODD FromSeq(int seq) => FromSeq(new SEQ(seq));
    internal static ODD FromSeq(SEQ seq) => new(seq.Val - 1, seq);
}
