using System;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        long[] input = Console.ReadLine().Split().Select(long.Parse).ToArray();

        long N = input[0], M = input[1];

        if (N >= M)
        {
            Console.WriteLine(0);
            return;
        }
        long ans = 1;

        for (long i = 2; i <= N; i++)
        {
            ans = (ans * i) % M;
        }
        Console.WriteLine(ans);
    }
}
