using System;
using System.Numerics;

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int[] a = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

        BigInteger k1 = 1;
        foreach (int i in a)
        {
            k1 *= i;
        }

        int m = int.Parse(Console.ReadLine());
        int[] b = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

        BigInteger k2 = 1;
        foreach (int i in b)
        {
            k2 *= i;
        }

        BigInteger g = GCD(k1, k2);
        BigInteger ret = g % 1_000_000_000;

        if (g >= 1_000_000_000)
        {
            Console.WriteLine($"{(int)ret:D09}");
        }
        else
        {
            Console.WriteLine(ret);
        }
    }

    public static BigInteger GCD(BigInteger a, BigInteger b)
    {
        if (b == 0) return a;
        return GCD(b, a % b);
    }
}
