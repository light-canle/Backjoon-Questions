using System;

// p2756 - 다트 (B2)
// #기하
// 2025.8.5 solved
// 400th bronze problem

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            double[] game = Array.ConvertAll(Console.ReadLine().Split(), double.Parse);
            int p1 = 0, p2 = 0;
            // 앞의 6개 수는 플레이어 1의 기록, 뒤의 6개 수는 플레이어 2의 기록이다.
            // 2개씩 묶어서 하나의 기록(다트의 위치)이 된다.
            for (int j = 0; j < 12; j += 2)
            {
                if (j < 6)
                {
                    p1 += Score(game[j], game[j + 1]);
                }
                else
                {
                    p2 += Score(game[j], game[j + 1]);
                }
            }
            // 점수에 따른 결과 출력
            if (p1 == p2)
            {
                Console.WriteLine($"SCORE: {p1} to {p2}, TIE.");
            }
            else if (p1 > p2)
            {
                Console.WriteLine($"SCORE: {p1} to {p2}, PLAYER 1 WINS.");
            }
            else
            {
                Console.WriteLine($"SCORE: {p1} to {p2}, PLAYER 2 WINS.");
            }
        }
    }

    // 두 점 사이의 거리 반환
    public static double Distance(double x1, double y1, double x2, double y2)
    {
        return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
    }

    // 중심과의 거리에 따른 점수 계산
    public static int Score(double x, double y)
    {
        double dist = Distance(0, 0, x, y);
        if (dist <= 3.0)
            return 100;
        else if (dist <= 6.0)
            return 80;
        else if (dist <= 9.0)
            return 60;
        else if (dist <= 12.0)
            return 40;
        else if (dist <= 15.0)
            return 20;
        else
            return 0;
    }
}
