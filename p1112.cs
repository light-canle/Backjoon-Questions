#pragma warning disable CS8604, CS8602, CS8600

using System;

public class Program
{
    public static void Main(string[] args)
    {
        long[] input = Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
        long n = input[0], b = input[1];

        if (n == 0)
        {
            Console.WriteLine("0");
            return;
        }

        string ans = "";
        bool minusSign = false;

        if (n < 0 && b > 0)
        {
            n *= -1;
            minusSign = true; ;
        }

        while (n != 0)
        {
            (long q, long r) = DivMod(n, b);
            n = q;
            ans = r + ans;
        }

        if (minusSign) { ans = "-" + ans; }
        Console.WriteLine(ans);
    }

    public static (long, long) DivMod(long a, long b)
    {
        long q = a / b;
        long r = a % b;

        if (r < 0)
        {
            q++;
            r += Math.Abs(b);
        }
        return (q, r);
    }
}
