using System;

// p15489 - 파스칼 삼각형 (S4)
// #dp #조합론
// 2025.8.17 solved

public class Program
{
    public static void Main(string[] args)
    {
        int[] input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        int r = input[0], c = input[1], w = input[2];
        long[,] dp = new long[32, 32];
        dp[0, 0] = dp[1, 0] = dp[1, 1] = 1;
        // nCr 정의
        for (int i = 2; i < 32; i++)
        {
            for (int j = 0; j <= i; j++)
            {
                if (j == 0 || j == i) dp[i, j] = 1;
                else
                {
                    dp[i, j] = dp[i - 1, j - 1] + dp[i - 1, j];
                }
            }
        }
        long result = 0;
        for (int i = 0; i < w; i++)
        {
            for (int j = 0; j <= i; j++)
            {
                result += dp[r - 1 + i, c - 1 + j];
            }
        }
        Console.WriteLine(result);
    }
}
