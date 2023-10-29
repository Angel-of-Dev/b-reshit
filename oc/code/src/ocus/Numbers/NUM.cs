// Copyright (c) Angel-of-Dev. All rights reserved.

using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using angelof.dev.ocus.Primitives;

namespace angelof.dev.ocus.Numbers;

/// <summary/>
[SuppressMessage("ReSharper", "IdentifierTypo")]
public readonly record struct NUM : IComparisonOperators<NUM, int, bool>, IAdditionOperators<NUM, NUM, NUM>, IUnaryNegationOperators<NUM, NUM>
{
    /// <summary/>
    public static readonly NUM Zero = new();

    /// <summary/>
    public NUM()
        : this(idx: 0, PARITY.NoParity) { }

    internal NUM(IDX idx, PARITY parity)
    {
        Parity = parity;
        Idx = idx;
    }

    /// <inheritdoc/>
    public static NUM operator +(NUM left, NUM right) => FromValue(left.Val + right.Val);

    /// <inheritdoc/>
    public static bool operator ==(NUM left, int right) => left.Val == right;

    /// <inheritdoc/>
    public static bool operator >(NUM left, int right) => left.Val > right;

    /// <inheritdoc/>
    public static bool operator >=(NUM left, int right) => left.Val >= right;

    /// <summary/>
    public static implicit operator NUM(int v) => FromValue(v);

    /// <inheritdoc/>
    public static bool operator !=(NUM left, int right) => left.Val != right;

    /// <inheritdoc/>
    public static bool operator <(NUM left, int right) => left.Val < right;

    /// <inheritdoc/>
    public static bool operator <=(NUM left, int right) => left.Val <= right;

    /// <inheritdoc/>
    public static NUM operator -(NUM value) => FromValue(-value.Val);

    /// <summary/>
    public IDX Idx { get; }

    /// <summary/>
    public int Val => GetVal();

    /// <summary/>
    public PARITY Parity { get; }

    private int GetVal()
        => Parity switch
        {
            PARITY.NoParity => Idx.Val,
            PARITY.Even     => new EVN(Idx.Val).Val,
            PARITY.Odd      => ODD.FromIdx(Idx).Val,
            _               => throw Guard.Argument.InvalidSwitchCase(Parity)
        };

    /// <summary/>
    public static NUM FromValue(int value)
    {
        if (value == 0)
        {
            return new NUM();
        }
        return value % 2 == 0
                   ? new NUM(EVN.FromValue(value).Idx.Val, PARITY.Even)
                   : new NUM(ODD.FromValue(value).Stem.Idx, PARITY.Odd);
    }
}
