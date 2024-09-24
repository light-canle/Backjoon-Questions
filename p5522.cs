using System;

/// <summary>
/// p5522 - 카드 게임, B5
/// 해결 날짜 : 2023/10/21
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        int sum = 0;
        for (int i = 0; i < 5; i++)
        {
            int input = int.Parse(Console.ReadLine()!);
            sum += input;
        }
        Console.WriteLine(sum);
    }
}