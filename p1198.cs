using System;
using System.Linq;
using System.Collections.Generic;

/// <summary>
/// p1198 - 삼각형으로 자르기, S2
/// 해결 날짜 : 2023/9/4
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());

        List<(int, int)> dotPosition = new List<(int, int)>();
        for (int i = 0; i < N; i++)
        {
            int[] pos = Console.ReadLine().Split().Select(int.Parse).ToArray();
            dotPosition.Add((pos[0], pos[1]));
        }
        double maxArea = 0;
        for (int i = 0; i < N - 2; i++)
        {
            for (int j = i + 1; j < N - 1; j++)
            {
                for (int k = j + 1; k < N; k++)
                {
                    maxArea = Math.Max(maxArea, 
                        AreaTriangle(dotPosition[i], dotPosition[j], dotPosition[k]));
                }
            }
        }
        Console.WriteLine(maxArea);
    }

    public static double AreaTriangle((int, int) a, (int, int) b, (int, int) c)
    {
        double area = 0;
        area += 0.5 * (a.Item1 + b.Item1) * (b.Item2 - a.Item2);
        area += 0.5 * (b.Item1 + c.Item1) * (c.Item2 - b.Item2);
        area += 0.5 * (c.Item1 + a.Item1) * (a.Item2 - c.Item2);
        return Math.Abs(area);
    }
}