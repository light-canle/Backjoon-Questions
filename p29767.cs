using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new (new BufferedStream(Console.OpenStandardInput()));
        int[] input = sr.ReadLine().Split().Select(int.Parse).ToArray();

        int N = input[0], K = input[1];

        int[] arr = sr.ReadLine().Split().Select(int.Parse).ToArray();

        List<long> pSum = new();
        pSum.Add(0);
        for (int i = 1; i <= N; i++)
        {
            pSum.Add(pSum[i - 1] + arr[i - 1]);
        }
        pSum.RemoveAt(0);
        pSum.Sort();
        pSum.Reverse();

        long ret = 0;
        for (int i = 0; i < K; i++)
        {
            ret += pSum[i];
        }
        Console.WriteLine(ret);
        sr.Close();
    }
}
