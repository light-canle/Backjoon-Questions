using System;
using System.Numerics;

/// <summary>
/// p2338 - 긴자리 계산, B5
/// 해결 날짜 : 2023/10/17
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        BigInteger A = BigInteger.Parse(Console.ReadLine());
        BigInteger B = BigInteger.Parse(Console.ReadLine());

        Console.WriteLine(A + B);
        Console.WriteLine(A - B);
        Console.WriteLine(A * B);
    }
}