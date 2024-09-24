using System;
using System.Numerics;
using System.Collections.Generic;

/// <summary>
/// p3009 - 네 번째 점, B3
/// 해결 날짜 : 2023/10/7
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        var points = new List<int>();
        for (int i = 0; i < 3; i++)
        {
            points.AddRange(Console.ReadLine().Split().Select(int.Parse));
        }

        (int a, int b, int c) = (points[0], points[2], points[4]);
        int x = FindDiff(a, b, c);
        (int d, int e, int f) = (points[1], points[3], points[5]);
        int y = FindDiff(d, e, f);

        Console.WriteLine($"{x} {y}");
    }

    public static int FindDiff(int a, int b, int c)
    {
        if (a == b && a != c) return c;
        else if (a == c && a != b) return b;
        else return a;
    }
}