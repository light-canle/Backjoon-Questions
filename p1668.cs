using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        List<int> heights = new();

        for (int i = 0; i < n; i++)
        {
            heights.Add(int.Parse(Console.ReadLine()));
        }
        Console.WriteLine(CanSee(heights));
        heights.Reverse();
        Console.WriteLine(CanSee(heights));
    } 

    public static int CanSee(List<int> heights)
    {
        int canSee = 0;
        int curMax = 0;
        int count = heights.Count;
        for (int i = 0; i < count; i++)
        {
            if (heights[i] > curMax)
            {
                canSee++;
                curMax = heights[i];
            }
        }
        return canSee;
    }
}
