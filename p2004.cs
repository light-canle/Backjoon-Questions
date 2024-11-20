using System;

public class Program
{
    public static void Main(string[] args)
    {
        long[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
        long n = arr[0], r = arr[1];
        long ans = CountLastZero(n, r);
        Console.WriteLine(ans);
    }

    public static long CountLastZero(long n, long r)
    {
        long count2 = CountK(n, 2) - CountK(r, 2) - CountK(n - r, 2);
        long count5 = CountK(n, 5) - CountK(r, 5) - CountK(n - r, 5);

        return Math.Min(count2, count5);
    }

    public static long CountK(long n, long k)
    {
        long limit = 2_000_000_000;
        long count = 0;
        long pow = k;
        while (pow <= limit)
        {
            count += n / pow;
            pow *= k;
        }
        return count;
    }
}
