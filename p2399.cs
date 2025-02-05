using System;

// p2399 - 거리의 합 (B2)
// #완전 탐색
// 2025.2.5 solved

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        long[] pos = Array.ConvertAll(Console.ReadLine().Split(), long.Parse);

        long distSum = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                distSum += Math.Abs(pos[i] - pos[j]);
            }
        }
        Console.WriteLine(distSum);
    }
}
