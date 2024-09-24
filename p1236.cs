using System;
using System.Linq;
using System.Collections.Generic;

/// <summary>
/// p1236 - 성 지키기, B1
/// 해결 날짜 : 2023/10/25
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        int[] size = Console.ReadLine()!.Split().Select(int.Parse).ToArray();
        (int N, int M) = (size[0], size[1]);

        List<string> list = new List<string>();
        for (int i = 0; i < N; i++)
        {
            string input = Console.ReadLine()!;
            list.Add(input);
        }

        int row_count = 0;
        int col_count = 0;

        for (int i = 0; i < N; i++)
        {
            if (!(list[i].Contains('X'))) row_count++;
        }

        for (int j = 0; j < M; j++)
        {
            bool contain = false;
            for (int k = 0; k < N; k++)
            {
                if (list[k][j] == 'X') contain = true;
            }
            if (!contain) col_count++;
        }

        Console.WriteLine(Math.Max(row_count, col_count));
    }
}