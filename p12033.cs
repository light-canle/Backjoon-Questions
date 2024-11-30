using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine());
        for (int i = 1; i <= t; i++)
        {
            int n = int.Parse(Console.ReadLine());
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();

            List<int> result = new List<int>();
            while (nums.Count > 0)
            {
                int last = nums[nums.Count - 1];
                nums.RemoveAt(nums.Count - 1);
                int toFind = nums.LastIndexOf(last / 4 * 3);
                result.Add(last / 4 * 3);
                nums.RemoveAt(toFind);
            }
            result.Reverse();
            Console.WriteLine($"Case #{i}: " + string.Join(" ", result));
        }
    }
}
