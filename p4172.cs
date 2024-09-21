#pragma warning disable CS8604, CS8602, CS8600

using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        Dictionary<int, int> dp = new();
        dp[0] = 1;
        while (true)
        {
            int n = int.Parse(Console.ReadLine());

            if (n == -1)
            {
                break;
            }

            Console.WriteLine(Find(n, dp));
        }
    }

    public static int Find(int i, Dictionary<int, int> dp)
    {
        if (dp.ContainsKey(i))
        {
            return dp[i];
        }
        return dp[i] = (Find((int)(i - Math.Sqrt(i)), dp) + Find((int)(Math.Log(i)), dp) + Find((int)(i * Math.Pow(Math.Sin(i), 2)), dp)) % 1000000;
    }
}
