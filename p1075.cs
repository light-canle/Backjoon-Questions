using System;

/// <summary>
/// p1075 - 나누기, B2
/// 해결 날짜 : 2023/8/31
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        int F = int.Parse(Console.ReadLine());

        int answer = 0;
        for (int i = 0; i < 100; i++)
        {
            int candidate = N - N % 100;
            candidate += i;
            if (candidate % F == 0)
            {
                answer = i;
                break;
            }
        }
        Console.WriteLine($"{answer:D2}");
    }
}
