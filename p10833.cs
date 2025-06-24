using System;

// p10833 - 사과 (B3)
// #사칙연산
// 2025.6.24 solved

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        int remain = 0;
        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split();
            int a = int.Parse(input[0]);
            int b = int.Parse(input[1]);
            remain += b % a;
        }
        Console.WriteLine(remain);
    }
}
