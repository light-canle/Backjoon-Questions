using System;

// 700th solved problem

public class Program
{
    public static void Main(string[] args)
    {
        while (true)
        {
            long[] input = Array.ConvertAll(Console.ReadLine().Split(), long.Parse);

            long p = input[0];
            long a = input[1];

            if (p == 0 && a == 0)
            {
                return;
            }

            long remain = PowMod(a, p, p);
            Console.WriteLine(remain == a && !IsPrime(p) ? "yes" : "no");
        }
    }

    // a^b mod m을 구한다. (a, m은 양의 정수)
    public static long PowMod(long a, long b, long m)
    {
        if (b == 0)
        {
            return 1;
        }
        if (b == 1)
        {
            return a % m;
        }

        if (b % 2 == 0)
        {
            long half = PowMod(a, b / 2, m);
            return (half * half) % m;
        }
        else
        {
            long half = PowMod(a, b / 2, m);
            return (((half * half) % m) * (a % m)) % m;
        }
    }

    public static bool IsPrime(long n)
    {
        if (n == 1)
        {
            return false;
        }
        if (n == 2 || n == 3)
        {
            return true;
        }
        int k = 4;
        while (k * k <= n)
        {
            if (n % k == 0)
            {
                return false;
            }
            k++;
        }
        return true;
    }
}
