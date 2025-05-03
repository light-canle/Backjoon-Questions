using System;
using System.Numerics;

// p24416 - 알고리즘 수업 - 피보나치 수 1 (B1)
// #DP
// 2025.5.4 solved

public class Program
{
    public static BigInteger[] dp;
    public static void Main(string[] args)
    {
        // dp 초기화
        dp = new BigInteger[41];
        dp[1] = dp[2] = 1;
        for (int i = 3; i < 41; i++)
        {
            dp[i] = -1;
        }

        int n = int.Parse(Console.ReadLine());
        Console.WriteLine($"{Fibonacci(n)} {n - 2}");
    }
    public static BigInteger Fibonacci(int n)
    {
        if (dp[n] != -1)
        {
            return dp[n];
        }
        return dp[n] = Fibonacci(n - 1) + Fibonacci(n - 2);
    }
}
