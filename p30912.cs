#pragma warning disable CS8604, CS8602, CS8600

using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

// p30912 - 위잉위잉 (G3)
// #기하학 #각도 정렬
// 2025.9.25 solved (9.24에 풀이)

public class Point : IComparable<Point>
{
    public long x;
    public long y;

    public Point(long x, long y)
    {
        this.x = x;
        this.y = y;
    }

    /* 
    점이 축 위에 있으면 그 축의 방향에 따라 0, 90, 180, 270을 반환
    축 위에 없으면 -1을 반환, 원점은 0을 반환한다.
    */
    public int OnAxis()
    {
        if (x == 0 && y == 0) return 0;
        if (x == 0)
        {
            return y > 0 ? 90 : 270;
        }
        else if (y == 0)
        {
            return x > 0 ? 0 : 180;
        }
        else
        {
            return -1;
        }
    }

    // 원점으로 부터 거리의 제곱을 반환
    public long DistanceFromOrigin()
    {
        return x * x + y * y;
    }

    // 점의 상대적 위치를 0 ~ 7의 정수로 반환한다.
    // 수가 클수록 각도가 큼이 보장된다.
    // 0 : +x방향, 2 : +y방향, 4 : -x방향, 6 : -y방향
    // 1 : 1사분면, 3 : 2사분면, 5 : 3사분면, 7 : 4사분면
    public int Position()
    {
        if (OnAxis() != -1)
        {
            return OnAxis() / 90 * 2;
        }

        if (x > 0)
        {
            return y > 0 ? 1 : 7;
        }
        else
        {
            return y > 0 ? 3 : 5;
        }
    }

    // 기울기를 비교해서 this가 더 크면 1, 같으면 0, 
    // 작으면 -1을 반환
    public int CompareSlope(Point other)
    {
        long a = y, b = x;
        long c = other.y, d = other.x;

        if (a * d > b * c)
        {
            return 1;
        }
        else if (a * d < b * c)
        {
            return -1;
        }
        else
        {
            return 0;
        }
    }

    public int CompareTo(Point other)
    {
        // 같은 축 위에 있는지 비교
        if ((this.OnAxis() != -1 && other.OnAxis() == -1) && (this.OnAxis() == other.OnAxis()))
        {
            return DistanceFromOrigin() < other.DistanceFromOrigin() ? -1 : 1;
        }
        // 같은 사분면 위에 있는지 비교
        else if (this.Position() == other.Position())
        {
            int s = CompareSlope(other);
            if (s == 0)
            {
                return DistanceFromOrigin() < other.DistanceFromOrigin() ? -1 : 1;
            }
            else
            {
                return s;
            }
        }
        // Position의 구현에 의해 Position()이 큰 쪽이 각도가 더 크다.
        return Position() - other.Position();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput()));
        StringBuilder output = new();

        int n = int.Parse(sr.ReadLine());
        List<(long, long)> positions = new();

        for (int i = 0; i < n; i++)
        {
            long[] point = Array.ConvertAll(sr.ReadLine().Split(), long.Parse);
            positions.Add((point[0], point[1]));
        }

        long[] origin = Array.ConvertAll(sr.ReadLine().Split(), long.Parse);
        long ox = origin[0], oy = origin[1];
        // 원점에 위치에 따라 평행이동을 한 뒤 정렬 (0도 부터 359.999... 도까지)
        List<Point> translated = new();
        for (int i = 0; i < n; i++)
        {
            translated.Add(new Point(positions[i].Item1 - ox, positions[i].Item2 - oy));
        }
        translated.Sort();
        // 원래 점 위치를 출력
        foreach (var p in translated)
        {
            output.AppendLine($"{p.x + ox} {p.y + oy}");
        }

        sw.WriteLine(output);
        sw.Flush();
        sr.Close();
        sw.Close();
    }
}
