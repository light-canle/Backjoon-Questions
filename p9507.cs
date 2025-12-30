#pragma warning disable CS8604, CS8602, CS8600

using System;
using System.Numerics;

// p9507 - Generations of Tribbles (S4)
// #DP
// 2025.12.31 solved (12.30)

public class Program
{
    public static void Main(string[] args)
    {
        BigInteger[] dp = new BigInteger[68];
        dp[0] = dp[1] = 1;
        dp[2] = 2;
        dp[3] = 4;
        for (int i = 4; i <= 67; i++)
        {
            BigInteger sum = 0;
            for (int j = 4; j >= 1; j--)
            {
                sum += dp[i - j];
            }
            dp[i] = sum;
        }

        int p = int.Parse(Console.ReadLine());
        for (int i = 0; i < p; i++)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(dp[n]);
        }
    }
}
