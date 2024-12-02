using System;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        long[] data = Console.ReadLine().Split().Select(long.Parse).ToArray();
        long s = data[0];
        long p = data[1];

        if (s == p)
        {
            Console.WriteLine(1);
        }
        else if (s > p)
        {
            Console.WriteLine(2);
        }
        else
        {
            if (s < 57)
            {
                double localMax = Math.Exp((double)s / Math.E);
                if (localMax < p)
                {
                    Console.WriteLine(-1);
                    return;
                }
            }
            int ret = 1;
            double curMax = Math.Pow((double)s / ret, ret);
            while (curMax < p)
            {
                ret++;
                curMax = Math.Pow((double)s / ret, ret);
            }
            Console.WriteLine(ret);
        }
    }
}
