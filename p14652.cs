#pragma warning disable CS8604, CS8602, CS8600

using System;

// p14652 - 나는 행복합니다~ (B4)
// #수학
// 2025.12.11 solved (12.10)

public class Program
{
    public static void Main(string[] args)
    {
        int[] info = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        int n = info[0], m = info[1], k = info[2];
        Console.WriteLine($"{k / m} {k % m}"); 
    }
}
