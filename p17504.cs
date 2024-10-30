using System;

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        long[] a = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);

        long num = 1, den = a[n - 1];
        for (int i = n - 2; i >= 0; i--)
        {
            num += den * a[i];
            long g = GCD(num, den);
            num /= g;
            den /= g;

            long t = num;
            num = den;
            den = t;
        }
        num = den - num;
        Console.WriteLine(num + " " + den);
    }
    public static long GCD(long a, long b)
    {
        if (b == 0) return a;
        return GCD(b, a % b);
    }
}
