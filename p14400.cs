#pragma warning disable CS8604, CS8602

using System;
using System.Collections.Generic;

// p14400 - 편의점 2 (S2)
// #기하학 #정렬
// 2025.11.15 solved

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        int n = int.Parse(sr.ReadLine());

        List<int> x = new List<int>();
        List<int> y = new List<int>();

        List<(int, int)> dots = new();

        for (int i = 0; i < n; i++)
        {
            int[] dot = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            x.Add(dot[0]);
            y.Add(dot[1]);
            dots.Add((dot[0], dot[1]));
        }

        // 점들의 x좌표, y좌표를 따로 모은 뒤 중앙값을 구한다.
        double xMed = Median(x);
        double yMed = Median(y);

        double totalDist = 0;

        for (int i = 0; i < n; i++)
        {
            totalDist += Distance(xMed, yMed, dots[i].Item1, dots[i].Item2);
        }

        Console.WriteLine(totalDist);
        sr.Close();
    }

    // 정렬된 list에서 중앙값을 구한다.
    public static double Median(List<int> list)
    {
        list.Sort();
        int count = list.Count;
        int half = count / 2;

        if (count % 2 == 0)
        {
            return (list[half - 1] + list[half]) / 2.0; 
        }
        else
        {
            return list[half];
        }
    }

    public static double Distance(double x1, double y1, double x2, double y2)
    {
        return Math.Abs(x2 - x1) + Math.Abs(y2 - y1);
    }
}
