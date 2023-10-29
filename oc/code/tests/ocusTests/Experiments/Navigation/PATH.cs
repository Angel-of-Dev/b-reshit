// Copyright (c) Angel-of-Dev. All rights reserved.

using System.Collections.Immutable;

namespace angelof.dev.ocus.tests.Experiments.Navigation;

/// <summary/>
public readonly record struct PATH
{
    /// <summary/>
    public static readonly PATH Self = new();

    /// <summary/>
    public PATH()
        : this(ImmutableList<SHIFT>.Empty) { }

    /// <summary/>
    public PATH(ImmutableList<SHIFT> segments) { Segments = segments; }

    /// <summary/>
    public ImmutableList<SHIFT> Segments { get; }

    /// <summary/>
    public PATH Add(int shift) => new(Segments.Add(SHIFT.Add(shift)));

    /// <summary/>
    public PATH Exp(int shift = 1) => new(Segments.Add(SHIFT.Exp(shift)));

    /// <summary/>
    public PATH Nxt() => Add(1);

    /// <summary/>
    public PATH Prv() => Add(-1);
}
