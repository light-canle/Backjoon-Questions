using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));

        Dictionary<long, int> exp = new();
        long k = 1;
        for (int i = 0; i < 63; i++)
        {
            exp[k] = i;
            k *= 2;
        }

        int n = int.Parse(sr.ReadLine());
        List<long> list = sr.ReadLine().Trim().Split().Select(long.Parse).ToList();

        int[] count = new int[63];
        for (int i = 0; i < n; i++)
        {
            if (list[i] > 0)
            {
                count[exp[list[i]]]++;
            }
        }

        int ans = 0;
        for (int i = 0; i < 63; i++)
        {
            if (count[i] > 0)
            {
                ans = i;
            }
            if (i != 62 && count[i] >= 2)
            {
                int mergeCount = count[i] / 2;
                count[i] -= mergeCount * 2;
                count[i + 1] += mergeCount;
            }
        }
        long ret = 1;
        for (int i = 0; i < ans; i++)
        {
            ret *= 2;
        }
        Console.WriteLine(ret);
        sr.Close();
    }
}
