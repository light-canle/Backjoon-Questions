using System;
using System.Numerics;

/// <summary>
/// p27433 - 팩토리얼 2, B5
/// 해결 날짜 : 2024/3/31
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine()!);
        Console.WriteLine(Factorial(N));
    }

    public static BigInteger Factorial(int n)
    {
        if (n == 0 || n == 1) return BigInteger.One;
        return n * Factorial(n - 1);
    }
}