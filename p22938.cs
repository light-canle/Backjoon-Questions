using System;

// p22938 - 백발백준하는 명사수 (B3)
// #기하학 #피타고라스의 정리
// 2025.3.10 solved

public class Program
{
    public static List<int> nums;
    public static void Main(string[] args)
    {
        long[] t1 = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
        long x1 = t1[0], y1 = t1[1], r1 = t1[2];
        long[] t2 = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
        long x2 = t2[0], y2 = t2[1], r2 = t2[2];

        // 두 점 사이의 거리를 구한다.
        long dx = x1 - x2;
        long dy = y1 - y2;
        long dist = dx * dx + dy * dy;
        long rSquare = (r1 + r2) * (r1 + r2);
        // 두 점 사이의 거리가 두 원의 반지름의 합보다 작으면
        // 두 원은 겹친다.
        if (dist < rSquare)
        {
            Console.WriteLine("YES");
        }
        else
        {
            Console.WriteLine("NO");
        }
    }
}
