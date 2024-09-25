#pragma warning disable CS8604, CS8602, CS8600

using System;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            int[] nums = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int l = nums.Length;

            long sum = 0;
            for (int j = 1; j < l - 1; j++)
            {
                for (int k = j + 1; k < l; k++)
                {
                    sum += GCD(nums[j], nums[k]);
                }
            }

            Console.WriteLine(sum);
        }
    }

    public static int GCD(int a, int b)
    {
        if (b == 0) return a;
        return GCD(b, a % b);
    }
}
