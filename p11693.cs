using System;
using System.Collections.Generic;

// p11693 - n^m의 약수의 합 (G1)
// #정수론 #분할 정복을 이용한 거듭제곱 #소인수분해 #소수판정
// 2025.2.2 solved
// 100th solved gold problem

public class Program
{
    public static int R = 1_000_000_007;
    public static void Main(string[] args)
    {
        long[] input = Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
        long n = input[0], m = input[1];
        
        // 1. n = 1
        // ans = 1
        if (n == 1)
        {
            Console.WriteLine(1);
            return;
        }

        // 2. n이 소수인 경우
        // 1, n, ... , n^(m-1), n^m이 약수가 된다.
        // 이들의 합은 (n^(m+1) - 1) / (n - 1)이다.
        if (IsPrime(n))
        {
            Console.WriteLine(GeometricSum(n, m, R));
        }

        // 3. n이 합성수인 경우
        // 모든 소인수들에 대해 각각에 대해서 약수의 합을 구하고
        // 그 합들을 모두 곱하면 된다.
        else
        {
            long ret = 1;
            var factors = Factorization(n);
            foreach (var factor in factors)
            {
                ret *= GeometricSum(factor.Key, factor.Value * m, R);
                ret %= R;
            }
            Console.WriteLine(ret);
        }
        
    }

    public static bool IsPrime(long n)
    {
        if (n == 1) return false;
        if (n == 2) return true;

        for (int i = 2; i * i <= n; i++)
        {
            if (n % i == 0) return false;
        }
        return true;
    }

    public static Dictionary<long, int> Factorization(long n)
    {
        Dictionary<long, int> factors = new();
        if (IsPrime(n))
        {
            factors[n] = 1;
            return factors;
        }
        int div = 2;
        while (n > 1)
        {
            if (n % div == 0)
            {
                if (factors.ContainsKey(div)) factors[div]++;
                else factors[div] = 1;
                n /= div;
                if (IsPrime(n)) break;
            }
            else
            {
                div++;
            }
        }
        if (n != 1)
        {
            if (factors.ContainsKey(n)) factors[n]++;
            else factors[n] = 1;
        }
        return factors;
    }

    // (1 + a + ... + a^m) % r을 구한다.
    public static long GeometricSum(long a, long m, long r)
    {
        if (m == 0) return 1;
        if (m == 1) return (a + 1) % r;
        if (m % 2 == 1)
        {
            long half = m / 2;
            long left = PowMod(a, half + 1, r) + 1;
            long right = GeometricSum(a, half, r);
            return (left * right) % r;
        }
        else
        {
            long half = m / 2;
            long left = PowMod(a, half, r) + 1;
            long right = GeometricSum(a, half - 1, r);
            return ((left * ((right * a) % r)) % r + 1) % r;
        }
    }

    // a^b % r을 구한다.
    public static long PowMod(long a, long b, long r)
    {
        if (b == 0) return 1;
        if (b == 1) return a % r;
        if (b % 2 == 1)
        {
            long x = PowMod(a, b / 2, r);
            return ((((x % r) * (x % r)) % r) * (a % r)) % r;
        }
        else
        {
            long x = PowMod(a, b / 2, r);
            return ((x % r) * (x % r)) % r;
        }
    }
}
