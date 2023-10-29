// Copyright (c) Angel-of-Dev. All rights reserved.

namespace angelof.dev;

/// <summary> Provides static extensions for this namespace. </summary>
public static class NamespaceExtensions
{
    private const string DefaultNewLine = "\n";

    /// <summary> Normalizes the new lines in given string, ensuring same representation on Windows and Linux. </summary>
    /// <param name="source"> The source string to normalize. </param>
    /// <param name="newLine"> Optionally, the new line to normalize to. Defaults to "\n". </param>
    /// <exception cref="ArgumentNullException"> <paramref name="source"/> is <c> null </c>. </exception>
    public static string NormalizeNewLines(this string source, string newLine = DefaultNewLine)
    {
        Guard.Argument.NotNull(source);

        source = source.Replace("\r\n", DefaultNewLine, StringComparison.Ordinal);
        if (newLine != DefaultNewLine)
        {
            source = source.Replace(DefaultNewLine, newLine, StringComparison.Ordinal);
        }

        return source;
    }
}
