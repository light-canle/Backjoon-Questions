#pragma warning disable CS8604, CS8602, CS8600

using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

// p11048 - 이동하기 (S2)
// #DP
// 2025.10.19 solved

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        int n = input[0], m = input[1];

        List<List<int>> list = new();

        for (int i = 0; i < n; i++)
        {
            list.Add(sr.ReadLine().Split().Select(int.Parse).ToList());
        }
        // dp[i, j] -> (1,1)에서 (i, j)까지 올 때 최대로 주울 수 있는 사탕의 수 (0으로 초기화)
        int[,] dp = new int[n + 1, m + 1];
        // 위쪽, 왼쪽, 왼쪽 위 대각선 칸에서 가장 사탕을 많이 가져올 수 있는 칸을 선택한 후 현재 칸의 사탕 개수를 더함
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= m; j++)
            {
                dp[i, j] = list[i - 1][j - 1] + Math.Max(Math.Max(dp[i - 1, j], dp[i, j - 1]), dp[i - 1, j - 1]);
            }
        }

        Console.WriteLine(dp[n, m]);
        sr.Close();
    }
}
