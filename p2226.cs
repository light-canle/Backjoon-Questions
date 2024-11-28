using System;
using System.Numerics;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        List<BigInteger> dp = new List<BigInteger>();
        dp.Add(0);

        for (int i = 1; i < n; i++)
        {
            var prev = dp[i - 1];
            if (i % 2 == 1)
            {
                dp.Add(2 * prev + 1);
            }
            else
            {
                dp.Add(2 * prev - 1);
            }
        }
        Console.WriteLine(dp[n - 1]);
    }
}
