#pragma warning disable CS8604, CS8602, CS8600

using System;

// p28214 - 크림빵 (B3)
// #구현
// 2025.3.25 solved

public class Program
{
    public static void Main(string[] args)
    {
        int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        int n = input[0], k = input[1], p = input[2];

        int[] cream = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        int canSell = 0;
        for (int i = 0; i < n; i++)
        {
            int notCream = 0;
            for (int j = 0; j < k; j++)
            {
                if (cream[j + i * k] == 0) notCream++;
            }
            if (notCream < p) 
            {
                canSell++;
            }
        }
        Console.WriteLine(canSell);
    }
}
