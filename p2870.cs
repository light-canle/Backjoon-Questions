#pragma warning disable CS8604, CS8602

using System;
using System.Numerics;
using System.Collections.Generic;

// p2870 - 수학숙제 (S4)
// #문자열 #정렬
// 2025.11.23 solved

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        List<BigInteger> nums = new();
        for (int i = 0; i < n; i++)
        {
            string line = Console.ReadLine()!;
            string curNum = "";
            foreach (char c in line)
            {
                if ('0' <= c && c <= '9')
                {
                    curNum += c;
                }
                else if (curNum != "")
                {
                    nums.Add(BigInteger.Parse(curNum));
                    curNum = "";
                }
            }
            if (curNum != "") nums.Add(BigInteger.Parse(curNum));
        }
        nums.Sort();
        foreach (BigInteger num in nums)
        {
            Console.WriteLine(num);
        }
    }
}
