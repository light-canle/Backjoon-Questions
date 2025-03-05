using System;
using System.Linq;
using System.Collections.Generic;

// p1124 - 언더프라임 (S1)
// #에라토스테네스의 체 #소인수분해
// 2025.3.5 solved

public class Program
{
    public static List<int> primes;
    public static void Main(string[] args)
    {
        int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        int n = input[0];
        int m = input[1];

        // 2-10^5까지의 소수 저장
        primes = new List<int>();
        bool[] isPrime = Enumerable.Repeat(true, 100001).ToArray();
        for (int i = 2; i <= 100000; i++)
        {
            if (!isPrime[i]) continue;
            primes.Add(i);
            for (int j = i * 2; j <= 100000; j += i)
            {
                isPrime[j] = false;
            }
        }

        // n부터 m까지의 언더프라임 수를 센다.
        int underPrime = 0;
        for (int i = n; i <= m; i++)
        {
            int factors = FactorCount(i);
            if (IsPrime(factors))
            {
                underPrime++;
            }
        }
        Console.WriteLine(underPrime);
    }

    public static bool IsPrime(int n)
    {
        if (n == 1) return false;
        if (n == 2) return true;
        if (n % 2 == 0) return false;
        for (int i = 3; i * i <= n; i += 2)
        {
            if (n % i == 0) return false;
        }
        return true;
    }

    // 소인수의 개수를 세서 반환
    // 12 = 2^2 × 3 -> 3을 반환 (2,2,3)
    public static int FactorCount(int n)
    {
        if (n == 1) return 1;
        if (IsPrime(n)) return 1;
        int count = 0;
        int idx = 0;
        while (n > 1)
        {
            if (n % primes[idx] == 0)
            {
                count++;
                n /= primes[idx];
            }
            else
            {
                idx++;
            }
        }
        return count;
    }
}
