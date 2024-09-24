using System;
using System.Linq;
using System.Numerics;

/// <summary>
/// p16395 - 파스칼의 삼각형, S5
/// 해결 날짜 : 2024/3/12
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        // input
        long[] input = Console.ReadLine()!.Split().Select(long.Parse).ToArray();
        (long N, long K) = (input[0], input[1]);

        Console.WriteLine(Combination(N - 1, K - 1));
    }

    public static BigInteger Combination(long N, long K)
    {
        if (K == 0) return 1;
        BigInteger numer = 1;
        for (long i = K + 1; i <= N; i++)
        {
            numer *= i;
        }
        BigInteger deno = 1;
        for (long i = 1; i <= N - K; i++)
        {
            deno *= i;
        }

        return numer / deno;
    }
}
