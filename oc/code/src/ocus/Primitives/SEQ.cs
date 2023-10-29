// Copyright (c) Angel-of-Dev. All rights reserved.

using System.Numerics;

namespace angelof.dev.ocus.Primitives;

/// <summary> Represents an integer type used for 1-based numbering of elements of sequences. </summary>
public readonly record struct SEQ : IComparisonOperators<SEQ, SEQ, bool>, IAdditionOperators<SEQ, SEQ, SEQ>, IMultiplyOperators<SEQ, SEQ, SEQ>
{
    internal static readonly SEQ One = new();

    /// <summary/>
    public SEQ()
        : this(1) { }

    /// <summary/>
    public SEQ(int val)
    {
        Guard.Argument.Condition(val, val != 0);

        Val = val;
    }

    /// <inheritdoc/>
    public static SEQ operator +(SEQ left, SEQ right) => left.Val + right.Val;

    /// <inheritdoc/>
    public static bool operator >(SEQ left, SEQ right) => left.Val > right.Val;

    /// <inheritdoc/>
    public static bool operator >=(SEQ left, SEQ right) => left.Val >= right.Val;

    /// <summary/>
    public static implicit operator int(SEQ seq) => seq.Val;

    /// <summary/>
    public static implicit operator SEQ(int seq) => new(seq);

    /// <inheritdoc/>
    public static bool operator <(SEQ left, SEQ right) => left.Val < right.Val;

    /// <inheritdoc/>
    public static bool operator <=(SEQ left, SEQ right) => left.Val <= right.Val;

    /// <inheritdoc/>
    public static SEQ operator *(SEQ left, SEQ right) => left.Val * right.Val;

    /// <summary/>
    public int Val { get; }

    /// <summary/>
    public SEQ Sqr => Val * Val;

    /// <inheritdoc/>
    public override string ToString() => $"{Val}";
}
