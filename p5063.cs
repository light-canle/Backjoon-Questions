#pragma warning disable CS8604, CS8602, CS8600

using System;

// p5063 - TGN (B3)
// #사칙연산
// 2025.11.30 solved

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            int[] k = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int advertiseProfit = (k[1] - k[2]) - k[0];
            if (advertiseProfit > 0)
            {
                Console.WriteLine("advertise");
            }
            else if (advertiseProfit == 0)
            {
                Console.WriteLine("does not matter");
            }
            else
            {
                Console.WriteLine("do not advertise");
            }
        }
    }
}
