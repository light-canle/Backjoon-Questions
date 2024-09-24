using System;
using System.Linq;

/// <summary>
/// p13241 - 최소공배수, S5
/// 해결 날짜 : 2024/3/28
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        long[] input = Console.ReadLine()!.Split().Select(long.Parse).ToArray();
        (long a, long b) = (input[0], input[1]);
        
        long gcd = GCD(a, b);
        long lcm = a * b / GCD(a, b);

        Console.WriteLine(lcm);
    }

    public static long GCD(long a, long b)
    {
        long m = Math.Min(a, b);
        long n = Math.Max(a, b);

        if (m == 0)
        {
            return n;
        }
        return GCD(n % m, m);
    }
}