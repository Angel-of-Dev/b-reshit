// Copyright (c) Angel-of-Dev. All rights reserved.

namespace angelof.dev.ocus.tests.Experiments.Numbers;

/// <summary> Represents an index of even numbers. </summary>
public sealed class EvenIdx : Idx<EvenIdx.Key>
{
    /// <inheritdoc/>
    protected override Key GetCore(int offset) => new(offset);

    /// <summary> Represents a key of an even index. </summary>
    public readonly record struct Key : IIdxKey
    {
        internal Key(int offset) { Offset = offset; }

        /// <summary> Gets the index offset represented by this key. </summary>
        public int Offset { get; }

        /// <summary> Gets the value referenced by this key. </summary>
        public int Value => 2 * Offset;

        /// <inheritdoc/>
        public int ToInt32() => Value;
    }
}
