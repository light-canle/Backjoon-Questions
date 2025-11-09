#pragma warning disable CS8604, CS8602, CS8600

using System;

// p2921 - 도미노 (B3)
// #수학
// 2025.11.10 solved (11.9)

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        int sum = 0;
        for (int i = 0; i <= n; i++)
        {
            for (int j = 0; j <= i; j++)
            {
                sum += i + j;
            }
        }
        Console.WriteLine(sum);
    }
}
