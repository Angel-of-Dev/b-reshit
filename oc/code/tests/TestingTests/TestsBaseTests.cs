// Copyright (c) Angel-of-Dev. All rights reserved.

using System.Diagnostics.CodeAnalysis;
using oe.testing;

namespace oe.tests.TestingTests;

[SuppressMessage("Globalization", "CA1305:Specify IFormatProvider")]
public sealed class TestsBaseTests : TestsBase
{
    /// <inheritdoc/>
    public TestsBaseTests(ITestOutputHelper testOutputHelper, int? seed = null)
        : base(testOutputHelper, seed) { }

    [Fact]
    public void WhenRandomSeedEnvironmentVariableIsSet_UsesThatSeed()
    {
        const int expectedSeed = 13;
        Environment.SetEnvironmentVariable("RANDOM_SEED", $"{expectedSeed}");
        var sut = new TestsBaseTests(TestOutputHelper);

        Assert.Equal(expectedSeed, sut.RandomSeed);
    }

    [Fact]
    public void WhenRandomSeedEnvironmentVariableIsSetAndRandomSeedIsProvidedInConstructor_UsesSeedProvidedInConstructor()
    {
        try
        {
            Environment.SetEnvironmentVariable("RANDOM_SEED", "7");
            const int expectedSeed = 13;
            var sut = new TestsBaseTests(TestOutputHelper, expectedSeed);

            Assert.Equal(expectedSeed, sut.RandomSeed);
        }
        finally
        {
            Environment.SetEnvironmentVariable("Random_SEED", value: null);
        }
    }
}
