using System;
using System.Linq;

public class Program
{
    public static long K = 1_000_000_007;
    public static void Main(string[] args)
    {
        long[] n = Console.ReadLine().Split().Select(long.Parse).ToArray();

        long A = n[0], B = n[1];

        long ans = SumMod(A, B - 1);

        Console.WriteLine(ans);
    }

    public static long SumMod(long A, long B)
    {
        if (B == 0) return 1;
        if (B == 1) return (1 + (A % K)) % K;
        if (B % 2 == 0)
        {
            long left = (1 + (PowMod(A, B / 2) % K)) % K;
            long right = (SumMod(A, B / 2 - 1) * (A % K)) % K;
            return (left * right + 1) % K;
        }
        else
        {
            long left = (1 + (PowMod(A, B / 2 + 1) % K)) % K;
            long right = SumMod(A, B / 2);
            return (left * right) % K;
        }
    }

    // return value of A^B mod (10^9 + 7)
    public static long PowMod(long A, long B)
    {
        if (B == 0) return 1;
        if (B == 1) return (int)A % K;
        if (B % 2 == 0)
        {
            long half = PowMod(A, B / 2);
            return (((half % K) * (half % K)) % K);
        }
        else 
        {
            long half = PowMod(A, B / 2);
            return ((((half % K) * (half % K)) % K) * (A % K)) % K;
        }
    }
}
