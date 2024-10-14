using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        int n = input[0];
        int c = input[1];
        int w = input[2];
        List<int> lengths = new();
        for (int i = 0; i < n; i++)
        {
            lengths.Add(int.Parse(Console.ReadLine()));
        }
        int maxLen = lengths.Max();
        long maxProfit = long.MinValue;
        for (int cur = 1; cur <= maxLen; cur++)
        {
            int count = 0;
            int cut = 0;
            for (int i = 0; i < n; i++)
            {
                if (lengths[i] == cur)
                {
                    count++;
                }
                else if (lengths[i] > cur)
                {
                    int gain = lengths[i] / cur;
                    int toCut = lengths[i] % cur == 0 ? gain - 1 : gain;
                    if ((long)toCut * c < (long)gain * w * cur)
                    {
                        count += gain;
                        cut += toCut;
                    }
                }
            }
            long profit = (long)count * cur * w - (long)cut * c;
            maxProfit = Math.Max(maxProfit, profit);
        }
        Console.WriteLine(maxProfit);
    }
}
