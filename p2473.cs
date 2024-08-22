using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        int count = int.Parse(Console.ReadLine());
        List<long> arr = Console.ReadLine().Split().Select(long.Parse).ToList();
        arr.Sort();
        long minDiff = 3_000_000_001;
        long k1 = 0, k2 = 0, k3 = 0;
        for (int i = 0; i < count; i++)
        {
            int p1 = 0, p2 = count - 1;
            while (p1 < p2)
            {
                if (p1 == i) 
                {
                    p1++;
                    continue;
                }
                if (p2 == i)
                {
                    p2--;
                    continue;
                }
                long sum = arr[p1] + arr[p2] + arr[i];

                if (Math.Abs(sum) < minDiff)
                {
                    minDiff = Math.Abs(sum);
                    k1 = arr[p1];
                    k2 = arr[p2];
                    k3 = arr[i];
                }
                if (sum < 0) p1++;
                else p2--;
            }
        }
        List<long> ret = new List<long>(new long[] {k1, k2, k3});
        ret.Sort();
        Console.WriteLine(string.Join(" ", ret));
    }
}
