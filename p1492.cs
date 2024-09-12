using System;
using System.Linq;
using System.IO;
using System.Numerics;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        BigInteger[] input = Array.ConvertAll(Console.ReadLine().Split(), BigInteger.Parse);

        BigInteger n = input[0];
        BigInteger k = input[1];

        Console.WriteLine(FaulhaberSum(n, k));
    }

    public static BigInteger Factorial(BigInteger n)
    {
        BigInteger ans = 1;

        for (BigInteger i = 1; i <= n; i++)
        {
            ans *= i;
        }

        return ans;
    }

    public static BigInteger Combination(BigInteger n, BigInteger r)
    {
        return Factorial(n) / (Factorial(r) * Factorial(n - r));
    }

    public static (BigInteger, BigInteger) BernoulliNumber(BigInteger n)
    {
        BigInteger numerator = 0;
        BigInteger denominator = 1;
        for (BigInteger k = 0; k <= n; k++)
        {
            BigInteger numer = 0;
            for (int i = 0; i <= k; i++)
            {
                numer += Combination(k, i) * BigInteger.Pow(-1, i) * BigInteger.Pow(i, (int)n);
            }
            BigInteger denom = k + 1;
            numerator = numer * denominator + numerator * denom;
            denominator = denom * denominator;
            BigInteger gcd = GCD(numerator, denominator);
            numerator /= gcd;
            denominator /= gcd;
        }

        return (numerator, denominator);
    }

    public static BigInteger GCD(BigInteger a, BigInteger b)
    {
        if (b == 0)
        {
            return a;
        }
        return GCD(b, a % b);
    }

    public static BigInteger FaulhaberSum(BigInteger n, BigInteger k)
    {
        BigInteger ansN = 0;
        BigInteger ansD = 1;
        for (BigInteger i = 0; i <= k; i++)
        {
            (BigInteger berN, BigInteger berD) = BernoulliNumber(i);
            BigInteger num = BigInteger.Pow(-1, (int)i) * Combination(k + 1, i) * berN * BigInteger.Pow(n, (int)(k + 1 - i));
            BigInteger den = berD * (k + 1);
            ansN = num * ansD + ansN * den;
            ansD = den * ansD;
            BigInteger gcd = GCD(ansN, ansD);
            ansN /= gcd;
            ansD /= gcd;
        }
        return ansN % 1_000_000_007;
    }
}
