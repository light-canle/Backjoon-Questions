#pragma warning disable CS8604, CS8602, CS8600

using System;

// p27110 - 특식 배부 (B4)
// #사칙연산
// 2025.10.29 solved

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int[] chickens = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        int sum = 0;
        for (int i = 0; i < 3; i++)
        {
            sum += chickens[i] <= n ? chickens[i] : n;
        }
        Console.WriteLine(sum);
    }
}
