// Copyright (c) Angel-of-Dev. All rights reserved.

namespace angelof.dev.ocus.tests.Experiments.Numbers;

/// <summary> Represents an index of all integers. </summary>
/// <remarks>
///     <para> Zero is indexed twice: -1 and 1. </para>
///     <para> Negative numbers start with Negative Unit at -2. </para>
///     <para> Positive numbers start with Positive Unit at +2. </para>
/// </remarks>
public sealed class IntIdx : Idx<IntIdx.Key>
{
    /// <inheritdoc/>
    protected override Key GetCore(int offset) => new(offset);

    /// <summary> Represents a key of integer index. </summary>
    public readonly record struct Key : IIdxKey
    {
        internal Key(int offset)
        {
            Offset = offset;
            UnitModifier = Offset > 0
                               ? -1
                               : 1;
        }

        /// <summary> Gets the offset represented by this key. </summary>
        public int Offset { get; }

        /// <summary> Gets the unit modifier. </summary>
        public int UnitModifier { get; }

        /// <summary> Gets the value referenced by this key. </summary>
        public int Value => Offset + UnitModifier;

        /// <inheritdoc/>
        public int ToInt32() => Value;
    }
}
