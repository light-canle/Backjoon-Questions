using System;
using System.Numerics;

/// <summary>
/// p10757 - 큰 수 A+B, B5
/// 해결 날짜 : 2023/11/25 (solved.ac 기준 11/24)
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        string[] n = Console.ReadLine()!.Split();

        BigInteger a = BigInteger.Parse(n[0]);
        BigInteger b = BigInteger.Parse(n[1]);
        Console.WriteLine(a + b);
    }
}