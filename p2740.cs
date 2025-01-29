using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        int[] aSize = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        List<List<int>> a = new();
        for (int i = 0; i < aSize[0]; i++)
        {
            a.Add(Console.ReadLine().Split().Select(int.Parse).ToList());
        }

        int[] bSize = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        List<List<int>> b = new();
        for (int i = 0; i < bSize[0]; i++)
        {
            b.Add(Console.ReadLine().Split().Select(int.Parse).ToList());
        }

        var ret = Multiply(a, b);
        foreach (var row in ret)
        {
            Console.WriteLine(string.Join(" ", row));
        }
    }

    public static List<List<int>> Multiply(List<List<int>> a, List<List<int>> b)
    {
        List<List<int>> c = new();
        int i = a.Count;
        int k = a[0].Count;
        int j = b[0].Count;
        for (int x = 0; x < i; x++)
        {
            c.Add(new List<int>());
            for (int y = 0; y < j; y++)
            {
                c[x].Add(0);
            }
        }

        for (int x = 0; x < i; x++)
        {
            for (int y = 0; y < j; y++)
            {
                for (int z = 0; z < k; z++)
                {
                    c[x][y] += a[x][z] * b[z][y];
                }
            }
        }

        return c;
    }
}
