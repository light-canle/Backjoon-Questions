using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        var data = Console.ReadLine().Split().Select(long.Parse).ToList();
        long problem = data[0];

        if (problem == 1)
        {
            Console.WriteLine(string.Join(" ", FindSequence(data[1], n)));
        }
        else
        {
            data.RemoveAt(0);
            Console.WriteLine(FindOrder(data, n));
        }
    }

    public static List<long> FindSequence(long k, int n)
    {
        long cur = k - 1;
        List<long> sequence = Range(1, (long)n);
        List<long> ret = new();
        for (int i = n - 1; i >= 1; i--)
        {
            int skip = (int)(cur / Factorial(i));
            ret.Add(sequence[skip]);
            cur -= skip * Factorial(i);
            sequence.RemoveAt(skip);
        }
        ret.Add(sequence[0]);
        return ret;
    }

    public static long FindOrder(List<long> seq, int n)
    {
        long order = 1;
        List<long> left = Range(1, (long)n);
        for (int i = 0; i < n - 1; i++)
        {
            int f = n - i - 1;
            int index = left.IndexOf(seq[i]);
            order += index * Factorial(f);
            left.RemoveAt(index);
        }
        return order;
    }

    public static long Factorial(long n)
    {
        if (n == 0)
        {
            return 1;
        }
        else
        {
            return n * Factorial(n - 1);
        }
    }

    public static List<long> Range(long start, long end)
    {
        List<long> ret = new List<long>();

        for (long i = start; i <= end; i++)
        {
            ret.Add(i);
        }

        return ret;
    }
}
