using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        List<int> arr = Console.ReadLine().Split().Select(int.Parse).ToList();

        int[] dp = new int[n];
        Find(arr, n, dp);
        arr.Reverse();
        int[] revDp = new int[n];
        Find(arr, n, revDp);

        int max = 0;
        for (int i = 0; i < n; i++)
        {
            max = Math.Max(max, dp[i] + revDp[n - i - 1] - 1);
        }
        Console.WriteLine(max);
    }

    public static void Find(List<int> arr, int n, int[] dp)
    {
        for (int i = 0; i < n; i++)
        {
            dp[i] = 1;
            for (int j = 0; j < i; j++)
            {
                if (arr[j] < arr[i])
                {
                    dp[i] = Math.Max(dp[i], dp[j] + 1);
                }
            }
        }
    }
}
