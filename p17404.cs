using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        int count = int.Parse(Console.ReadLine());
        List<List<int>> cost = new();

        for (int i = 0; i < count; i++)
        {
            cost.Add(Console.ReadLine().Split(' ').Select(int.Parse).ToList());
        }
        int[,] dp = new int[count, 3];
        dp[0, 0] = cost[0][0];
        dp[0, 1] = cost[0][1];
        dp[0, 2] = cost[0][2];
        int minCost = int.MaxValue;

        for (int i = 0; i < 3; i++)
        {
            for (int j = 1; j < count; j++)
            {
                dp[j, 0] = Math.Min(dp[j - 1, 1], dp[j - 1, 2]) + cost[j][0];
                dp[j, 1] = Math.Min(dp[j - 1, 0], dp[j - 1, 2]) + cost[j][1];
                dp[j, 2] = Math.Min(dp[j - 1, 0], dp[j - 1, 1]) + cost[j][2];
                if (j == 1 || j == count - 1)
                {
                    if (j == 1)
                    {
                        for (int k = 0; k < 3; k++)
                            dp[j, k] = cost[0][i] + cost[1][k];
                    }
                    dp[j, i] = 1000001;
                }
            }

            minCost = Math.Min(Math.Min(minCost, dp[count - 1, 0]), Math.Min(dp[count - 1, 1], dp[count - 1, 2]));
        }
        Console.WriteLine(minCost);
    }
}
