using System;

public class Program
{
    public static int[,] dp;
    public static void Main(string[] args)
    {
        int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        int n = input[0], k = input[1];

        dp = new int[n + 1, n + 1];

        for (int i = 1; i <= n; i++){
            dp[i, 0] = 1;
            dp[i, i] = 1;
        }
        Console.WriteLine(Combination(n, k));
    }

    public static int Combination(int n, int k)
    {
        if (dp[n, k] != 0) return dp[n, k];
        return dp[n, k] = (Combination(n - 1, k) + Combination(n - 1, k - 1)) % 10007;
    }
}
