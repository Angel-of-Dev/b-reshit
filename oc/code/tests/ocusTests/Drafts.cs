// Copyright (c) Angel-of-Dev. All rights reserved.

using System.Diagnostics.CodeAnalysis;
using System.Text;
using angelof.dev.ocus.tests.Experiments.Numbers;
using oe.testing;

namespace angelof.dev.ocus.tests;

[SuppressMessage("ReSharper", "InconsistentNaming")]
public sealed class Drafts : TestsBase
{
    /// <inheritdoc/>
    public Drafts(ITestOutputHelper testOutputHelper, int? seed = null)
        : base(testOutputHelper, seed) { }

    [Fact]
    public void DraftIdxIdx()
    {
        var sb = new StringBuilder();
        var idxes = new IdxIdx();
        sb = IdxDescriptor.Describe(idxes, sb);
        TestOutputHelper.WriteLine(sb.ToString());
    }
}
