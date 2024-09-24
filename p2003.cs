using System;
using System.IO;
using System.Linq;

/// <summary>
/// p2003 - 수들의 합 2, S4
/// 해결 날짜 : 2023/10/23
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        int[] inputs = sr.ReadLine()!.Split().Select(int.Parse).ToArray();
        (int N, int M) = (inputs[0], inputs[1]);

        int cur_sum = 0;
        int[] sums = new int[N + 1];
        int[] list = sr.ReadLine()!.Split().Select(int.Parse).ToArray();
        // 부분합 저장
        for (int i = 1; i < N + 1; i++)
        {
            cur_sum += list[i - 1];
            sums[i] = cur_sum;
        }

        long count = 0;
        for (int i = 1; i < N + 1; i++) // N이 아닌 N+1까지 해야 마지막 항의 값이 계산된다.
        {
            for (int j = i; j < N + 1; j++)
            {
                int part_sum = sums[j] - sums[i - 1]; // i ~ j번째 까지의 합
                if (part_sum == M) { count++; }
            }
        }

        Console.WriteLine(count);
        sr.Close();
    }
}