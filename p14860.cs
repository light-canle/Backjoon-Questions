#pragma warning disable CS8604, CS8602, CS8600

using System;
using System.Linq;
using System.Collections.Generic;

// p14860 - GCD 곱 (P4)
// #에라토스테네스의 체 #분할 정복을 이용한 거듭제곱 #정수론
// 2025.7.7 start
// 2025.9.24 solved

public class Program
{
    public static void Main(string[] args)
    {
        const long K = 1_000_000_007;
        int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        int a = input[0], b = input[1];
        // 둘 중 작은 수를 구함
        int min = Math.Min(a, b);

        if (min == 1)
        {
            Console.WriteLine(1);
            return;
        }
        // 에라토스테네스의 체를 이용해 1~min 사이의 소수를 모두 구한다.
        List<int> nums = Enumerable.Range(2, min - 1).ToList();
        bool[] isPrime = Enumerable.Repeat(true, min + 1).ToArray();
        List<int> primes = new();
        isPrime[0] = isPrime[1] = false;
        if (min > 3)
        {
            // min이 4 이상일 때 작동
            // 소수 판정처럼 2부터 sqrt(min)까지의 수에 대한 배수를 체크한다.
            for (int i = 2; i * i <= min; i++)
            {
                if (isPrime[i])
                {
                    primes.Add(i);
                    for (int j = i * 2; j <= min; j += i)
                    {
                        isPrime[j] = false;
                    }
                }
            }
            // 검사한 소수보다 큰 것 중 나눠지지 않은 것은 소수이다.
            for (int i = primes[^1] + 1; i <= min; i++)
            {
                if (isPrime[i])
                {
                    primes.Add(i);
                }
            }
        }
        else
        {
            // min이 2, 3이면 위의 방식이 안 작동하므로 따로 소수를 구한다.
            if (min >= 2) primes.Add(2);
            if (min >= 3) primes.Add(3);
        }
        /*
        a×b 격자로 gcd(1,1)~gcd(a,b)를 나열하면
        그 수를 소인수분해 했을 때,
        소수 p가 k제곱 이상 곱해져 있는 수의 개수는
        c = floor(a/p^k) × floor(b/p^k)개 이다.
        우리가 위에서 구한 2~min 범위의 모든 소수 p에 대해
        p^k <= min인 양의 정수 k에 한해서
        c를 구한 뒤 p^c를 누적해서 곱하면 된다.
        */
        long ret = 1;
        foreach (var p in primes)
        {
            long cur = p;
            while (cur <= min)
            {
                long count = (a / cur) * (b / cur);
                ret *= PowMod(p, count, K);
                ret %= K;
                cur *= p;
            }
        }
        Console.WriteLine(ret);
    }

    // a^b mod k를 구한다.
    public static long PowMod(long a, long b, long k)
    {
        if (b == 0) return 1;
        if (b == 1) return a % k;
        long half = PowMod(a, b / 2, k);
        long s = (half * half) % k;
        if (b % 2 == 0)
        {
            return s;
        }
        else
        {
            return (s * (a % k)) % k;
        }
    }
}
