using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

// p11651 - 좌표 정렬하기 2, S5
// 해결 날짜 : 2023/8/21

public class Point
{
    public int X;
    public int Y;

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        int pointCount = int.Parse(Console.ReadLine());
        List<Point> points = new List<Point>();

        for (int i = 0; i < pointCount; i++)
        {
            int[] input = Console.ReadLine().Trim().Split(' ').Select(x => int.Parse(x)).ToArray();
            points.Add(new Point(input[0], input[1]));
        }
        
        StringBuilder output = new StringBuilder();

        points = points.OrderBy(p => p.Y).ThenBy(p => p.X).ToList();

        foreach(Point point in points)
        {
            output.AppendLine(point.X + " " + point.Y);
        }

        Console.WriteLine(output);
    }
}