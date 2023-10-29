// Copyright (c) Angel-of-Dev. All rights reserved.

using System.Text;

namespace angelof.dev;

/// <summary> Represents exception thrown when expected run-time condition is not met. </summary>
public sealed partial class ExpectationException : InvalidOperationException
{
    /// <summary> Initializes a new instance of <see cref="ExpectationException"/>. </summary>
    public ExpectationException() { }

    /// <summary> Initializes a new instance of <see cref="ExpectationException"/>. </summary>
    /// <param name="message"> The message describing expectation and context in which it failed. </param>
    public ExpectationException(string message)
        : base(message) { }

    /// <summary> Initializes a new instance of <see cref="ExpectationException"/>. </summary>
    /// <param name="message"> The message describing expectation and context in which it failed. </param>
    /// <param name="innerException"> The inner exception. </param>
    public ExpectationException(string message, Exception innerException)
        : base(message, innerException) { }

    /// <summary> Initializes a new instance of <see cref="ExpectationException"/>. </summary>
    /// <param name="expected"> The description expected condition. </param>
    /// <param name="actual"> The description actual condition. </param>
    /// <param name="additionalContext"> Optionally, additional context of failed expectation. </param>
    public ExpectationException(string expected, string actual, object? additionalContext = null)
        : base(GetMessage(expected, actual, additionalContext)) { }

    private static string GetMessage(string expected, string actual, object? additionalContext = null)
    {
        const string expectedLabel = "🟩 Expected: ";
        const string actualLabel = "🟥 Actual: ";
        const string contextLabel = "Context:";

        var sb = new StringBuilder();
        sb.AppendLine();
        sb.Append(expectedLabel);
        sb.Append(expected);
        sb.AppendLine();
        sb.Append(actualLabel);
        sb.Append(actual);

        if (additionalContext is not null)
        {
            sb.AppendLine();
            sb.Append(contextLabel);
            sb.AppendLine();
            sb.Append(Serializer.Serialize(additionalContext));
        }

        return sb.ToString().NormalizeNewLines();
    }
}
