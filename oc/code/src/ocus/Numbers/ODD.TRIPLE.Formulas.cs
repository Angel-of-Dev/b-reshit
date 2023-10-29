// Copyright (c) Angel-of-Dev. All rights reserved.

using System.Diagnostics.CodeAnalysis;
using angelof.dev.ocus.Validation;

namespace angelof.dev.ocus.Numbers;

[SuppressMessage("ReSharper", "InconsistentNaming")]
public readonly partial record struct ODD
{
    internal readonly partial record struct TRIPLE
    {
        internal sealed class Formulas : Check<TRIPLE>
        {
            /// <inheritdoc/>
            public Formulas(TRIPLE o)
                : base(o) { }

            /// <inheritdoc/>
            protected override IEnumerable<CheckOutcome> GetAllRulesCore()
            {
                var famIdx = o.FamilyIdx;
                var genIdx = o.GenerationIdx;
                var a = o.a;
                var b = o.b;
                var c = o.c;
                var A = o.A;
                var C = o.C;
                var D = o.D;
                var y = o.y;
                var z = o.z;

                yield return Equality(a.Val, (y * z).Val);
                yield return Equality(b.Val, famIdx * (y + z).Val);

                yield return Equality(a.Sqr.Val, (c + b).Val, genIdx == 0);
                yield return Equality(z.Sqr.Val, (c + b).Val);

                yield return Equality(2 * famIdx * y.Val, (c - (a + b)).Val);
                yield return Equality((y + z).Val * y.Val, (a + c - b).Val);
                yield return Equality(2 * famIdx * z.Val, (c + b - a).Val);

                yield return Condition(D.Val == 0);

                yield return Equality(expected: 0, c.Seq.Sqr - c.Idx.Sqr - a.Seq.Sqr - a.Idx.Sqr, genIdx == 0);
                yield return Equality(A.Val, b.Val + c.Val, genIdx == 0);
                yield return Equality(a.Val, c.Idx.Sqr - a.Idx.Sqr, famIdx == 1);
                yield return Equality(c.Val, c.Seq.Sqr - a.Seq.Sqr, famIdx == 1);
                yield return Equality(A.Seq, c.Idx.Sqr + a.Idx.Sqr, famIdx == 1);
                yield return Equality(C.Seq, c.Seq.Sqr + a.Seq.Sqr, famIdx == 1);
            }
        }
    }
}
