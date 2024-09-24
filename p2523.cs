using System;

/// <summary>
/// p2523 - 별 찍기 13, B3
/// 해결 날짜 : 2023/10/19
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());

        for (int i = 1; i <= N; i++)
        {
            string s = new string('*', i);
            Console.WriteLine(s);
        }
        for (int i = N - 1; i > 0; i--)
        {
            string s = new string('*', i);
            Console.WriteLine(s);
        }
    }
}