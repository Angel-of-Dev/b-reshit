// Copyright (c) Angel-of-Dev. All rights reserved.

using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace angelof.dev.ocus.tests.Experiments.Numbers;

/// <summary> Provides text description of an index. </summary>
[SuppressMessage("Globalization", "CA1305:Specify IFormatProvider")]
public static class IdxDescriptor
{
    /// <summary> Describes an index. </summary>
    public static StringBuilder Describe(Idx idx, StringBuilder? sb)
    {
        Guard.Argument.NotNull(idx);

        sb ??= new StringBuilder();

        sb.Append(GetIdxName(idx));

        for (var ix = 1; ix <= 10; ix++)
        {
            var key = idx.GetIdxKey(ix);
            sb.Append($"{key.ToInt32(),3}");
        }

        sb.Append($"\t{idx.Meta}");

        return sb;
    }

    /// <summary> Describes an index of indexes. </summary>
    public static StringBuilder Describe(IdxIdx idxes, StringBuilder? sb)
    {
        Guard.Argument.NotNull(idxes);

        sb ??= new StringBuilder();

        return idxes.All.Aggregate(sb, (current, idx) => Describe(idx, current).AppendLine());
    }

    private static string GetIdxName(Idx idx)
        => idx switch
        {
            EvenIdx => "[ Even ]",
            OddIdx  => "[  Odd ]",
            IntIdx  => "[  Int ]",
            IdIdx   => "[   Id ]",
            _       => idx.GetType().Name
        };
}

/// <summary> Represents and index of indexes. </summary>
public sealed class IdxIdx
{
    private readonly List<Idx> _all = new();

    /// <summary/>
    public IdxIdx()
    {
        _all.Add(new EvenIdx());
        _all.Add(new OddIdx());
        _all.Add(new IntIdx());
        _all.Add(new IdIdx());
    }

    internal IReadOnlyList<Idx> All => _all;
}
