// Copyright (c) Angel-of-Dev. All rights reserved.

using System.Diagnostics.CodeAnalysis;
using angelof.dev.ocus.Primitives;

namespace angelof.dev.ocus.Numbers;

[SuppressMessage("ReSharper", "InconsistentNaming")]
public readonly partial record struct ODD
{
    internal readonly partial record struct TRIPLE
    {
        internal TRIPLE(IDX familyIdx, IDX generationIdx)
        {
            FamilyIdx = familyIdx;
            GenerationIdx = generationIdx;
        }

        public EVN b => EVN.FromValue((int)Math.Sqrt(c.Sqr.Val - a.Sqr.Val));
        public EVN B => b * b;
        public EVN D => C - (A + B);
        public IDX FamilyIdx { get; }
        public IDX GenerationIdx { get; }
        public ODD a => z * y;
        public ODD A => a * a;
        public ODD c => FromValue(a.Val + XHypotenuse.Val);

        /// <summary> Represents the length of hypotenuse. </summary>
        public ODD C => c.Sqr;

        public ODD z => x.Shift(GenerationIdx);
        internal EVN XHypotenuse => EVN.FromValue(X.Seq.Val - x.Val);
        internal ODD x => FromIdx(FamilyIdx);

        /// <summary> Gets the square of <see cref="x"/>. </summary>
        /// <remarks>
        ///     <para> Triple Family Traits
        ///         <para> Hypotenuse - Odd Leg = <see cref="X"/>.<see cref="ODD.Seq"/> - <see cref="x"/>.<see cref="ODD.Val"/>. </para>
        ///     </para>
        ///     <para> Right Triangle
        ///         <para> Length of Odd Leg = the <see cref="ODD.Val"/> of <see cref="x"/>. </para>
        ///         <para> Length of Even Leg = the <see cref="ODD.Idx"/> of <see cref="X"/>. </para>
        ///         <para> Length of Hypotenuse = the <see cref="ODD.Seq"/> of <see cref="X"/>. </para>
        ///     </para>
        /// </remarks>
        internal ODD X => x.Sqr;

        internal ODD y => FromIdx(GenerationIdx);
    }
}
