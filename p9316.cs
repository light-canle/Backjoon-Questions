using System;

// p9316 - Hello Judge (B4)
// #구현
// 2025.5.20 solved

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 1; i <= n; i++)
        {
            Console.WriteLine($"Hello World, Judge {i}!");
        }
    }
}
