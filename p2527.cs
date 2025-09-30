#pragma warning disable CS8604, CS8602, CS8600

using System;

// p2527 - 직사각형 (S1)
// #기하학 #많은 조건 분기
// 2025.9.30 solved

public class Program
{
    public static void Main(string[] args)
    {
        while (true)
        {
            string input = Console.ReadLine();
            if (input == null)
            {
                break;
            }
            int[] p = Array.ConvertAll(input.Trim().Split(), int.Parse);
            int x1 = p[0], y1 = p[1], x2 = p[2], y2 = p[3];
            int x3 = p[4], y3 = p[5], x4 = p[6], y4 = p[7];

            // x, y 범위가 겹치는 지 확인
            int coverX = CoverLength(x1, x2, x3, x4);
            int coverY = CoverLength(y1, y2, y3, y4);

            // 겹치지 않음
            if (coverX == -1 || coverY == -1)
            {
                Console.WriteLine("d");
            }
            // 한 점에서 만남
            else if (coverX == 0 && coverY == 0)
            {
                Console.WriteLine("c");
            }
            // 선분이 겹침
            else if ((coverX > 0 && coverY == 0) ||
                (coverX == 0 && coverY > 0))
            {
                Console.WriteLine("b");
            }
            // 직사각형
            else
            {
                Console.WriteLine("a");
            }
        }
    }

    // a1~a2와 b1~b2에서 겹치는 구간의 길이를 반환 (a1 < a2, b1 < b2)
    // 두 구간이 한 점에서 만나는 경우 : 0을 반환
    // 어디에서도 만나지 않는 경우 : -1을 반환
    public static int CoverLength(int a1, int a2, int b1, int b2)
    {
        if (b1 < a1)
        {
            if (b2 < a1) return -1;
            else if (b2 == a1) return 0;
            else if (a1 < b2 && b2 <= a2) return b2 - a1;
            else
            {
                return a2 - a1;
            }
        }
        else if (a1 <= b1 && b1 <= a2)
        {
            if (a1 < b2 && b2 <= a2) return b2 - b1;
            else
            {
                return a2 - b1;
            }
        }
        else
        {
            return -1;
        }
    }
}
