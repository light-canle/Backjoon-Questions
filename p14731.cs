using System;
using System.IO;

// p14731 - 謎紛芥索紀 (Large) (S1)
// #분할 정복을 이용한 거듭제곱 #미적분학 #정수론
// 2025.8.28 solved

public class Program
{
    public static int K = 1_000_000_007;
    public static void Main(string[] args)
    {
        StreamReader sr = new (new BufferedStream(Console.OpenStandardInput()));
        int n = int.Parse(sr.ReadLine());
        long ret = 0;
        for (int i = 0; i < n; i++)
        {
            long[] term = Array.ConvertAll(sr.ReadLine().Split(), long.Parse);
            if (term[1] == 0) continue;
            long coeff = (term[1] * term[0]) % K;
            ret += (coeff * PowMod(2, term[1] - 1, K)) % K;
            ret %= K;
        }
        Console.WriteLine(ret);
        sr.Close();
    }

    public static long PowMod(long a, long n, long r)
    {
        if (n == 0) return 1;
        else if (n == 1) return a % r;
        long half = PowMod(a, n / 2, r);
        if (n % 2 == 0)
        {
            return (half * half) % r;
        }
        else
        {
            return (((half * half) % r) * (a % r)) % r;
        }
    }
}
