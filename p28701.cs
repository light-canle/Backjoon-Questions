#pragma warning disable CS8604, CS8602, CS8600

using System;
using System.Collections.Generic;
using System.Linq;

// p28701 - 세제곱의 합 (B5)
// #사칙연산
// 2025.12.9 solved (12.8)

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        int sum = n * (n + 1) / 2;
        Console.WriteLine(sum);
        Console.WriteLine(sum * sum);
        Console.WriteLine(Enumerable.Range(1, n).Select(x => x * x * x).Sum());
    }
}
