using System;
using System.Linq;

/// <summary>
/// p10813 - 공 바꾸기, B2
/// 해결 날짜 : 2024/3/26
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        int[] input = Console.ReadLine()!.Split().Select(int.Parse).ToArray();

        (int N, int M) = (input[0], input[1]);
        int[] bucket = new int[N];

        for (int i = 0; i < N; i++)
        {
            bucket[i] = i + 1;
        }

        for (int i = 0; i < M; i++)
        {
            int[] cur = Console.ReadLine()!.Split().Select(int.Parse).ToArray();
            int temp = bucket[cur[0] - 1];
            bucket[cur[0] - 1] = bucket[cur[1] - 1];
            bucket[cur[1] - 1] = temp;
        }

        Console.WriteLine(string.Join(' ', bucket));
    }
}