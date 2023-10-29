// Copyright (c) Angel-of-Dev. All rights reserved.

namespace angelof.dev.ocus.tests.Experiments.Numbers;

/// <summary> Represents an index of odd numbers. </summary>
public sealed class OddIdx : Idx<OddIdx.Key>
{
    /// <inheritdoc/>
    protected override Key GetCore(int offset) => new(offset);

    /// <summary> Represents a key of an odd index. </summary>
    public readonly record struct Key : IIdxKey
    {
        internal Key(int offset)
        {
            Offset = offset;
            UnitModifier = Offset > 0
                               ? -1
                               : 1;
        }

        /// <summary> Gets the index offset represented by this key. </summary>
        public int Offset { get; }

        /// <summary> Gets the unit modifier. </summary>
        public int UnitModifier { get; }

        /// <summary> Gets the value referenced by this key. </summary>
        public int Value => 2 * Offset + UnitModifier;

        /// <inheritdoc/>
        public int ToInt32() => Value;
    }
}
