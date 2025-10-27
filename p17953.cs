#pragma warning disable CS8604, CS8602, CS8600

using System;
using System.Linq;
using System.Collections.Generic;

// p17953 - 디저트 (G5)
// #DP
// 2025.10.27 solved

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        int[] input = Array.ConvertAll(sr.ReadLine().Trim().Split(), int.Parse);
        int n = input[0], m = input[1];

        List<List<int>> satisfaction = new List<List<int>>();

        for (int i = 0; i < m; i++)
        {
            satisfaction.Add(sr.ReadLine().Split(' ').Select(int.Parse).ToList());
        }
        // dp[a, b] -> b+1번째 날에 a+1번 디저트를 먹었을 때의 최대 만족감
        int[,] dp = new int[m, n];
        // 처음은 그 디저트의 원래 만족감으로 초기화
        for (int i = 0; i < m; i++)
        {
            dp[i, 0] = satisfaction[i][0];
        }

        for (int i = 1; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                int maxSatisfaction = int.MinValue;
                for (int k = 0; k < m; k++)
                {
                    // 전 날 디저트와 동일하면 오늘 먹을 디저트의 만족감의 반을 빼준다.
                    maxSatisfaction = Math.Max(k == j ?
                       dp[k, i - 1] - 
                       (satisfaction[j][i] % 2 == 0 ? // 만족감이 홀수인 경우에는 소수점 버림을 해야 하므로 빼는 값은 1을 더한다.
                       satisfaction[j][i] / 2 : satisfaction[j][i] / 2 + 1) : dp[k, i - 1], 
                       maxSatisfaction);
                }
                dp[j, i] = maxSatisfaction + satisfaction[j][i];
            }
        }

        // 마지막 날에 모인 값 중 최댓값을 고른다.
        int maxValue = dp[0, n - 1];
        for (int i = 1; i < m; i++)
        {
            maxValue = Math.Max(maxValue, dp[i, n - 1]);
        }
        Console.WriteLine(maxValue);
        sr.Close();
    }
}
