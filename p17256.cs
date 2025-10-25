#pragma warning disable CS8604, CS8602, CS8600

using System;

// p17256 - 달달함이 넘쳐흘러 (B4)
// #사칙연산
// 2025.10.26 solved (10.25)

public class Program
{
    public static void Main(string[] args)
    {
        int[] cakeA = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        int[] cakeC = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        int bx = cakeC[0] - cakeA[2];
        int by = cakeC[1] / cakeA[1];
        int bz = cakeC[2] - cakeA[0];

        Console.WriteLine($"{bx} {by} {bz}");
    }
}
