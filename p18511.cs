using System;
using System.Linq;
using System.Collections.Generic;

// p18511 - 큰 수 구성하기 (S5)
// #재귀 #완전 탐색
// 2025.3.30 solved

public class Program
{
    public static void Main(string[] args)
    {
        int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        
        int n = input[0], k = input[1];
        int[] list = Console.ReadLine().Split().Select(int.Parse).ToArray();

        List<int> nums = new();
        for (int i = 1; i <= 9; i++)
        {
            GenNumber(i, "", list, nums);
        }
        nums.Sort();

        int idx = 0;
        while (nums[idx] <= n)
        {
            idx++;
        }
        Console.WriteLine(nums[idx - 1]);
    }

    // 각 자리가 list의 수인 자릿수가 digit인 수를 생성
    public static void GenNumber(int digit, string n, int[] list, List<int> nums)
    {
        if (digit == 0)
        {
            nums.Add(int.Parse(n));
            return; 
        }

        for (int i = 0; i < list.Length; i++)
        {
            n += list[i].ToString();
            GenNumber(digit - 1, n, list, nums);
            n = n.Substring(0, n.Length - 1);
        }
    }
}
