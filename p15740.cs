#pragma warning disable CS8604, CS8602

using System;
using System.Numerics;

// p15740 - A+B - 9
// #사칙연산
// 2025.11.23 solved (11.22)

public class Program
{
    public static void Main(string[] args)
    {
        BigInteger[] input = Array.ConvertAll(Console.ReadLine().Split(), BigInteger.Parse);
        Console.WriteLine(input[0] + input[1]);
    }
}
