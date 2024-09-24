using System;
using System.Linq;
using System.IO;

/// <summary>
/// p1485 - 정사각형, S3
/// 해결 날짜 : 2023/11/21
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        int N = int.Parse(sr.ReadLine()!);
        for (int i = 0; i < N; i++)
        {
            // 네 점의 좌표를 받음
            (long, long)[] points = new (long, long)[4];
            for (int j = 0; j < 4; j++)
            {
                long[] input = sr.ReadLine()!.Split().Select(long.Parse).ToArray();
                points[j] = (input[0], input[1]);
            }
            // 네 점 중 두 점을 골라 각각의 거리를 구함
            long[] lenList = new long[6];
            int l = 0;
            for (int j = 0; j < 3; j++)
            {
                for (int k = j + 1; k < 4; k++)
                {
                    lenList[l] = lenSquare(points[j], points[k]);
                    l++;
                }
            }
            // 정사각형이면, 네 변의 길이가 같고, 두 대각선의 길이가 같다는 사실을 이용해서
            // 배열을 정렬한 뒤 각 변들이 정사각형의 네 변과 대각선을 나타내고 있는지 확인한다.
            var sorted = lenList.OrderBy(x => x).ToArray();
            bool isSquare = sorted[0] == sorted[1] 
                && sorted[1] == sorted[2] 
                && sorted[2] == sorted[3]
                && sorted[3] != sorted[4]
                && sorted[4] == sorted[5];
            Console.WriteLine(isSquare ? 1 : 0);
        }
        sr.Close();
    }

    // 두 점 사이 거리의 제곱을 구한다.
    public static long lenSquare((long, long) p1, (long, long) p2)
    {
        return Square(p1.Item1 - p2.Item1) + Square(p1.Item2 - p2.Item2);
    }

    public static long Square(long a) => a * a;
}