using System;

// p3004 - 체스판 조각 (B3)
// #구현
// 2025.7.6 solved

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int half = n / 2;
        if (n % 2 == 0)
            Console.WriteLine((half + 1) * (half + 1));
        else
            Console.WriteLine((half + 1) * (half + 2));
    }
}
