using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());

        List<int> square = new List<int>();

        for (int i = 1; i * i <= 50000; i++)
        {
            square.Add(i * i);
        }
        int[] dp = new int[50001];

        for (int i = 1; i <= 50000; i++)
        {
            dp[i] = 50000;
        }

        foreach (int i in square)
        {
            dp[i] = 1;
        }
        for (int i = 2; i <= 50000; i++)
        {
            dp[i] = Math.Min(dp[i], dp[i - 1] + 1);
            foreach (int j in square)
            {
                if (i + j <= 50000)
                    dp[i + j] = Math.Min(dp[i + j], dp[i] + 1);
            }
        }

        Console.WriteLine(dp[N]);
    }
}
