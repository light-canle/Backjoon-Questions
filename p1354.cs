using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

public class Program
{
  public static void Main(string[] args)
  {
    long[] input = Array.ConvertAll(Console.ReadLine().Split(), long.Parse);

    long n = input[0];
    long p = input[1];
    long q = input[2];
    long x = input[3];
    long y = input[4];

    Dictionary<long, long> dp = new();

    dp[0] = 1;
    long ans = Find(n, p, q, x, y, dp);

    Console.WriteLine(ans);
  }
  public static long Find(long n, long p, long q, long x, long y, Dictionary<long, long> dp)
  {
    if (n < 1)
    {
      return 1;
    } else if (dp.ContainsKey(n))
    {
      return dp[n];
    }
    return dp[n] = Find(n / p - x, p, q, x, y, dp) + Find(n / q - y, p, q, x, y, dp);
  }
}
