// Copyright (c) Angel-of-Dev. All rights reserved.

namespace angelof.dev.ocus.tests.Experiments.Navigation;

/// <summary/>
public readonly record struct SHIFT
{
    /// <summary/>
    public SHIFT()
        : this(ShiftType.Unset, value: 0) { }

    /// <summary/>
    internal SHIFT(ShiftType type, int value)
    {
        Type = type;
        Val = value;
    }

    /// <summary/>
    public int Val { get; }

    /// <summary/>
    internal ShiftType Type { get; }

    internal static SHIFT Add(int val) => new(ShiftType.Add, val);
    internal static SHIFT Exp(int val) => new(ShiftType.Exp, val);
    internal static SHIFT Mul(int val) => new(ShiftType.Mul, val);

    internal enum ShiftType
    {
        Unset,
        Add,
        Mul,
        Exp
    }
}
