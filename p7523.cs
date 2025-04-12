using System;

// p7523 - Gauß (B2)
// #사칙연산
// 2025.4.12 solved

public class Program
{
    public static void Main(string[] args)
    {
        int s = int.Parse(Console.ReadLine());

        for (int i = 1; i <= s; i++)
        {
            long[] range = Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
            long a = range[0], b = range[1];
            Console.WriteLine($"Scenario #{i}:");
            Console.WriteLine(Sum(a, b));
            Console.WriteLine();
        }
    }

    public static long Sum(long a, long b)
    {
        if (a < 0 && b < 0)
        {
            return -Sum(-a) + Sum(-b - 1);
        }
        else if (a < 0 && b >= 0)
        {
            return -Sum(-a) + Sum(b);
        }
        else
        {
            return Sum(b) - Sum(a - 1);
        }
    }

    public static long Sum(long n)
    {
        if (n == 0) return 0;
        return n * (n + 1) / 2;
    }
}
