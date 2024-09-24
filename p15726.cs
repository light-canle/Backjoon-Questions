using System;
using System.Linq;

/// <summary>
/// p15726 - 이칙연산, B4
/// 해결 날짜 : 2023/9/10
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        long[] input = Console.ReadLine().Split().Select(long.Parse).ToArray();

        long ans1 = (long)(input[0] * input[1] / (double)input[2]);
        long ans2 = (long)((double)input[0] / input[1] * input[2]);

        Console.WriteLine((ans1 > ans2) ? ans1 : ans2);
    }
}