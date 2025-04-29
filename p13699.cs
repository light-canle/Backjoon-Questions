using System;
using System.Numerics;

// p13699 - 점화식 (S4)
// #DP #재귀
// 2025.4.29 solved

public class Program
{
    public static BigInteger[] dp;
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        dp = new BigInteger[36];
        dp[0] = 1;
        Console.WriteLine(T(n));
    }

    public static BigInteger T(int n)
    {
        if (dp[n] != 0)
        {
            return dp[n];
        }
        BigInteger ret = 0;
        // t(n) = t(0)t(n-1) + t(1)t(n-2) + ... + t(n-1)t(0)
        for (int i = 0; i < n; i++)
        {
            ret += T(i) * T(n - 1 - i);
        }
        return dp[n] = ret;
    }
}
