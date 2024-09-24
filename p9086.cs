using System;

/// <summary>
/// p9086 - 문자열, B5
/// 해결 날짜 : 2023/9/27
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        for (int i = 0; i < N; i++)
        {
            string input = Console.ReadLine();
            Console.WriteLine($"{input[0]}{input[^1]}");
        }
    }
}