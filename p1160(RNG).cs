using System;
using System.Linq;
using System.Numerics;

// p1160 - Random Number Generator (P5)
// #분할 정복을 이용한 거듭제곱
// 2024.6.1 solved
// 1st Platinum Problem

public class Program
{
    public static void Main(string[] args)
    {
        BigInteger[] i = Console.ReadLine().Split().Select(BigInteger.Parse).ToArray();
        (var m, var a, var c, var x0, var n, var g) = (i[0], i[1], i[2], i[3], i[4], i[5]);

        Console.WriteLine(Rand(m, a, c, x0, n, g));
    }

    public static BigInteger Rand(BigInteger m, BigInteger a, BigInteger c, BigInteger x0, BigInteger n, BigInteger g)
    {
        return FindX(m, a, c, x0, n) % g;
    }

    public static BigInteger FindX(BigInteger m, BigInteger a, BigInteger c, BigInteger x0, BigInteger n)
    {
        if (n == 0) return x0;
        if (a == 0) return c % m;
        if (a == 1) return (x0 + n * c) % m;
        return ((PowMod(a, n, m) * (x0 % m)) % m + ((c % m) * (SumMod(a, n - 1, m) % m))) % m;
    }

    // Find a^n % m
    public static BigInteger PowMod(BigInteger a, BigInteger n, BigInteger m)
    {
        if (n == 0) return 1;
        if (n == 1) return a % m;

        if (n % 2 == 0)
        {
            var b = PowMod(a, n / 2, m);
            return (b * b) % m;
        }
        else
        {
            var b = PowMod(a, n / 2, m);
            return (b * b * a) % m;
        }
    }

    // Find (1 + a + ... + a^n) % m
    public static BigInteger SumMod(BigInteger a, BigInteger n, BigInteger m)
    {
        if (n == 0) return 1;
        if (n == 1) return (a + 1) % m;
        if (n % 2 == 0)
        {
            var b = SumMod(a, (n / 2) - 1, m);
            var c = PowMod(a, n / 2, m);
            return (((1 + c) % m) * (b % m) * (a % m) + 1) % m;
        }
        else
        {
            var b = SumMod(a, (n - 1) / 2, m);
            var c = PowMod(a, (n + 1) / 2, m);
            return (((1 + c) % m) * (b % m)) % m;
        }
    }
}
