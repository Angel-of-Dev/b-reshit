// Copyright (c) Angel-of-Dev. All rights reserved.

namespace angelof.dev.Support;

/// <summary> Provides means of generating a string representation of specified objects. </summary>
internal static class Format
{
    /// <summary> Formats the sequence of items as a comma separated list of items. </summary>
    /// <param name="items"> The items to format. </param>
    public static string List<T>(params T[] items) => ListCore(items);

    private static string ListCore<T>(IEnumerable<T> items)
    {
        var list = string.Join(",", items.Select(static x => $"{x?.ToString()}"));
        return $"[{list}]";
    }
}
