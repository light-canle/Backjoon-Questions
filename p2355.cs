using System;
using System.Linq;

/// <summary>
/// p2355 - 시그마, B2
/// 해결 날짜 : 2023/10/11
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        long[] input = Console.ReadLine().Split().Select(long.Parse).ToArray();
        (long N, long M) = (input[0], input[1]);

        long min = (N < M) ? N : M;
        long max = (N == min) ? M : N;

        long neg_sum = 0;
        long pos_sum = 0;
        if (min < 0 && max < 0)
        {
            neg_sum = SumToOne(Math.Abs(min)) - SumToOne(Math.Abs(max + 1));
        }
        else if (min < 0 && max >= 0)
        {
            neg_sum = SumToOne(Math.Abs(min));
            pos_sum = SumToOne(max);
        }
        else
        {
            pos_sum = SumToOne(max) - SumToOne(min - 1);
        }
        Console.WriteLine(pos_sum - neg_sum);
    }

    public static long SumToOne(long n)
    {
        if (n <= 0) { return 0; }
        else { return n * (n + 1) / 2; }
    }
}