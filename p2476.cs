#pragma warning disable CS8604, CS8602, CS8600

using System;

// p2476 - 주사위 게임 (B3)
// #사칙연산
// 2025.12.21 solved (12.20)

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int maxPrize = 0;
        for (int i = 0; i < n; i++)
        {
            int[] dice = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            maxPrize = Math.Max(maxPrize, GetPrize(dice[0], dice[1], dice[2]));
        }
        Console.WriteLine(maxPrize);
    }

    public static int GetPrize(int a, int b, int c)
    {
        // 3개 모두 동일
        if (a == b && b == c)
        {
            return 10000 + a * 1000;
        }
        // 3개 중 2개만 동일
        else if (a == b || b == c)
        {
            return 1000 + b * 100;
        }
        else if (c == a)
        {
            return 1000 + a * 100;
        }
        // 모두 다름
        else
        {
            int max = Math.Max(a, Math.Max(b, c));
            return max * 100;
        }
    }
}
