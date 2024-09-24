using System;
using System.Linq;
using System.Collections.Generic;

/// <summary>
/// p1547 - 공, B3
/// 해결 날짜 : 2023/11/21 (solved.ac 기준 11/20)
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine()!);
        List<int> cups = Enumerable.Range(1, 3).ToList();
        for (int i = 0; i < N; i++)
        {
            int[] input = Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            (int x, int y) = (input[0], input[1]);

            if (x != y)
            {
                int xi = cups.IndexOf(x);
                int yi = cups.IndexOf(y);

                int temp = cups[xi];
                cups[xi] = cups[yi];
                cups[yi] = temp;
            }
        }
        Console.WriteLine(cups[0]);
    }
}