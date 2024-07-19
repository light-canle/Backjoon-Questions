#pragma warning disable CS8604, CS8602, CS8600

using System;
using System.Linq;
using System.IO;

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

        int N = input[0], M = input[1];

        int[] list = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

        long[] prefix = new long[N + 1];
        long curSum = 0;
        
        for (int i = 0; i < N; i++)
        {
            curSum += list[i];
            prefix[i + 1] = curSum;
        }

        long[] reCount = new long[M];

        for (int i = 0; i < N + 1; i++)
        {
            reCount[prefix[i] % M]++;
        }

        long count = 0;
        for (int i = 0; i < M; i++)
        {
            if (reCount[i] >= 1)
            {
                count += (reCount[i] * (reCount[i] - 1) / 2);
            }
        }

        Console.WriteLine(count);
        sr.Close();
    }
}
