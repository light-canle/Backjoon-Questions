#pragma warning disable CS8604, CS8602, CS8600

using System;

// p3063 - 게시판 (S4)
// #기하학 #많은 조건 분기
// 2025.9.29 solved

public class Program
{
    public static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine());
        for (int i = 0; i < t; i++)
        {
            int[] p = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int x1 = p[0], y1 = p[1], x2 = p[2], y2 = p[3];
            int x3 = p[4], y3 = p[5], x4 = p[6], y4 = p[7];

            // x범위와 y범위에서 서로의 겹치는 구간의 길이를 구한다.
            int coverX = CoverLength(x1, x2, x3, x4);
            int coverY = CoverLength(y1, y2, y3, y4);
            // 영화 동아리 포스터 넓이
            int posterArea = (x2 - x1) * (y2 - y1);
            // 원래 넓이에서 가리는 구간의 넓이를 빼서 보이는 부분의 넓이를 구함
            Console.WriteLine(posterArea - coverX * coverY);
        }
    }

    // a1~a2와 b1~b2에서 겹치는 구간의 길이를 반환 (a1 < a2, b1 < b2)
    public static int CoverLength(int a1, int a2, int b1, int b2)
    {
        if (b1 <= a1)
        {
            if (b2 <= a1) return 0;
            else if (a1 < b2 && b2 <= a2) return b2 - a1;
            else
            {
                return a2 - a1;
            }
        }
        else if (a1 < b1 && b1 <= a2)
        {
            if (a1 < b2 && b2 <= a2) return b2 - b1;
            else
            {
                return a2 - b1;
            }
        }
        else
        {
            return 0;
        }
    }
}
