using System;
using System.Numerics;

public class Program
{
    public static void Main(string[] args)
    {
        long[] input = Array.ConvertAll(Console.ReadLine().Split(), long.Parse);

        long a = input[0], b = input[1];

        BigInteger sum = SumPowTwo(b) - SumPowTwo(a - 1);

        Console.WriteLine(sum);
    }

    public static BigInteger SumPowTwo(long n)
    {
        BigInteger sum = 0;

        for (int i = 0; i <= 50; i++)
        {
            sum += ((BigInteger)n + BigInteger.Pow(2, i)) / BigInteger.Pow(2, i + 1) * BigInteger.Pow(2, i);
        }

        return sum;
    }
}
