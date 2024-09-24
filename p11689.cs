using System;
using System.Linq;
using System.Collections.Generic;
using System.Numerics;

/// <summary>
/// p11689 - GCD(n, k) = 1, G1
/// 해결 날짜 : 2024/4/4(solved.ac : 4/3)
/// </summary>

/*
GCD(n, k) = 1는 두 자연수 n, k가 서로소임을 뜻한다.
그리고 오일러 피 함수는 자연수 n에 대해 1 <= k <= n인 자연수 중에서 n과 서로소인 k가 몇 개
있는지를 나타내는 함수로 문제의 조건과 일치한다. 즉, 이 문제는 n에 대해 오일러 피 함수의 값을 구하는 문제이다.

오일러 피 함수의 성질 중에서 주목할 만한 것이 2개가 있다.
1. φ(mn)=φ(m)φ(n)
2. φ(p^k)=p^(k-1) * (p-1) (p는 소수, k는 자연수)
이 두 성질을 이용하면 자연수 n을 소인수분해 한 뒤, 곱셈의 성질을 이용하면 이 함수의 값을 매우 빠르게 구할 수
있음을 알 수 있다.

기존에 썼던 소인수분해 알고리즘이 이상해서, 인터넷에서 O(n^0.5)인 알고리즘을 참고했다.
for (long currentNum = 2; currentNum * currentNum <= N; currentNum++)
{
    while (N % currentNum == 0)
    {
        primes.Add(currentNum);
        N /= currentNum;
    }
}
if (N > 1) primes.Add(N);
*/

public class Program
{
    public static void Main(string[] args)
    {
        long N = long.Parse(Console.ReadLine()!);

        List<long> primes = new List<long>();
        if (IsPrime(N)) { primes.Add(N); }
        else
        {
            for (long currentNum = 2; currentNum * currentNum <= N; currentNum++)
            {
                while (N % currentNum == 0)
                {
                    primes.Add(currentNum);
                    N /= currentNum;
                }
            }
            if (N > 1) primes.Add(N);
        }

        var DistinctPrimes = primes.Distinct().ToList();

        // 오일러 피 함수의 곱의 성질을 이용한다.
        BigInteger piFunValue = 1;

        foreach (long p in DistinctPrimes)
        {
            // 소인수 분해되어 나온 소인수의 오일러 피 함수 값을 정답에 계속 곱해준다.
            piFunValue *= BigInteger.Pow(p, primes.Count(x => x == p) - 1) * (p - 1);
        }
        Console.WriteLine(piFunValue);
    }

    public static bool IsPrime(long num)
    {
        if (num == 1) return false;
        if (num == 2 || num == 3) return true;
        if (num % 6 != 1 && num % 6 != 5) return false;

        for (long i = 2; i * i <= num; i++)
        {
            if (num % i == 0) return false;
        }
        return true;
    }
}

// 소인수 분해 알고리즘 출처 : https://blog.naver.com/jinhan814/222141831551
// 오일러 피 함수 : https://ko.wikipedia.org/wiki/%EC%98%A4%EC%9D%BC%EB%9F%AC_%ED%94%BC_%ED%95%A8%EC%88%98