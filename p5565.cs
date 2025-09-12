using System;

// p5565 - 영수증 (B4)
// #사칙연산
// 2025.9.12 solved

public class Program
{
    public static void Main(string[] args)
    {
        int total = int.Parse(Console.ReadLine());
        int other = 0;
        for (int i = 0; i < 9; i++)
        {
            other += int.Parse(Console.ReadLine());
        }
        Console.WriteLine(total - other);
    }
}
