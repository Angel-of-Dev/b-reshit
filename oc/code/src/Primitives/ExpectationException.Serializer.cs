// Copyright (c) Angel-of-Dev. All rights reserved.

using System.Text.Json;

namespace angelof.dev;

public sealed partial class ExpectationException
{
    private static class Serializer
    {
        private static readonly JsonSerializerOptions s_jsonOptions = new() {WriteIndented = true};

        internal static string Serialize<T>(T value)
        {
            var s = value?.ToString();
            return !string.IsNullOrWhiteSpace(s)
                       ? s
                       : JsonSerializer.Serialize(value, s_jsonOptions);
        }
    }
}
