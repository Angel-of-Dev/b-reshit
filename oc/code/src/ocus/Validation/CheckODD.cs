// Copyright (c) Angel-of-Dev. All rights reserved.

using System.Diagnostics.CodeAnalysis;
using angelof.dev.ocus.Numbers;

namespace angelof.dev.ocus.Validation;

[SuppressMessage("Performance", "CA1822:Mark members as static")]
[SuppressMessage("ReSharper", "EntityNameCapturedOnly.Local")]
[SuppressMessage("ReSharper", "InconsistentNaming")]
internal sealed class CheckODD : Check<ODD>
{
    /// <inheritdoc/>
    public CheckODD(ODD o)
        : base(o) { }

    /// <inheritdoc/>
    protected override IEnumerable<CheckOutcome> GetAllRulesCore()
    {
        var O = o.Sqr;
        var Oo = O * o;
        var s = o.Stem.Seq.Val;
        var S = s * s;
        var Ss = S * s;
        var v = o.Val;
        var V = v * v;
        var i = o.Stem.Idx.Val;
        var I = i * i;
        var Ii = I * I;

        yield return Inequality(V, Ss - Ii, s != 0 && s != 1);
        yield return Inequality(Oo.Stem.Seq, Ss + Ii, s != 0 && s != 1);
        yield return Inequality(Oo.Stem.Seq, S * V - I, s != 0 && s != 1);
        yield return Inequality(Oo.Stem.Seq, I * V + S, s != 0 && s != 1);
    }
}
