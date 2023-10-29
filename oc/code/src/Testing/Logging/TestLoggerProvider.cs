// Copyright (c) Angel-of-Dev. All rights reserved.

using System.Collections.Immutable;
using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

namespace oe.testing.Logging;

/// <summary> Provides a custom implementation of <see cref="ILoggerProvider"/> that uses xunit logging infrastructure. </summary>
internal sealed class TestLoggerProvider : ILoggerProvider
{
    private readonly ITestOutputHelper _outputHelper;
    private ImmutableDictionary<string, TestLogger> _loggers = ImmutableDictionary<string, TestLogger>.Empty;
    internal TestLoggerProvider(ITestOutputHelper outputHelper) { _outputHelper = outputHelper ?? throw new ArgumentNullException(nameof(outputHelper)); }

    public ILogger CreateLogger(string name)
    {
        if (_loggers.TryGetValue(name, out var logger))
        {
            return logger;
        }

        logger = CreateNamedLogger(name);
        _loggers = _loggers.Add(name, logger);
        return logger;
    }

    public void Dispose() => _loggers = _loggers.Clear();
    private TestLogger CreateNamedLogger(string name) => new(_outputHelper, name);
}
