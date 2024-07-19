#pragma warning disable CS8604, CS8602, CS8600

using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int N = input[0], Q = input[1];

        List<int> tone = Console.ReadLine().Split().Select(int.Parse).ToList();

        List<int> diff = new List<int>();

        for (int i = 0; i < N - 1; i++)
        {
            diff.Add(Math.Abs(tone[i + 1] - tone[i]));
        }

        List<int> diffSum = new List<int>();

        int curSum = 0;
        diffSum.Add(0);

        for (int i = 0; i < N - 1; i++)
        {
            curSum += diff[i];
            diffSum.Add(curSum);
        }

        for (int i = 0; i < Q; i++)
        {
            int[] range = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int s = range[0] - 1, e = range[1] - 1;

            int part = diffSum[e] - diffSum[s];

            Console.WriteLine(part);
        }
    }
}
