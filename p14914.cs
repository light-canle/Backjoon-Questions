#pragma warning disable CS8604, CS8602, CS8600

using System;

// p14914 - 사과와 바나나 나눠주기 (B3)
// #완전 탐색 #GCD
// 2025.12.17 solved

public class Program
{
    public static void Main(string[] args)
    {
        int[] count = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        int apple = count[0], banana = count[1];

        int gcd = GCD(apple, banana);

        for (int i = 1; i <= gcd; i++)
        {
            if (gcd % i == 0)
            {
                Console.WriteLine($"{i} {apple / i} {banana / i}");
            }
        }
    }

    public static int GCD(int a, int b)
    {
        if (b == 0) return a;
        return GCD(b, a % b);
    }
}
