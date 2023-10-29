// Copyright (c) Angel-of-Dev. All rights reserved.

using System.Diagnostics.CodeAnalysis;
using System.Text;
using angelof.dev.ocus.Numbers;
using angelof.dev.ocus.tests.Experiments;
using oe.testing;

namespace angelof.dev.ocus.tests;

[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("Globalization", "CA1305:Specify IFormatProvider")]
public sealed class ODDTRIPLETests : TestsBase
{
    /// <inheritdoc/>
    public ODDTRIPLETests(ITestOutputHelper testOutputHelper, int? seed = null)
        : base(testOutputHelper, seed) { }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    public void List(int famIdx)
    {
        var sb = new StringBuilder();

        var oddRoot = ODD.FromIdx(famIdx);
        sb = TheScribe.Describe(oddRoot, sb: sb).AppendLine().AppendLine("---").AppendLine();
        var areAllSuccessful = true;
        for (var genIdx = 0; genIdx <= 5; genIdx++)
        {
            var o = new ODD.TRIPLE(famIdx, genIdx);
            sb = TheScribe.Describe(o, sb);
            sb.AppendLine();
            sb = TheScribe.Check(o, out var isSuccessful, sb);
            sb.AppendLine();
            sb.AppendLine("---");
            sb.AppendLine();

            areAllSuccessful &= isSuccessful;
        }

        Log($"{famIdx}", sb.ToString());
        Assert.True(areAllSuccessful);
    }
}
