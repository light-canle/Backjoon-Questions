using System;
using System.IO;

// p16401 - 과자 나눠주기 (S2)
// #이분 탐색
// 2025.4.18 solved

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new (new BufferedStream(Console.OpenStandardInput()));
        int[] c = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

        int m = c[0], n = c[1];

        long[] l = Array.ConvertAll(sr.ReadLine().Split(), long.Parse);

        long sum = l.Sum();
        if (m > sum)
        {
            Console.WriteLine(0);
            return;
        }
        
        long low = 1, high = 1_000_000_000;
        while (Math.Abs(high - low) > 1)
        {
            long mid = (low + high) / 2;
            long count = 0;
            for (int i = 0; i < n; i++)
            {
                count += l[i] / mid;
            }
            if (count >= m)
            {
                low = mid;
            }
            else
            {
                high = mid - 1;
            }
        }
        long cl = 0;
        for (int i = 0; i < n; i++)
        {
            cl += l[i] / high;
        }
        if (cl >= m)
        {
            Console.WriteLine(high);
        }
        else
        {
            Console.WriteLine(low);
        }
    }
}
