using System;
using System.Linq;
using System.Collections.Generic;

// p11024 - 더하기 4 (B3)
// #사칙연산
// 2025.6.9 solved

public class Program
{
    public static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine());
        for (int i = 0; i < t; i++)
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();
            Console.WriteLine(nums.Sum());
        }
    }
}
