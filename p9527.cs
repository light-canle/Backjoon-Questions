using System;
using System.Numerics;

public class Program
{
    public static void Main(string[] args)
    {
        long[] input = Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
        long a = input[0], b = input[1];

        BigInteger result = Count1(b) - Count1(a - 1);

        Console.WriteLine(result);

    }

    public static BigInteger Count1(long n)
    {
        if (n == 0) return 0;
        BigInteger ret = 1 + (n - 1) / 2;
        for (int i = 1; i <= 53; i++)
        {
            BigInteger cur = BigInteger.Pow(2, i);
            if (n >= cur)
            {
                BigInteger front = (n - cur + 1) % (cur * 2);
                ret += front > cur ? cur : front;
                ret += ((n - cur + 1) / (cur * 2)) * cur;
            }
        }
        return ret;
    }
}
