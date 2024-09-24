using System;
using System.Linq;

/// <summary>
/// p10810 - 공 넣기, B3
/// 해결 날짜 : 2024/3/26
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        int[] input = Console.ReadLine()!.Split().Select(int.Parse).ToArray();

        (int N, int M) = (input[0], input[1]);
        int[] bucket = new int[N];

        for (int i = 0; i < M; i++)
        {
            int[] cur = Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            for (int j = cur[0]; j <= cur[1]; j++)
            {
                bucket[j - 1] = cur[2];
            }
        }

        Console.WriteLine(string.Join(' ', bucket));
    }
}