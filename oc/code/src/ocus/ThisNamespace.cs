// Copyright (c) Angel-of-Dev. All rights reserved.

using System.Diagnostics.CodeAnalysis;
using angelof.dev.ocus.Numbers;
using angelof.dev.ocus.Primitives;

namespace angelof.dev.ocus;

/// <summary> Provides static extensions for this namespace. </summary>
[SuppressMessage("ReSharper", "InconsistentNaming")]
public static class ThisNamespace
{
    internal static ODD Shift(this ODD odd, IDX shift) => ODD.FromIdx(odd.Stem.Idx + shift.Val);
    internal static ODD Shift(this ODD odd, SEQ shift) => ODD.FromIdx(odd.Stem.Seq + shift.Val);
    internal static NUM Square(this NUM evo) => NUM.FromValue(evo.Val * evo.Val);
    internal static EVN ToEven(this IDX idx) => EVN.FromIdx(idx);
    internal static EVN ToEven(this SEQ seq) => EVN.FromSeq(seq);
    internal static ODD ToOdd(this SEQ seq) => ODD.FromSeq(seq);
    internal static ODD ToOdd(this IDX idx) => ODD.FromIdx(idx);

    internal static T VerifyGet<T>(this SEQ seq, T thing)
    {
        VerifyNotZero(seq);
        return thing;
    }

    internal static void VerifyNotZero(this SEQ seq) => Guard.Expect.Condition(seq, seq.Val != 0);
    internal static void VerifyZeroReminder(this DIVREM dr) => Guard.Expect.Condition(dr, dr.R == 0);
}
