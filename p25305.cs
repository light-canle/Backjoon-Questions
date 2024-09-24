using System;
using System.Linq;
using System.Collections.Generic;

/// <summary>
/// p25305 - 커트라인, B2
/// 해결 날짜 : 2024/3/27
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        int[] input = Console.ReadLine()!.Split().Select(int.Parse).ToArray();
        (int N, int k) = (input[0], input[1]);
        List<int> list = Console.ReadLine()!.Split().Select(int.Parse).ToList();

        list.Sort();
        list.Reverse();

        Console.WriteLine(list[k - 1]);
    }
}