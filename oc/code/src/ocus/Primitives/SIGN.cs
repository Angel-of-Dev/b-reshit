// Copyright (c) Angel-of-Dev. All rights reserved.

using System.Numerics;

namespace angelof.dev.ocus.Primitives;

/// <summary/>
public readonly record struct SIGN : IMultiplyOperators<SIGN, SIGN, SIGN>
{
    /// <summary> Gets the value of a sign of negative numbers. </summary>
    public const int NegativeValue = -1;
    /// <summary> Gets the value of a sign of positive numbers. </summary>
    public const int PositiveValue = 1;
    /// <summary> Gets the value of a sign of unsigned numbers. </summary>
    public const int UnsignedValue = 0;
    private readonly int _value;

    /// <summary/>
    public SIGN()
        : this(UnsignedValue) { }

    /// <summary/>
    public SIGN(int value)
    {
        _value = value switch
        {
            < 0 => NegativeValue,
            > 0 => PositiveValue,
            _   => UnsignedValue
        };
    }

    /// <summary/>
    public static implicit operator int(SIGN sign) => sign._value;

    /// <inheritdoc/>
    public static SIGN operator *(SIGN left, SIGN right) => new(left._value * right._value);
}
