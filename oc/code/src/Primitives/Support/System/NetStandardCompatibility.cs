// Copyright (c) Angel-of-Dev. All rights reserved.

// ReSharper disable CheckNamespace

#if NETSTANDARD2_0
namespace cc
{
    internal static class SystemExtensions
    {
        public static string Replace(this string str,
                                     string oldValue,
                                     string? newValue,
                                     StringComparison _)
            => str.Replace(oldValue, newValue);
    }
}
#endif
