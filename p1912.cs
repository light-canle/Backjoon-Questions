using System;

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int[] arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        int[] dp = new int[n];
        dp[0] = arr[0];
        for (int i = 1; i < n; i++)
        {
            dp[i] = Math.Max(dp[i - 1] + arr[i], arr[i]);
        }

        int max = dp[0];

        for (int i = 1; i < n; i++)
        {
            max = Math.Max(max, dp[i]);
        }
        Console.WriteLine(max);
    }
}
