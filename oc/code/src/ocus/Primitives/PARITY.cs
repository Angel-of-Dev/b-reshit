// Copyright (c) Angel-of-Dev. All rights reserved.

using System.Diagnostics.CodeAnalysis;

namespace angelof.dev.ocus.Primitives;

/// <summary> Defines type of parity of a number. </summary>
[SuppressMessage("ReSharper", "InconsistentNaming")]
public enum PARITY
{
    /// <summary> Represents no parity, neither odd nor even. </summary>
    NoParity = 0,
    /// <summary> Represents odd parity. </summary>
    Odd = 1,
    /// <summary> Represents even parity. </summary>
    Even = 2
}
