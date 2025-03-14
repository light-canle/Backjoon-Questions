using System;

// p14606 - 피자 (Small) (S5)
// #dp
// 2025.3.14 solved

public class Program
{
  public static void Main(string[] args)
  {
    int n = int.Parse(Console.ReadLine());
    int[] dp = new int[11];
    Console.WriteLine(Fun(dp, n));
  }
  public static int Fun(int[] dp, int n)
  {
    if (n == 1) return 0;
    if (dp[n] != 0) return dp[n];
    
    int half = n / 2;
    if (n % 2 == 0)
    {
      return dp[n] = half * half + Fun(dp, half) + Fun(dp, half);
    }
    else
    {
      return dp[n] = half * (half + 1) + Fun(dp, half) + Fun(dp, half + 1);
    }
  }
}
