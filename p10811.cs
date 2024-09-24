using System;
using System.Linq;

/// <summary>
/// p10811 - 바구니 뒤집기, B2
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

            int low = cur[0] - 1, high = cur[1] - 1;

            while (low <= high)
            {
                int temp = bucket[low];
                bucket[low] = bucket[high];
                bucket[high] = temp;

                low++; high--;
            }
        }

        Console.WriteLine(string.Join(' ', bucket));
    }
}
