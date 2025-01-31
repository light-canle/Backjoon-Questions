using System;

public class Program
{
    public static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine());

        for (int i = 0; i < t; i++)
        {
            long n = long.Parse(Console.ReadLine());

            Console.WriteLine(Weighted(n));
        }
    }

    public static long Weighted(long n)
    {
        long ret = 0;
        for (long k = 1; k <= n; k++)
        {
            ret += k * TriNumber(k + 1);
        }
        return ret;
    }

    public static long TriNumber(long n)
    {
        return n * (n + 1) / 2;
    }
}
