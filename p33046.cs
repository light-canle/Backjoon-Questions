using System;

// p33046 - Alea Iacta Est (B4)
// #사칙연산
// 2025.6.17 solved

public class Program
{
    public static void Main(string[] args)
    {
        int[] d1 = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        int[] d2 = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        int sum = d1[0] + d1[1] + d2[0] + d2[1];
        Console.WriteLine((sum - 2) % 4 + 1);
    }
}
