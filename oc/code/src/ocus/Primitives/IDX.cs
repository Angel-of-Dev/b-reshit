// Copyright (c) Angel-of-Dev. All rights reserved.

using System.Numerics;

namespace angelof.dev.ocus.Primitives;

/// <summary> Represents an integer type used for 0-based numbering of indexes. </summary>
public readonly record struct IDX : IComparisonOperators<IDX, IDX, bool>, IAdditionOperators<IDX, IDX, IDX>, IMultiplyOperators<IDX, IDX, IDX>
{
    /// <summary> Gets the zero. </summary>
    internal static readonly IDX Zero = new();

    /// <summary/>
    public IDX()
        : this(0) { }

    /// <summary/>
    public IDX(int val) { Val = val; }

    /// <inheritdoc/>
    public static IDX operator +(IDX left, IDX right) => left.Val + right.Val;

    /// <inheritdoc/>
    public static bool operator >(IDX left, IDX right) => left.Val > right.Val;

    /// <inheritdoc/>
    public static bool operator >=(IDX left, IDX right) => left.Val >= right.Val;

    /// <summary/>
    public static implicit operator int(IDX idx) => idx.Val;

    /// <summary/>
    public static implicit operator IDX(int idx) => new(idx);

    /// <inheritdoc/>
    public static bool operator <(IDX left, IDX right) => left.Val < right.Val;

    /// <inheritdoc/>
    public static bool operator <=(IDX left, IDX right) => left.Val <= right.Val;

    /// <inheritdoc/>
    public static IDX operator *(IDX left, IDX right) => left.Val * right.Val;

    /// <summary/>
    public IDX Sqr => Val * Val;

    /// <summary/>
    public int Val { get; }

    /// <inheritdoc/>
    public override string ToString() => $"{Val}";
}
