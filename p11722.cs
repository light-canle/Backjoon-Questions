using System;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int[] LDS = new int[N];
        for (int i = 0; i < N; i++)
        {
            LDS[i] = 1;
            for (int j = 0; j < i; j++)
            {
                if (nums[i] < nums[j])
                {
                    LDS[i] = Math.Max(LDS[i], LDS[j] + 1);
                }
            }
        }
        Console.WriteLine(LDS.Max());
    }
}
