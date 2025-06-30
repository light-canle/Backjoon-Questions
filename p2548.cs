using System;
using System.Linq;
using System.Collections.Generic;

// p2548 - 대표 자연수 (S3)
// #완전 탐색
// 2025.6.30 solved

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        List<int> arr = Console.ReadLine().Split().Select(int.Parse).ToList();

        arr.Sort();
        int ans = arr[0];
        int minDiff = int.MaxValue;
        for (int c = arr[0]; c <= arr[n - 1]; c++)
        {
            int diff = 0;
            foreach (var v in arr)
            {
                diff += Math.Abs(v - c);
            }
            if (diff < minDiff)
            {
                ans = c;
                minDiff = diff;
            }
        }
        Console.WriteLine(ans);
    }
}
