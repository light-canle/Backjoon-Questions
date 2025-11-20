#pragma warning disable CS8604, CS8602

using System;
using System.IO;

// p12847 - 꿀 아르바이트 (S3)
// #누적 합
// 2025.11.20 solved

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        int n = input[0], m = input[1];

        long[] pay = Array.ConvertAll(sr.ReadLine().Split(), long.Parse);
        
        long[] psum = new long[n + 1];
        long curSum = 0;
        for (int i = 1; i <= n; i++)
        {
            curSum += pay[i - 1];
            psum[i] = curSum;
        }

        // 연속된 m일의 일급의 합이 최대인 구간을 찾는다.
        long maxPay = 0;
        for (int i = m; i <= n; i++)
        {
            maxPay = Math.Max(maxPay, psum[i] - psum[i - m]);
        }
        Console.WriteLine(maxPay);
        sr.Close();
    }
}
