#pragma warning disable CS8604, CS8602, CS8600

using System;

// p9469 - 폰 노이만 (B3)
// #사칙연산
// 2025.9.7 solved

public class Program
{
    public static void Main(string[] args)
    {
        int p = int.Parse(Console.ReadLine()!);

        for (int i = 1; i <= p; i++) 
        {
            double[] info = Array.ConvertAll(Console.ReadLine().Split(), double.Parse);
            double d = info[1], a = info[2], b = info[3], f = info[4];
            Console.WriteLine($"{i} {d / (a + b) * f}");
        }
    }
}
