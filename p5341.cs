using System;

/// <summary>
/// p5341 - Pyramids, B5
/// 해결 날짜 : 2023/11/8(solved.ac 기준 11/7)
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        while (true)
        {
            int N = int.Parse(Console.ReadLine()!);
            if (N == 0) { break; }
            else
            {
                Console.WriteLine(N * (N + 1) / 2);
            }
        }
    }
}