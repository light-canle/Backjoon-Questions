using System;
using System.Numerics;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections.Generic;

// p30468 - 호반우가 학교에 지각한 이유 1 (B4)
// #사칙연산
// 2025.5.6 solved

public class Program
{
    public static void Main(string[] args)
    {
        int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        int sum = input[0] + input[1] + input[2] + input[3];
        int n = input[4];

        Console.WriteLine(sum >= n * 4 ? 0 : n * 4 - sum);
    }
}
