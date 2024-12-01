using System;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        long[] x = new long[n];
        long[] y = new long[n];
        for (int i = 0; i < n; i++)
        {
            long[] data = Console.ReadLine().Split().Select(long.Parse).ToArray();
            x[i] = data[0];
            y[i] = data[1];
        }
        long retA = 0, retB = 0;
        long minRSS = long.MaxValue;
        for (int a = 1; a <= 100; a++)
        {
            for (int b = 1; b <= 100; b++)
            {
                long rss = 0;
                for (int i = 0; i < n; i++)
                {
                    long func = a * x[i] + b;
                    long diff = Math.Abs(y[i] - func);
                    rss += diff * diff;
                }

                if (rss < minRSS)
                {
                    minRSS = rss;
                    retA = a;
                    retB = b;
                }
            }
        }
        Console.WriteLine(retA + " " + retB);
    }
}
