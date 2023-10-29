// Copyright (c) Angel-of-Dev. All rights reserved.

using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging;
using oe.testing.Logging;
using oe.testing.Randomness;
using Xunit.Abstractions;

namespace oe.testing;

/// <summary> Provides a base class for types containing xunit tests. </summary>
public abstract class TestsBase
{
    /// <summary> Gets the name of a random seed variable. </summary>
    public const string RandomSeedName = "RANDOM_SEED";

    /// <param name="testOutputHelper"> The test output helper associated with current test run. The value is normally provided by xUnit runner
    ///     when creating an instance of derived type. </param>
    /// <param name="seed"> Optionally, a seed for random number generator. Falls back to a value of <see cref="RandomSeedName"/> environment
    ///     variable, then to a value generated from current system time. </param>
    protected TestsBase(ITestOutputHelper testOutputHelper, int? seed = null)
    {
        TestOutputHelper = testOutputHelper;
        LoggerFactory = new LoggerFactory(new[] {new TestLoggerProvider(TestOutputHelper)});
        Logger = LoggerFactory.CreateLogger(GetType().FullName ?? GetType().Name);

        var actualSeed = Normalize(seed);
        Logger.LogInformation("Set random seed = {Seed}.", actualSeed);
        RandomSeed = actualSeed;
        Random = new RandomDataProvider(RandomSeed);
    }

    /// <summary> Gets the random seed used by this test class. </summary>
    public int RandomSeed { get; }

    /// <summary> Gets the <see cref="LoggerFactory"/> instance associated with this test context. </summary>
    /// <remarks> The factory uses <see cref="TestLoggerProvider"/> that forwards logs to <see cref="TestOutputHelper"/>. </remarks>
    public LoggerFactory LoggerFactory { get; }

    /// <summary> Gets the <see cref="ILogger"/> associated with this test class. </summary>
    /// <remarks> The logger is implemented as <see cref="TestLogger"/> that forwards logs to <see cref="TestOutputHelper"/>. </remarks>
    protected ILogger Logger { get; }

    /// <summary> Gets the random data provider. </summary>
    protected IRandomDataProvider Random { get; }

    /// <summary> Gets the instance of <see cref="ITestOutputHelper"/> associated with current test run. </summary>
    protected ITestOutputHelper TestOutputHelper { get; }

    /// <summary> Creates a test log entry. </summary>
    protected void Log(string name,
                       string log,
                       [CallerFilePath] string? path = null,
                       [CallerMemberName] string? caller = null)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentException.ThrowIfNullOrWhiteSpace(log);
        ArgumentException.ThrowIfNullOrWhiteSpace(path);
        ArgumentException.ThrowIfNullOrWhiteSpace(caller);

        TestOutputHelper.WriteLine(log);

        var root = Path.GetDirectoryName(path)!;
        var testClass = Path.GetFileNameWithoutExtension(path).Replace("Tests", string.Empty, StringComparison.OrdinalIgnoreCase);
        var dir = Path.Combine(root,
                               "_logs",
                               testClass,
                               caller);
        var file = Path.Combine(dir, $"{name}.md");

        Logger.LogInformation("Create test log: {PATH}", file);

        Directory.CreateDirectory(dir);
        File.WriteAllText(file, log);
    }

    private int Normalize(int? seed)
    {
        const int arbitraryConstant = 13;

        var actual = seed ?? arbitraryConstant;
        if (seed is null)
        {
            Logger.LogDebug("Random seed not set, check environment variable {RandomSeedName}.", RandomSeedName);
            var envVar = Environment.GetEnvironmentVariable(RandomSeedName);
            if (envVar == null ||
                !int.TryParse(envVar, out actual))
            {
                Logger.LogDebug("Random seed not set, use system time.");
                actual = (int)(DateTime.Now.Ticks % int.MaxValue);
            }
        }

        return actual;
    }
}
