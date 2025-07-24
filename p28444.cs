using System;

// p28444 - HI-ARC=? (B5)
// #사칙연산
// 2025.7.24 solved

public class Program
{
    public static void Main(string[] args)
    {
        int[] nums = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        Console.WriteLine(nums[0] * nums[1] - nums[2] * nums[3] * nums[4]);
    }
}
