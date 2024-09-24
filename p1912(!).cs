using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// p1912 - 연속 합, S2
/// </summary>

// 미해결 문제

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        int N = int.Parse(sr.ReadLine()!);

        int[] list = sr.ReadLine()!.Split().Select(int.Parse).ToArray();

        int cur_sum = 0;
        int[] sums = new int[N + 1];
        sums[0] = 0;
        for (int i = 0; i < list.Length; i++)
        {
            cur_sum += list[i];
            sums[i + 1] = cur_sum;
        }

        Console.WriteLine(string.Join(" ", sums));

        int max = sums[1], max_pos = 1;
        for (int i = 2; i < sums.Length; i++)
        {
            if (sums[i] >= max)
            {
                max = sums[i];
                max_pos = i;
            }
        }

        int min_before_max = sums[1];
        for (int i = 2; i < max_pos; i++)
        {
            if (sums[i] < min_before_max)
            {
                min_before_max = sums[i];
            }
        }

        Console.WriteLine(max - min_before_max);

        sr.Close();
    }
}