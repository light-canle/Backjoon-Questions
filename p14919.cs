#pragma warning disable CS8604, CS8602, CS8600

using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        int M = int.Parse(sr.ReadLine().Trim());
        double[] l = Array.ConvertAll(sr.ReadLine().Trim().Split(), double.Parse);
        List<double> s = l.ToList();

        s.Sort();
        int N = s.Count;
        int[] count = new int[M];

        int index = 0;
        for (int i = 0; i < M; i++)
        {
            while (index < N && s[index] < (double)(i + 1) / M)
            {
                count[i]++;
                index++;
            }
            if (index >= N) break;
        }
        Console.WriteLine(string.Join(" ", count));
        sr.Close();
    }
}
