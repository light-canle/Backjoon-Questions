using System;

// p14494 - 다이나믹이 뭐예요? (S3)
// #DP
// 2025.4.26 solved

public class Program
{
    public static long[,] dp;
    public static void Main(string[] args)
    {
        int[] pos = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        int x = pos[0], y = pos[1];

        dp = new long[1001, 1001];
        // (1,1) ~ (1000, 1000)을 -1로 초기화
        for (int i = 1; i < 1001; i++)
        {
            for (int j = 1; j < 1001; j++)
            {
                dp[i, j] = -1;
            }
        }
        // (1, 1) -> (1, 1)로 가는 길은 1가지이다.
        dp[1, 1] = 1;
        Console.WriteLine(RoadNumber(x, y));
    }

    public static long RoadNumber(int x, int y)
    {
        if (x == 0 || y == 0) return 0;
        // 메모이제이션
        if (dp[x, y] != -1) return dp[x, y];
        // (x, y)로 가는 경우의 수는 (x - 1, y), (x, y - 1), (x - 1, y - 1)로 가는 경우의 수를 합한 것과 같다.
        return dp[x, y] = (RoadNumber(x - 1, y) + RoadNumber(x, y - 1) + RoadNumber(x - 1, y - 1)) % 1_000_000_007;
    }
}
