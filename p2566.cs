using System;
using System.Linq;
using System.Collections.Generic;

/// <summary>
/// p2566 - 최댓값, B3
/// 해결 날짜 : 2024/3/26
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        List<List<int>> list = new List<List<int>>();
        for (int i = 0; i < 9; i++)
        {
            int[] input = Console.ReadLine()!.Split().Select(int.Parse).ToArray();
            list.Add(input.ToList());
        }

        int max = list[0][0];
        int y = 1, x = 1;

        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (list[i][j] > max)
                {
                    y = i + 1;
                    x = j + 1;
                    max = list[i][j];
                }
            }
        }

        Console.WriteLine(max);
        Console.WriteLine($"{y} {x}");
    }
}