// Copyright (c) Angel-of-Dev. All rights reserved.

using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

namespace oe.testing.Logging;

/// <summary> Provides a custom implementation of <see cref="ILogger"/> that uses xunit logging infrastructure. </summary>
internal sealed class TestLogger : ILogger
{
    private readonly Func<string, LogLevel, bool> _filter;
    private readonly ITestOutputHelper _outputHelper;
    private readonly string _name;

    internal TestLogger(ITestOutputHelper outputHelper, string name, Func<string, LogLevel, bool>? filter = null)
    {
        _outputHelper = outputHelper;
        _name = Normalize(name);
        _filter = filter ?? (Func<string, LogLevel, bool>)((_, _) => true);
    }

    /// <inheritdoc/>
    public IDisposable? BeginScope<TState>(TState state) where TState : notnull => null;

    /// <inheritdoc/>
    public bool IsEnabled(LogLevel logLevel) => logLevel != LogLevel.None && _filter(_name, logLevel);

    /// <inheritdoc/>
    public void Log<TState>(LogLevel logLevel,
                            EventId eventId,
                            TState state,
                            Exception? exception,
                            Func<TState, Exception?, string> formatter)
    {
        if (!IsEnabled(logLevel))
        {
            return;
        }

        if (string.IsNullOrWhiteSpace(_name))
        {
            _outputHelper.WriteLine("{0}", formatter(state, arg2: null));
        }
        else
        {
            _outputHelper.WriteLine("{0} - {1}", _name, formatter(state, arg2: null));
        }

        if (exception != null)
        {
            _outputHelper.WriteLine("{0}", exception);
        }
    }

    /// <summary> Normalises logger name by removing tests namespace prefix. </summary>
    /// <remarks> Tests namespace prefix is common to all test loggers. Removing it improves log output readability. </remarks>
    private static string Normalize(string name)
    {
        const string testsPrefix = "Tests.";

        var startIdx = name.IndexOf(testsPrefix, StringComparison.Ordinal);
        if (startIdx < 0)
        {
            startIdx = name.IndexOf(testsPrefix, StringComparison.OrdinalIgnoreCase);
        }
        return startIdx < 0
                   ? name
                   : name[(startIdx + testsPrefix.Length)..];
    }
}
