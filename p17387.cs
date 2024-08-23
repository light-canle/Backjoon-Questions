using System;

public class Program
{
    public static void Main(string[] args)
    {
        long[] input = Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
        long x1 = input[0], y1 = input[1], x2 = input[2], y2 = input[3];
        input = Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
        long x3 = input[0], y3 = input[1], x4 = input[2], y4 = input[3];

        long t1 = CCW(x1, y1, x2, y2, x3, y3) * CCW(x1, y1, x2, y2, x4, y4);

        long t2 = CCW(x3, y3, x4, y4, x1, y1) * CCW(x3, y3, x4, y4, x2, y2);

        bool intersect = t1 <= 0 && t2 <= 0;

        if (t1 == 0 && t2 == 0)
        {
            long a = Math.Min(x1, x2);
            long b = Math.Max(x1, x2);
            long c = Math.Min(x3, x4);
            long d = Math.Max(x3, x4);
            long e = Math.Min(y1, y2);
            long f = Math.Max(y1, y2);
            long g = Math.Min(y3, y4);
            long h = Math.Max(y3, y4);
            intersect =
                !(d < a || b < c) && !(h < e || f < g);
        }
        Console.WriteLine(intersect ? "1" : "0");
    }

    public static long CCW(long x1, long y1, long x2, long y2, long x3, long y3)
    {
        long outer = (x2 - x1) * (y3 - y1) - (x3 - x1) * (y2 - y1);
        return outer > 0 ? 1 : outer < 0 ? -1 : 0;
    }
}
