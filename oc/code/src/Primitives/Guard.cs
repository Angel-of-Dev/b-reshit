// Copyright (c) Angel-of-Dev. All rights reserved.

namespace angelof.dev;

/// <summary> Provides static access to <see cref="ArgumentGuard"/> and <see cref="ExpectGuard"/>. </summary>
/// <remarks>
///     <para> Provide additional guard logic with extension methods to <see cref="ArgumentGuard"/> and <see cref="ExpectGuard"/>. </para>
/// </remarks>
public static class Guard
{
    /// <summary> Gets the argument guard that provides run-time argument validation logic. </summary>
    public static readonly ArgumentGuard Argument = new();
    /// <summary> Gets the expectation guard that provides run-time condition check logic. </summary>
    public static readonly ExpectGuard Expect = new();
}
