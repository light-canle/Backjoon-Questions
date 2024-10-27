using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new (new BufferedStream(Console.OpenStandardInput()));
        int n = int.Parse(sr.ReadLine());

        List<int> list = sr.ReadLine().Split().Select(int.Parse).ToList();

        int maxLen = MaxIncreasing(list);
        list.Reverse();
        maxLen = Math.Max(maxLen, MaxIncreasing(list));
        Console.WriteLine(maxLen);
    }

    public static int MaxIncreasing(List<int> list)
    {
        int maxLen = 0;
        int listCount = list.Count;
        int current = 0;
        int prev = 0;
        for (int i = 0; i < listCount; i++)
        {
            if (prev <= list[i])
                current++;
            else
            {
                maxLen = Math.Max(maxLen, current);
                current = 1;
            }
            prev = list[i];
        }
        return Math.Max(maxLen, current);
    }
}
