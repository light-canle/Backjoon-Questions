using System;

/// <summary>
/// p9625 - BABBA, S5
/// 해결 날짜 : 2023/10/6
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        int input = int.Parse(Console.ReadLine());
        long countA = 1;
        long countB = 0;
        for (int i = 1; i <= input; i++)
        {
            long temp = countB;
            countB += countA;
            countA += temp - countA;
        }
        Console.WriteLine($"{countA} {countB}");
    }
}