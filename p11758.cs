using System;
using System.Linq;
using System.Collections.Generic;

/// <summary>
/// p11758 - CCW, G5
/// 시작 날짜 : 2023/9/6(풀이만 작성)
/// 해결 날짜 : 2023/9/7
/// </summary>

/*
세 점의 위치 관계에 대한 문제
자세한 풀이는 풀이 노트 참조
*/

public class Point
{
    public int X, Y;
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
        Point[] points = new Point[3];
        for (int i = 0; i < 3; i++)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            points[i] = new Point(input[0], input[1]);
        }

        int answer = 0;
        // 세 점이 일직선을 이루는 지 판단
        if (IsLine(points))
        {
            answer = 0;
        }
        // 일직선이 아니라면 첫 점과 마지막 점을 연결한 직선을 기준으로
        // p2가 위에 있는 지 아래에 있는지, 그리고,
        // p3의 x좌표가 p1보다 큰 지 작은지에 의해 결정된다.
        else
        {
            answer = DetermineCycle(points);
        }
        Console.WriteLine(answer);
    }

    public static bool IsLine(Point[] p)
    {
        if (p[0].X == p[1].X && p[0].X == p[2].X) return true;
        if (p[0].Y == p[1].Y && p[0].Y == p[2].Y) return true;

        // x좌표가 낮은 순으로 정렬
        var points = p.OrderBy(p => p.X).ToList();

        // 기울기 구하기
        double slope1 = (double)(points[1].Y - points[0].Y) / (points[1].X - points[0].X);
        double slope2 = (double)(points[2].Y - points[0].Y) / (points[2].X - points[0].X);

        // 두 기울기가 같으면 일직선에 있는 것이다.
        return slope1 == slope2;
    }

    public static int DetermineCycle(Point[] p)
    {
        int direction = 0;
        // 첫 점, 마지막 점의 x좌표가 같을 때 - 두 번째 점의 x좌표에 의해 결정
        if (p[0].X == p[2].X)
        {
            // 첫 번째 점이 마지막 점보다 위에 있을 때,
            // 두 번째 점이 오른쪽에 있으면 시계 방향(-1),
            // 왼쪽에 있으면 반시계 방향(1)이다.
            direction = (p[1].X > p[2].X) ? -1 : 1;
            // 마지막 점이 위에 있는 경우 결과는 정반대가 된다.
            if (p[0].Y < p[2].Y) direction *= -1;
        }
        // 첫 점, 마지막 점의 y좌표가 같을 때 - 두 번째 점의 y좌표에 의해 결정
        else if (p[0].Y == p[2].Y)
        {
            // 첫 번째 점이 마지막 점보다 왼쪽에 있을 때,
            // 두 번째 점이 위쪽에 있으면 시계 방향(-1),
            // 아래쪽에 있으면 반시계 방향(1)이다.
            direction = (p[1].Y > p[2].Y) ? -1 : 1;
            // 마지막 점이 왼쪽에 있는 경우 결과는 정반대가 된다.
            if (p[0].X > p[2].X) direction *= -1;
        }
        // 그 외의 경우에는 p1, p3를 지나는 직선을 기준으로
        // p2가 위에 있는지 아래에 있는지에 따라 결정된다.
        // 첫 번째 점이 마지막 점보다 왼쪽에 있을 때
        // 두 번째 점이 직선보다 높은 곳에 있으면 시계 방향(-1),
        // 낮은 곳에 있으면 반시계 방향(1)이 된다.
        else
        {
            direction = IsUpperThanLine(new Point[2] { p[0], p[2] }, p[1]) ? -1 : 1;
            // 만약 첫 번째 점이 오른쪽에 있는 경우 방향은 반대가 된다.
            if (p[0].X > p[2].X) direction *= -1;
        }
        return direction;
    }

    public static bool IsUpperThanLine(Point[] line, Point p)
    {
        double a = (double)(line[1].Y - line[0].Y) / (line[1].X - line[0].X);
        double b = line[1].Y - a * line[1].X;

        return (a * p.X + b < p.Y);
    }
}