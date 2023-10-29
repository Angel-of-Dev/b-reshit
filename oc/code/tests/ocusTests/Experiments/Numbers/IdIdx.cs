// Copyright (c) Angel-of-Dev. All rights reserved.

namespace angelof.dev.ocus.tests.Experiments.Numbers;

/// <summary> Represents an identity index with key values matching their offsets. </summary>
public sealed class IdIdx : Idx<IdIdx.Key>
{
    /// <inheritdoc/>
    protected override Key GetCore(int offset) => new(offset);

    /// <summary> Represents a key of id index. </summary>
    public readonly record struct Key : IIdxKey
    {
        internal Key(int offset) { Offset = offset; }

        /// <summary> Gets the offset represented by this key. </summary>
        public int Offset { get; }

        /// <summary> Gets the value referenced by this key. </summary>
        public int Value => Offset;

        /// <inheritdoc/>
        public int ToInt32() => Value;
    }
}
