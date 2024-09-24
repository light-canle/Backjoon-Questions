#pragma warning disable CS8604, CS8602, CS8600

using System;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int[] heights = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        int maxHeight = 0;
        int curMin = heights[0], prev = heights[0];
        int curLen = 1;

        for (int i = 1; i < n; i++)
        {
            if (heights[i] <= prev) 
            {
                curLen = 1;
                maxHeight = Math.Max(maxHeight, prev - curMin);
                curMin = heights[i];
            }
            else
            {
                curLen++;
            }
            prev = heights[i];
        }

        maxHeight = Math.Max(maxHeight, heights[n - 1] - curMin);
        Console.WriteLine(maxHeight);
    }
}
