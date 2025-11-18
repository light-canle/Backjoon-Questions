#pragma warning disable CS8604, CS8602

using System;

// p5598 - 카이사르 암호 (B2)
// #문자열
// 2025.11.19 solved

public class Program
{
    public static void Main(string[] args)
    {
        string code = Console.ReadLine()!;
        Console.WriteLine(Decode(code));
    }

    public static string Decode(string code)
    {
        string ret = "";
        foreach (char c in code)
        {
            int order = c - 'A';
            order -= 3;
            order = order < 0 ? order + 26 : order;
            char decoded = Convert.ToChar(order + 'A');
            ret += decoded;
        }
        return ret;
    }
}
