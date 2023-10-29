// Copyright (c) Angel-of-Dev. All rights reserved.

namespace oe.testing.Randomness;

/// <summary> Provides means of generating test data. </summary>
public interface IRandomDataProvider
{
    /// <summary> Gets the list of alpha-numeric characters. </summary>
    public const string AlphaNumericCharacters = "1234567890qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM";

    /// <summary> Gets the pseudo-random number generator. </summary>
    Random Generator { get; }

    /// <summary> Returns a random string containing alpha-numeric characters. </summary>
    /// <remarks>
    ///     <para> Implementations MUST restrict allowed characters to <see cref="AlphaNumericCharacters"/>. </para>
    /// </remarks>
    /// <param name="minLength"> The minimum length of string to return. </param>
    /// <param name="maxLength"> The maximum length of string to return. </param>
    string AlphaNumericString(int minLength = 1, int maxLength = 20);

    /// <summary> Generates a random integer. </summary>
    /// <param name="min"> The inclusive lower bound of the random number returned. </param>
    /// <param name="max"> The exclusive upper bound of the random number returned. <paramref name="max"/> must be greater than or equal to
    ///     <paramref name="min"/>. </param>
    int Int32(int min = int.MinValue, int max = int.MaxValue);
}
