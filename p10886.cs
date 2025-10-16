#pragma warning disable CS8604, CS8602, CS8600

using System;

// p10886 - 0 = not cute / 1 = cute (B3)
// #구현
// 2025.10.16 solved

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int zeros = 0, ones = 0;
        for (int i = 0; i < n; i++)
        {
            int survey = int.Parse(Console.ReadLine());
            if (survey == 0) zeros++;
            else ones++;
        }
        Console.WriteLine(zeros < ones ? "Junhee is cute!" : "Junhee is not cute!");
    }
}
