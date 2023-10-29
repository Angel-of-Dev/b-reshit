// Copyright (c) Angel-of-Dev. All rights reserved.

using System.Numerics;
using angelof.dev.ocus.Primitives;

namespace angelof.dev.ocus.Numbers;

public readonly partial record struct ODD
{
    /// <summary> Represents a stem of an odd number. </summary>
    internal readonly record struct STEM : IMultiplyOperators<STEM, STEM, STEM>
    {
        /// <summary/>
        public STEM()
            : this(idx: -1, seq: 1) { }

        /// <summary/>
        public STEM(IDX idx, SEQ seq)
        {
            Idx = idx;
            Seq = seq;
        }

        /// <inheritdoc/>
        public static STEM operator *(STEM left, STEM right) => new(left.Idx * right.Idx, left.Seq * right.Seq);

        /// <summary/>
        public IDX Idx { get; }

        /// <summary> Gets the type of parity of this stem. </summary>
        /// <remarks>
        ///     <para> Parity is determined from <see cref="Idx"/> value.
        ///         <para> Index Zero has no parity. </para>
        ///         <para> Non-zero indexes inherit their parity from the parity of the index value. </para>
        ///     </para>
        /// </remarks>
        public PARITY Parity => GetParity(out _, out _);

        /// <summary/>
        public SEQ Seq { get; }

        internal PARITY GetParity(out EVN evn, out ODD odd)
        {
            var parity = Idx.Val == 0
                             ? PARITY.NoParity
                             : Idx.Val % 2 == 0
                                 ? PARITY.Even
                                 : PARITY.Odd;

            if (parity == PARITY.Even)
            {
                evn = EVN.FromValue(Idx.Val);
                odd = FromValue(Seq);
                return parity;
            }

            evn = EVN.FromValue(Seq);
            odd = FromValue(Idx);
            return parity;
        }
    }
}
