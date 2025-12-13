#pragma warning disable CS8604, CS8602, CS8600

using System;
using System.Numerics;

// p10826 - 피보나치 수 4 (S5)
// #DP
// 2025.12.14 solved (12.13)

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        // 작은 값에 대한 결과
        if (n == 0)
        {
            Console.WriteLine(0); return;
        }
        else if (n == 1) 
        {
            Console.WriteLine(1); return;
        }
        // 피보나치 수열 생성
        BigInteger[] dp = new BigInteger[n + 1];
        dp[0] = 0;
        dp[1] = 1;

        for (int i = 2; i <= n; i++)
        {
            dp[i] = dp[i - 1] + dp[i - 2];
        }
        Console.WriteLine(dp[n]);
    }
}
