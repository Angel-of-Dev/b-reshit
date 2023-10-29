// Copyright (c) Angel-of-Dev. All rights reserved.

using System.Diagnostics.CodeAnalysis;
using angelof.dev.ocus.Primitives;
using angelof.dev.ocus.Validation;

namespace angelof.dev.ocus.Numbers;

[SuppressMessage("ReSharper", "InconsistentNaming")]
public readonly partial record struct ODD
{
    internal sealed class Formulas : Check<ODD>
    {
        private readonly IDX idx;
        private readonly int val;
        private readonly SEQ seq;

        /// <inheritdoc/>
        public Formulas(ODD o)
            : base(o)
        {
            val = o.Val;
            idx = o.Idx;
            seq = o.Seq;
        }

        /// <inheritdoc/>
        protected override IEnumerable<CheckOutcome> GetAllRulesCore()
        {
            // Equations for Value
            yield return Equality(o.Val, 2 * idx + 1);
            yield return Equality(o.Val, idx + seq);
            yield return Equality(o.Val, seq.Sqr - idx.Sqr);

            // Equations for Square Value
            yield return Equality(o.Sqr.Val, 4 * idx.Sqr + 4 * idx + 1);

            // Equations for Square Index
            yield return Equality(o.Sqr.Idx, val * seq - seq);
            yield return Equality(o.Sqr.Idx, 2 * idx.Sqr + 2 * idx);
            yield return Equality(o.Sqr.Idx, val * idx + idx);

            // Equations for Square Sequence
            yield return Equality(o.Sqr.Seq, idx.Sqr + seq.Sqr);
            yield return Equality(o.Sqr.Seq, val * idx + seq);
            yield return Equality(o.Sqr.Seq, val * seq - idx);

            // Facts about Square Index
            yield return Condition(o.Sqr.Idx % 2 == 0);
        }

        /// <summary> Computes odd square from odd root. </summary>
        public static ODD SqrFromRootStem(STEM stem) => FromSeq(stem.Idx.Sqr.Val + stem.Seq.Sqr.Val);

        /// <summary> Computes odd square index from odd root index. </summary>
        public static int SqrIdxFromIdx(IDX idx) => 2 * idx.Sqr + 2 * idx;

        /// <summary> Computes odd square value from odd root index. </summary>
        public static int SqrValFromIdx(IDX idx) => 4 * idx.Sqr + 4 * idx + 1;

        /// <summary> Computes odd value from odd number's index. </summary>
        public static int ValFromIdx(IDX idx) => 2 * idx + 1;
    }
}
