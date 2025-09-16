#pragma warning disable CS8604, CS8602, CS8600

using System;

// p2460 - 지능형 기차 2 (B3)
// #사칙연산
// 2025.9.17 solved (9.16)

public class Program
{
    public static void Main(string[] args)
    {
        int current = 0;
        int maxPeople = 0;
        for (int i = 0; i < 10; i++)
        {
            int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            current += input[1] - input[0];
            maxPeople = Math.Max(maxPeople, current);
        }
        Console.WriteLine(maxPeople);
    }
}
