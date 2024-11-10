using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        List<int> nums = new();

        for (int i = 1; i <= 6; i++)
        {
            Generate(nums, 0, i);
        }

        int n = int.Parse(Console.ReadLine());

        int idx = 0;
        while (nums[idx] < n && idx < nums.Count - 1)
        {
            idx++;
        }

        if (nums[idx] > n) idx--;
        Console.WriteLine(nums[idx]);
    }

    public static void Generate(List<int> nums, int num, int left)
    {
        if (left == 0)
        {
            nums.Add(num);
            return;
        }
        Generate(nums, num * 10 + 4, left - 1);
        Generate(nums, num * 10 + 7, left - 1);
    }
}
