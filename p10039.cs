using System;

/// <summary>
/// p10039 - 평균 점수, B4
/// 해결 날짜 : 2023/11/8
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        int scores = 0;
        for (int i = 0; i < 5; i++)
        {
            int input = int.Parse(Console.ReadLine()!);
            if (input < 40) scores += 40;
            else scores += input;
        }
        Console.WriteLine(scores / 5);
    }
}