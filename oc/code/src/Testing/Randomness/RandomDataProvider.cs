// Copyright (c) Angel-of-Dev. All rights reserved.

using Bogus;

namespace oe.testing.Randomness;

internal sealed class RandomDataProvider : IRandomDataProvider
{
    private readonly Faker _faker;

    /// <summary> Initializes a new instance of <see cref="RandomDataProvider"/>. </summary>
    /// <param name="seed"> The seed for random number generator. </param>
    internal RandomDataProvider(int seed)
    {
        _faker = new Faker();
        Generator = new Random(seed);
    }

    /// <inheritdoc/>
    public Random Generator { get; }

    /// <inheritdoc/>
    public string AlphaNumericString(int minLength = 1, int maxLength = 20) => _faker.Random.String2(minLength, maxLength, IRandomDataProvider.AlphaNumericCharacters);

    /// <inheritdoc/>
    /// CA5394
    public int Int32(int min = int.MinValue, int max = int.MaxValue) => Generator.Next(min, max);
}
