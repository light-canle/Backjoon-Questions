#pragma warning disable CS8604, CS8602, CS8600

using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        int n = int.Parse(sr.ReadLine());
        Dictionary<long, int> count = new Dictionary<long, int>();

        for (int i = 0; i < n; i++)
        {
            long k = long.Parse(sr.ReadLine());
            if (count.ContainsKey(k))
                count[k]++;
            else
                count[k] = 1;
        }

        long maxValue = 0;
        int maxCount = 0;

        foreach (var k in count.Keys)
        {
            if (count[k] > maxCount)
            {
                maxValue = k;
                maxCount = count[k];
            }
            else if (count[k] == maxCount) 
            { 
                maxValue = Math.Min(k, maxValue);
            }
        }

        Console.WriteLine(maxValue);
        sr.Close();
    }
}
