using System;

/// <summary>
/// p2292 - 벌집, B2
/// 해결 날짜 : 2023/8/28
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        int s = int.Parse(Console.ReadLine());

        int moveCount = (int)Math.Ceiling(0.5 + (1.0 / 6.0) * Math.Sqrt(12.0 * s - 3.0));

        Console.WriteLine(moveCount);
    }
}
