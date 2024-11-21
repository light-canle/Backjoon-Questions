using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        List<int> nums = new List<int>();
        for (int i = 1; i < 10; i++)
        {
            Make47(nums, "", i);
        }
        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

        int a = arr[0], b = arr[1];
        Console.WriteLine(Count(nums, b) - Count(nums, a - 1));
    }

    public static int Count(List<int> nums, int n)
    {
        int count = 0;
        int limit = nums.Count;

        while (count < limit  && nums[count] <= n) count++;
        
        return count;
    }

    public static void Make47(List<int> nums, string cur, int left)
    {
        if (left == 0)
        {
            nums.Add(int.Parse(cur));
            return;
        }
        Make47(nums, cur + "4", left - 1);
        Make47(nums, cur + "7", left - 1);
    }
}
