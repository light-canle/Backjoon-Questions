#pragma warning disable CS8604, CS8602, CS8600

using System;
using System.Linq;
using System.Collections.Generic;

// p11402 - 이항 계수 4 (P4)
// #뤼카 정리 #정수론 #진법 변환
// 2025.9.27 solved

// BigInt라는 이름으로 사용
using BigInt = System.Numerics.BigInteger;

public class Program
{
    public static void Main(string[] args)
    {
        BigInt[] input = Array.ConvertAll(Console.ReadLine().Split(), BigInt.Parse);

        BigInt n = input[0], k = input[1], m = input[2];

        // 뤼카의 정리를 이용하기 위해 n과 k를 m진법으로 나타낸다.
        var nDigit = ConvertBase(n, m);
        var kDigit = ConvertBase(k, m);

        // k가 작아서 자릿수가 적은 경우 앞에 0을 넣어서 맞춘다.
        if (kDigit.Count < nDigit.Count)
        {
            int addZero = nDigit.Count - kDigit.Count;
            kDigit.InsertRange(0, Enumerable.Repeat(new BigInt(0), addZero));
        }

        // 0C0 ~ (m-1)C(m-1)에 대한 데이터를 미리 계산한다.
        BigInt[,] dp = new BigInt[(int)m, (int)m];
        dp[0, 0] = dp[1, 0] = dp[1, 1] = 1;
        for (int nn = 2; nn < m; nn++)
        {
            dp[nn, 0] = 1;
            for (int kk = 1 ; kk <= nn; kk++)
            {
                dp[nn, kk] = (dp[nn - 1, kk - 1] + dp[nn - 1, kk]) % m;
            }
        }

        // 각각의 자리에 대해서 nCk를 구한다.
        BigInt ret = 1;
        for (int i = 0; i < nDigit.Count; i++)
        {
            ret *= dp[(int)nDigit[i], (int)kDigit[i]];
            ret %= m;
        }
        Console.WriteLine(ret);
    }

    /// <summary>
    /// n을 b진법으로 나타냈을 때 각 자릿수를 반환하는 함수
    /// ex) n = 9, b = 2 -> 1001 , {1, 0, 0, 1} 반환
    /// </summary>
    public static List<BigInt> ConvertBase(BigInt n, BigInt b)
    {
        List<BigInt> ret = new();
        var m = n;
        while (m > 0)
        {
            ret.Add(m % b);
            m /= b;
        }
        ret.Reverse();
        return ret;
    }
}
