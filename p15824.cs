#pragma warning disable CS8604, CS8602, CS8600

using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

// p15824 - 너 봄에는 캡사이신이 맛있단다 (G2)
// #조합론 #분할 정복을 이용한 거듭제곱
// 2025.9.22 solved

/*
N = 1일 때는 최대, 최소가 같으므로 값은 0이다.
정렬된 수열
a1 a2 ... an에 대하여
1 <= l < r <= n인 l, r을 골랐을 때,
al이 최소이고, ar이 최대가 되는 조합은
2^(r - l - 1)개가 된다.

그래서 가능한 모든 l, r에 대하여
(ar - al) * 2^(r - l - 1)의 합을 구하면 답을 얻을 수 있다.

문제는 l, r의 조합이 nC2개로 매우 많다는 것이다.
l, r차이가 1일 때,
(a2 - a1) + (a3 - a2) + ... + (an - a(n-1)) = an - a1
l, r차이가 2일 때,
(a3 - a1) + (a4 - a2) + ... + (an - a(n-2)) = an + a(n-1) - a2 - a1
...
이런 식으로 오른쪽부터 하나씩 더한 것을 왼쪽부터 하나씩 더한 것을 빼면 빠르게 구할 수 있다.
이는 l, r의 차이가 n - 1, n - 2일 때와 동일한 결과를 낳는다.
*/
public class Program
{
    public static void Main(string[] args)
    {
        const int K = 1_000_000_007;
        StreamReader sr = new (new BufferedStream(Console.OpenStandardInput()));
        int n = int.Parse(sr.ReadLine());
        List<long> nums = Console.ReadLine().Split().Select(long.Parse).ToList();
        nums.Sort();

        long result = 0;
        long leftSum = 0, rightSum = 0;
        int l = 0, r = n - 1;
        int dl = 1, dr = -1;
        for (int i = 0; i < n - 1; i++)
        {
            leftSum += nums[l] * dl;
            rightSum += nums[r] * (-dr);
            l += dl; r += dr;

            result += ((rightSum - leftSum) % K) * PowMod(2, i, K);
            result %= K;
            
            if (l == r)
            {
                l--; r++;
                dl = 0; dr = 0;
                continue;
            }
            else if (l > r)
            {
                dl = -1; dr = 1;
                l += dl; r += dr;
            }

            if (dl * dr == 0)
            {
                dl = -1; dr = 1;
            }
            
        }
        Console.WriteLine(result);
        sr.Close();
    }

    public static long PowMod(long a, long b, long k)
    {
        if (b == 0) return 1;
        if (b == 1) return a % k;
        long half = PowMod(a, b / 2, k);
        long ret = (half * half) % k;
        if (b % 2 == 0)
        {
            return ret;
        }
        else
        {
            return (ret * (a % k)) % k;
        }
    }
}
