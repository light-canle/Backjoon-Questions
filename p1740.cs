using System;
using System.Numerics;

/// <summary>
/// p1740 - 거듭제곱, S4
/// 해결 날짜 : 2023/10/15
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        long N = long.Parse(Console.ReadLine());

        BigInteger result = 0;

        for (int i = 0; i < 41; i++)
        {
            long bit = N & 1;
            if (bit == 1)
                result += BigInteger.Pow(3, i);
            N = N >> 1;
        }
        Console.WriteLine(result.ToString());
    }
}