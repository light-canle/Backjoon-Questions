using System;

/// <summary>
/// p2420 - 사파리월드, B5
/// 해결 날짜 : 2023/9/17
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        long [] input = Console.ReadLine().Split().Select(long.Parse).ToArray();
        Console.WriteLine(Math.Abs(input[0] - input[1]));
    }
}