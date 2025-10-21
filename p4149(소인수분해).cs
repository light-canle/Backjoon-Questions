using System;
using System.Numerics;
using System.Collections.Generic;

// p4149 - 큰 수 소인수분해 (P1)
// #밀러-라빈 소수 판별법 #폴라드 로 #소인수분해 #정수론
// 2025.10.21 solved
// 1000th solved problem

public class Program
{
    public static Random r = new Random();
    public static void Main(string[] args)
    {
        BigInteger n = BigInteger.Parse(Console.ReadLine()!);
        List<BigInteger> factors = new();
        // 폴라드 로를 사용한 인수분해
        PollardRho(n, factors);
        // 약수 크기 순으로 정렬
        factors.Sort();
        foreach (BigInteger factor in factors)
        {
            Console.WriteLine(factor);
        }
    }

    // return a^b mod c
    // time complexity: O(log(b))
    public static BigInteger PowMod(BigInteger a, BigInteger b, BigInteger c)
    {
        // base
        if (b == 0) return 1;
        if (b == 1) return a % c;

        // recursive
        BigInteger half = PowMod(a, b / 2, c);
        if (b % 2 == 0)
        {
            return (half * half) % c;
        }
        else
        {
            return (((half * half) % c) * a) % c;
        }
    }

    /* 
    밀러-라빈 소수 판별법을 사용해서 n이 합성수인지를 판별한다. 이 함수에서 false를 리턴하면 합성수인 것이다.
    n - 1 = 2^h * m으로 나타낼 때, 1 < a < n인 정수 a, 홀수 소수 p에 대하여
    a^m mod p = 1이거나 1 <= j < h인 정수 j에 대해
    a^(2^j * m) mod p = n - 1이면 n은 유사 소수가 되고, 둘 다 아니면 합성수가 된다.
    */
    public static bool MillerRabin(BigInteger n, BigInteger a)
    {
        BigInteger k = n - 1;
        while (true)
        {
            BigInteger d = PowMod(a, k, n);
            // 앞에 곱해진 2의 배수 항이 모두 사라져서, m만 남음 : a^m mod p = 1 판정
            if (k % 2 == 1) return (d == 1 || d == n - 1);
            // a^(2^j * m) mod p = n - 1인 경우
            if (d == n - 1) return true; 
            k /= 2; // j를 1 줄인다.
        }
    }

    // 2^62-1보다 작은 양의 정수에 대한 소수 판정
    public static bool IsPrime(BigInteger n)
    {
        // 1 이하는 소수가 아니다.
        if (n <= 1) return false;
        // 41 이하의 소수에 대하여 밀러-라빈 소수 판정법 실시
        BigInteger[] smallPrimes = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41 };

        foreach (var p in smallPrimes)
        {
            // 작은 소수와 일치
            if (n == p) return true;
            // 소수의 배수는 합성수
            else if (n % p == 0) return false;
            if (!MillerRabin(n, p)) return false;
        }
        return true;
    }

    public static BigInteger GCD(BigInteger a, BigInteger b)
    {
        if (b == 0) return a;
        return GCD(b, a % b);
    }

    public static void PollardRho(BigInteger n, List<BigInteger> factors)
    {
        // 1이하는 무시
        if (n <= 1) return;
        // 폴라드 로는 인수분해 알고리즘 이므로 n이 소수인 경우에만 factors에 넣어야 소인수 분해가 된다.
        if (IsPrime(n))
        {
            factors.Add(n);
            return;
        }
        // 2를 소인수로 들고 있으면 2를 나눈 것에 대해 재귀한다.
        if (n % 2 == 0)
        {
            factors.Add(2);
            PollardRho(n / 2, factors);
            return;
        }
        BigInteger a, b;
        // a, b는 동일하게 둔다. [2, n - 1]의 범위를 가짐짐
        a = r.NextInt64(2, (long)n);
        b = a;
        // 상수항 -> [1, n - 2]
        BigInteger c = r.NextInt64(1, (long)n - 1), g = n;
        do
        {
            // 공약수가 1 -> 다시 시도한다.
            // 공약수가 n -> 현재 초기값 a와 c로는 자명한 해가 없으므로 다시 지정
            // 공약수가 [2, n - 1] -> 그 공약수가 n의 약수가 된다.
            if (g == n)
            {
                a = r.NextInt64(2, (long)n);
                b = a;
                c = r.NextInt64(1, (long)n - 1);
            }
            // f(x) = x^2 + c에 대해
            // f(a)와 f(f(b))의 차이의 절댓값을 구한 뒤 n과의 최대공약수를 구한다.
            a = (((a * a) % n) + c) % n;
            b = (((b * b) % n) + c) % n;
            b = (((b * b) % n) + c) % n;
            g = GCD(BigInteger.Abs(a - b), n);
        } while (g == 1 || g == n);
        PollardRho(g, factors);
        PollardRho(n / g, factors);
    }
}
