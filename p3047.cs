#pragma warning disable CS8604, CS8602, CS8600

using System;
using System.Linq;
using System.Collections.Generic;

// p3047 - ABC (B3)
// #구현
// 2025.10.12 solved

public class Program
{
    public static void Main(string[] args)
    {
        List<int> n = Console.ReadLine().Split().Select(int.Parse).ToList();
        n.Sort();
        string order = Console.ReadLine();
        List<int> ret = new();
        for (int i = 0; i < 3; i++)
        {
            ret.Add(n[order[i] - 'A']);
        }
        Console.WriteLine(string.Join(" ", ret));
    }
}
