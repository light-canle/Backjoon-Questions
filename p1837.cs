#pragma warning disable CS8604, CS8602, CS8600

using System;
using System.Numerics;

// p1837 - 암호제작 (B3)
// #완전 탐색 #큰 수 연산
// 2025.10.10 solved

public class Program
{
    public static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split();

        BigInteger n = BigInteger.Parse(input[0]);
        BigInteger k = BigInteger.Parse(input[1]);

        bool isSafe = true;
        BigInteger div = 0;
        for (BigInteger s = 2; s < k; s++)
        {
            if (n % s == 0)
            {
                isSafe = false;
                div = s;
                break;
            }
        }
        Console.WriteLine(isSafe ? "GOOD" : $"BAD {div}");
    }
}
