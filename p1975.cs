#pragma warning disable CS8604, CS8602, CS8600

using System;
using System.IO;
using System.Linq;

// p1975 - Number Game (B1)
// #정수론 #DP
// 2025.12.3 solved (12.2)

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput()));
        int t = int.Parse(sr.ReadLine());
        int[] dp = Enumerable.Repeat(-1, 1001).ToArray();
        for (int i = 0; i < t; i++)
        {
            int n = int.Parse(sr.ReadLine());
            if (dp[n] != -1)
            {
                sw.WriteLine(dp[n]);
                continue;
            }
            int count = 0;
            for (int j = 2; j <= n; j++)
            {
                int cur = n;
                while (cur % j == 0) { count++; cur /= j; }
            }
            sw.WriteLine(count);
        }
        sw.Flush(); sw.Close(); sr.Close();
    }
}
