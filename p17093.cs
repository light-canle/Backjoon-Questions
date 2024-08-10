using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int N = size[0], M = size[1];

        List<(long, long)> point1 = new List<(long, long)>();
        for (int i = 0; i < N; i++)
        {
            long[] point = Console.ReadLine().Split().Select(long.Parse).ToArray();

            point1.Add((point[0], point[1]));
        }

        List<(long, long)> point2 = new List<(long, long)>();
        for (int i = 0; i < M; i++)
        {
            long[] point = Console.ReadLine().Split().Select(long.Parse).ToArray();

            point2.Add((point[0], point[1]));
        }

        long totalMax = 0;

        for (int i = 0; i < M; i++)
        {
            (long, long) cur = point2[i];
            long maxDistSquare = 0;
            for (int j = 0; j < N; j++)
            {
                long distSquare = GetDistSquare(cur, point1[j]);
                if (distSquare > maxDistSquare)
                {
                    maxDistSquare = distSquare;
                }
            }

            if (totalMax < maxDistSquare)
        {
            totalMax = maxDistSquare;
            }
        }

        Console.WriteLine(totalMax);
    }

    public static long GetDistSquare((long, long) p1, (long, long) p2)
    {
        return (p1.Item1 - p2.Item1) * (p1.Item1 - p2.Item1) + (p1.Item2 - p2.Item2) * (p1.Item2 - p2.Item2);
    }
}
