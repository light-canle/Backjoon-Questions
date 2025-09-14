#pragma warning disable CS8604, CS8602, CS8600

using System;

// p3923 - 저울 (S2)
// #완전 탐색
// 2025.9.14 solved

public class Program
{
    public static void Main(string[] args)
    {
        while (true)
        {
            long[] input = Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
            long a = input[0], b = input[1], d = input[2];

            if (a == 0 && b == 0 && d == 0)
            {
                break;
            }

            long small = Math.Min(a, b);
            long large = Math.Max(a, b);

            int count = 1;
            bool done = false;
            while (!done)
            {
                for (int sCount = count; sCount >= 0; sCount--)
                {
                    long lCount = count - sCount;
                    long left = small * sCount;
                    long right = large * lCount;
                    if (Math.Abs(left - right) == d || left + right == d)
                    {
                        Console.WriteLine(a < b ? $"{sCount} {lCount}" : $"{lCount} {sCount}");
                        done = true;
                        break;
                    }
                }
                count++;
            }
        }
    }
}
