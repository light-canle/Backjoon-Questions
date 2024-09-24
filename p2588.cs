using System;

/// <summary>
/// p2588 - 곱셈, B3
/// 해결 날짜 : 2023/11/22
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);
        int m = int.Parse(Console.ReadLine()!);

        int d1 = m / 100;
        int d2 = (m % 100) / 10;
        int d3 = (m % 10);
        Console.WriteLine($"{n * d3}\n{n * d2}\n{n * d1}\n{n * m}");
    }
}