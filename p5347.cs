using System;

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            long[] input = Console.ReadLine().Split().Select(long.Parse).ToArray();

            long a = input[0], b = input[1];

            Console.WriteLine(LCM(a, b));
        }
    }

    public static long LCM(long a, long b)
    {
        return a / GCD(a, b) * b;
    }

    public static long GCD(long a, long b)
    {
        if (b == 0) return a;
        return GCD(b, a % b);
    }
}
