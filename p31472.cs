#pragma warning disable CS8604, CS8602, CS8600

using System;

// p31472 - 갈래의 색종이 자르기 (B3)
// #수학
// 2025.11.13 solved

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int length = (int)(Math.Sqrt(2 * n));
        Console.WriteLine(4 * length);
    }
}
