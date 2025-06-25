using System;
using System.Linq;
using System.Collections.Generic;

// p17249 - 태보태보 총난타 (B2)
// #문자열
// 2025.6.25 solved

public class Program
{
    public static void Main(string[] args)
    {
        string s = Console.ReadLine();
        int left = s.Substring(0, s.IndexOf("(")).Count(c => c == '@');
        int right = s.Substring(s.IndexOf(")")).Count(c => c == '@');
        Console.WriteLine($"{left} {right}");
    }
}
