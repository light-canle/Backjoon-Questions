#pragma warning disable CS8604, CS8602, CS8600

using System;
using System.IO;
using System.Text;

// p13977 - 이항 계수와 쿼리 (P5)
// #DP #조합론 #페르마의 소정리 #모듈러 역원 #분할 정복을 이용한 거듭제곱
// 2025.9.23 solved

public class Program
{
    public static void Main(string[] args)
    {
        const long P = 1_000_000_007;
        StreamReader sr = new (new BufferedStream(Console.OpenStandardInput()));
        StreamWriter sw = new (new BufferedStream(Console.OpenStandardOutput()));
        StringBuilder output = new();
        // factMod[k] = k! mod P
        long[] factMod = new long[4_000_001];
        factMod[0] = 1;
        for (int i = 1; i <= 4_000_000; i++)
        {
            factMod[i] = (i * factMod[i - 1]) % P;
        }
        int m = int.Parse(sr.ReadLine());
        for (int i = 0; i < m; i++)
        {
            long[] line = Array.ConvertAll(sr.ReadLine().Split(), long.Parse);
            long n = line[0], k = line[1];
            // n! mod P
            long numer = factMod[n];
            // k!(n-k)! mod P
            long denom = (factMod[k] * factMod[n - k]) % P;
            // 위에서 구한 것의 P에 대한 모듈러 역원
            /*
            a * a^(-1) mod P =
            a^P * a^(-1) mod P =
            a * a^(P-2) mod P
            => a^(-1) mod P = a^(P-2) mod P
            */
            long inv = PowMod(denom, P - 2, P);
            long f = (numer * inv) % P;
            output.AppendLine(f.ToString());
        }
        sw.WriteLine(output);
        sw.Flush();
        sr.Close();
        sw.Close();
    }

    // a^b mod k를 구한다.
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
