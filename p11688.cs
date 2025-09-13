using System;
using System.Numerics;
using System.Collections.Generic;

// p11688 - 최소공배수 찾기 (G5)
// #유클리드 호제법 #정수론(약수 찾기, gcd, lcm)
// 2025.9.13 solved

public class Program
{
    public static void Main(string[] args)
    {
        BigInteger[] input = Array.ConvertAll(Console.ReadLine().Split(), BigInteger.Parse);
        BigInteger a = input[0], b = input[1], L = input[2];
        // 1. a와 b의 최소공배수를 구한다.
        BigInteger k = LCM(a, b);
        // 2. L이 k의 배수가 아니면 k, c의 공배수가 될 수 없다.
        if (L % k != 0)
        {
            Console.WriteLine(-1);
            return;
        }

        /*
        L = lcm(k, c)이므로,
        L = kc / gcd(k, c)
        L은 k의 배수이므로 d = L / k라 하면,
        d = c / gcd(k, c)
        g' = gcd(k, c)로 두면,
        dg' = c
        공약수의 정의에 의해 g'는 k의 약수이다.
        즉, k의 약수를 구한 뒤 그걸 g로 두고
        dg와 k의 최대공약수가 g인 경우
        이때의 dg가 우리가 찾는 c가 된다.
        */
        // 3. k의 약수 중 답의 후보를 찾는다.
        var kDiv = Divisor(k);
        BigInteger d = L / k;

        foreach (var g in kDiv)
        {
            BigInteger c = d * g;
            if (GCD(c, k) == g)
            {
                Console.WriteLine(c);
                break;
            }
        }
    }

    public static BigInteger GCD(BigInteger a, BigInteger b)
    {
        if (b == 0) return a;
        return GCD(b, a % b);
    }

    public static BigInteger LCM(BigInteger a, BigInteger b)
    {
        return a / GCD(a, b) * b;
    }

    public static List<BigInteger> Divisor(BigInteger n)
    {
        List<BigInteger> ret = new();
        ret.Add(1);
        ret.Add(n);
        BigInteger k = 2;
        while (k * k <= n)
        {
            if (n % k == 0)
            {
                ret.Add(k);
                if (k * k != n) ret.Add(n / k);
            }
            k++;
        }
        ret.Sort();
        return ret;
    }
}
