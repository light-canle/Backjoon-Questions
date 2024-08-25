using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        long[] input = Array.ConvertAll(Console.ReadLine().Split(), long.Parse);

        long n = input[0], b = input[1];
        List<List<long>> matrix = new List<List<long>>();

        for (int i = 0; i < n; i++)
        {
            matrix.Add(Console.ReadLine().Split().Select(long.Parse).ToList());
        }

        List<List<long>> ret = PowMatrix(matrix, b, n);

        foreach (var row in ret)
        {
            Console.WriteLine(string.Join(" ", row));
        }
    }

    public static List<List<long>> PowMatrix(List<List<long>> matrix, long pow, long n)
    {
        if (pow == 1)
            return MultiplyMatrix(matrix, Identity(n), n);
        List<List<long>> ret = PowMatrix(matrix, pow / 2, n);
        if (pow % 2 == 0)
        {
            return MultiplyMatrix(ret, ret, n);
        }
        else
        {
            return MultiplyMatrix(MultiplyMatrix(ret, ret, n), matrix, n);
        }
    }

    public static List<List<long>> MultiplyMatrix(List<List<long>> m1, List<List<long>> m2, long n)
    {
        List<List<long>> ret = new List<List<long>>();

        for (int i = 0; i < n; i++)
        {
            ret.Add(new List<long>());
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                long cur = 0;
                for (int k = 0; k < n; k++)
                {
                    cur += ((m1[i][k] % 1000) * (m2[k][j] % 1000)) % 1000;
                    cur %= 1000;
                }
                ret[i].Add(cur);
            }
        }
        return ret;
    }

    public static List<List<long>> Identity(long n)
    {
        List<List<long>> ret = new List<List<long>>();

        for (int i = 0; i < n; i++)
        {
            ret.Add(new List<long>());
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (i == j)
                    ret[i].Add(1);
                else
                    ret[i].Add(0);
            }
        }
        return ret;
    }
}
