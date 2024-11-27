using System;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        long[] arr = Console.ReadLine().Split().Select(long.Parse).ToArray();

        long deno = 1;
        long num = 0;

        for (int i = 0; i < n; i++)
        {
            long add = deno;
            deno *= arr[i];
            num *= arr[i];
            num += add;
            long gcd = GCD(num, deno);
            num /= gcd;
            deno /= gcd;
        }
        
        long temp = num;
        num = deno;
        deno = temp;

        Console.WriteLine(num + "/" + deno);
    }

    public static long GCD(long a, long b)
    {
        if (b == 0) return a;
        return GCD(b, a % b);
    }
}
