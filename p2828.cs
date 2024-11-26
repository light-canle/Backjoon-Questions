using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int n = size[0], m = size[1];
        int l = 1, r = l + m - 1;
        int count = int.Parse(Console.ReadLine());

        int dist = 0;
        for (int i = 0; i < count; i++)
        {
            int cur = int.Parse(Console.ReadLine());
            if (l <= cur && cur <= r) continue;
            else if (cur < l)
            {
                dist += l - cur;
                l = cur;
                r = l + m - 1;
            }
            else
            {
                dist += cur - r;
                r = cur;
                l = r - m + 1;
            }
        }

        Console.WriteLine(dist);
    }
}
