#pragma warning disable CS8604, CS8602, CS8600
using System;
using System.IO;
using System.Collections.Generic;

// p22341 - 사각형 면적 (B2)
// #사칙연산
// 2025.5.31 solved (solved.ac 5.30)

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new (new BufferedStream(Console.OpenStandardInput()));
        int[] info = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        int n = info[0], c = info[1];

        List<(int, int)> points = new();
        for (int i = 0; i < c; i++)
        {
            int[] p = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            points.Add((p[0], p[1]));
        }

        int xLimit = n, yLimit = n;
        for (int i = 0; i < c; i++)
        {
            // 영역을 벗어나거나 경계에 걸친 점은 무시
            if (points[i].Item1 <= 0 || points[i].Item2 <= 0) continue;
            if (points[i].Item1 >= xLimit || points[i].Item2 >= yLimit) continue;
            // 가로로 자른 것의 넓이가 넓거나 같으면 가로로, 아니면 세로로 자른다.
            if (xLimit * points[i].Item2 <= yLimit * points[i].Item1)
            {
                xLimit = points[i].Item1;
            }
            else
            {
                yLimit = points[i].Item2;
            }
        }
        Console.WriteLine(xLimit * yLimit);
        sr.Close();
    }
}
