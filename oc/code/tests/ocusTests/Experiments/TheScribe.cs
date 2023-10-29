// Copyright (c) Angel-of-Dev. All rights reserved.

using System.Diagnostics.CodeAnalysis;
using System.Text;
using angelof.dev.ocus.Numbers;
using angelof.dev.ocus.Primitives;
using angelof.dev.ocus.Validation;

namespace angelof.dev.ocus.tests.Experiments;

[SuppressMessage("Globalization", "CA1305:Specify IFormatProvider")]
[SuppressMessage("ReSharper", "InconsistentNaming")]
internal static class TheScribe
{
    private const int ColumnWidth = 12;

    public static StringBuilder Check(ODD o, out bool isSuccessful, StringBuilder? sb = null)
    {
        sb ??= new StringBuilder();
        var check = new ODD.Formulas(o);
        isSuccessful = true;
        foreach (var outcome in check.GetAllRules())
        {
            if (outcome is {ShouldRun: true, IsSuccess: false})
            {
                isSuccessful = false;
            }

            sb.AppendLine(Say(outcome));
        }

        return sb;
    }

    public static StringBuilder Check(ODD.TRIPLE o, out bool isSuccessful, StringBuilder? sb = null)
    {
        sb ??= new StringBuilder();
        var check = new ODD.TRIPLE.Formulas(o);
        isSuccessful = true;
        foreach (var outcome in check.GetAllRules())
        {
            if (outcome is {ShouldRun: true, IsSuccess: false})
            {
                isSuccessful = false;
            }

            sb.AppendLine(Say(outcome));
        }

        return sb;
    }

    public static StringBuilder Describe(ODD.TRIPLE o, StringBuilder? sb = null)
    {
        sb ??= new StringBuilder();

        var a = o.a;
        var b = o.b;
        var c = o.c;
        var A = o.A;
        var B = o.B;
        var C = o.C;
        var D = o.D;

        const int padding = 40;
        sb = sb.AppendLine($"FamIdx: {o.FamilyIdx.Val} GenIdx: {o.GenerationIdx.Val} x: {o.x.Val} y: {o.y.Val} z: {o.z.Val} h: {o.XHypotenuse.Val}").AppendLine();
        sb = sb.AppendLine($"{R("TRIPLE")}{T("ODD")}{T("EVEN")}{T("ODD")}")
               .AppendLine($"{Ris("abc")}{T(IS(a))}{T(IS(b))}{T(IS(c))}".PadRight(padding))
               .AppendLine($"{Rv("abc")}{T(V(a))}{T(V(b))}{T(V(c))}".PadRight(padding))
               .AppendLine($"{Rs("ABC")}{T(IS(A))}{T(IS(B))}{T(IS(C))}".PadRight(padding) + $"{R(post: "𝛅")}{T(IS(D))}")
               .AppendLine($"{Rv("ABC")}{T(V(A))}{T(V(B))}{T(V(C))}".PadRight(padding) + $"{R(post: "𝚫")}{T(V(D))}");

        return sb;
    }

    public static StringBuilder Describe(ODD o, int rootCount = 4, StringBuilder? sb = null)
    {
        sb ??= new StringBuilder();
        const int padding = 40;
        sb = sb.AppendLine($"{R("ODD")}{T("SEQ")}{T("IDX")}{R("STEM")}{T("SEQ")}{T("IDX")}".PadRight(padding));
        return DescribeSquares(o, rootCount);

        StringBuilder DescribeSquares(ODD root, int count)
        {
            var odd = root;
            var stem = odd.Stem;
            for (var exp = 1; exp <= count; exp++)
            {
                sb = sb.AppendLine($"{R(V(odd))}{T(S(odd))}{T(I(odd))}{R($"e={exp}")}{T(S(stem))}{T(I(stem))}".PadRight(padding));

                odd *= root;
                stem *= root.Stem;
            }

            return sb;
        }
    }

    public static string Parity(PARITY parity)
        => parity switch
        {
            PARITY.NoParity => "Z",
            PARITY.Odd      => "O",
            PARITY.Even     => "E",
            _               => throw Guard.Argument.InvalidSwitchCase(parity)
        };

    public static string Say(CheckOutcome o)
        => $"[{(!o.ShouldRun
                    ? o.IsSuccess == true
                          ? "🟨"
                          : "  "
                    : o.IsSuccess == true
                        ? "🟩"
                        : "🟥")}]".PadRight(6) +
           $"{o.Condition}".PadRight(100) +
           $"|{o.RunCondition}";

    private static string H(string head = " ", string pre = "=>", string post = " ") => R(head, pre, post);
    private static string Hi(string head) => H(head, post: "i:");
    private static string Hv(string head) => H(head, post: "==");
    private static string I(int idx) => $"{idx}:";
    private static string I(ODD o) => I(o.Stem);
    private static string I(ODD.STEM o) => I(o.Idx.Val);
    private static string IS(ODD o) => $"{o.Idx.Val}:{o.Seq.Val}";
    private static string IS(EVN o) => $"{o.Idx.Val}:{o.Idx.Val}";
    private static string Left(string s, string pre = "[") => T(-ColumnWidth, $"{pre}{s}");
    private static string R(string head = " ", string pre = " ", string post = " ") => $"{T(w: 3, pre)}{T(w: 5, head)}|{T(w: 1, post)}";
    private static string Ri(string head) => R(head, post: "i:");
    private static string Right(string s, string post = "]") => T(ColumnWidth, $"{s}{post}");
    private static string Ris(string head) => R(head, post: "is");
    private static string Rs(string head) => R(head, post: ":s");
    private static string Rv(string head) => R(head, post: "==");
    private static string S(int seq) => $":{seq}";
    private static string S(SEQ seq) => S(seq.Val);
    private static string S(ODD o) => S(o.Stem.Seq.Val);
    private static string S(ODD.STEM o) => S(o.Seq.Val);
    private static string S(NUM o) => S(o.Idx.Val);
    private static string S(EVN o) => S(o.Idx.Val);
    private static string Say<TItem>(IEnumerable<TItem> items) => string.Join("", items.Select(x => $"{T(x)}"));

    private static string Say(SIGN s)
        => (int)s switch
        {
            -1 => "-",
            0  => "^",
            +1 => "+",
            _  => "?"
        };

    private static string T<TItem>(TItem thing) => T(ColumnWidth, $"{thing}");

    private static string T(int w, string s)
        => w > 0
               ? s.PadLeft(w)
               : s.PadRight(-w);

    private static string T(string txt) => T(ColumnWidth, txt);
    private static string V(int val) => $"{val}";
    private static string V(ODD odd) => V(odd.Val);
    private static string V(NUM evo) => V(evo.Val);
    private static string V(EVN evn) => V(evn.Val);
}
