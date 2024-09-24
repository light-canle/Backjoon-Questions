using System;
using System.Linq;

/// <summary>
/// p1027 - 고층 건물, G4
/// 해결 날짜 : 2023/9/11
/// </summary>

/*
브루트포스 알고리즘과 일차 함수를 이용하는 문제
*/

public class Program
{
    public static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        int[] heights = Console.ReadLine().Split().Select(int.Parse).ToArray(); ;

        int maxCount = 0; ;
        for (int i = 0; i < heights.Length; i++)
        {
            int currentCount = 0;
            for (int j = 0; j < heights.Length; j++)
            {
                if (i == j) continue;

                if (IsSeen(heights, i, heights[i], j, heights[j])) currentCount++;
            }
            maxCount = Math.Max(currentCount, maxCount);
        }
        Console.WriteLine(maxCount);
    }

    // 현재 b1 빌딩에서 b2빌딩을 볼 수 있는지를 판단하는 함수
    // "빌딩이 보인다"라는 기준은 b1, b2의 지붕 좌표인 두 점 (b1Pos, b1Height), (b2Pos, b2Height)
    // 을 이은 선분이 중간에 있는 건물에 닿지 않는 것이다.
    public static bool IsSeen(int[] array, int b1Pos, int b1Height, 
        int b2Pos, int b2Height)
    {
        // 두 점을 잇는 선분의 기울기과 y절편을 구한다.
        double lineSlope = (double)(b2Height - b1Height) / (b2Pos - b1Pos);
        double lineIntercept = b1Height - lineSlope * b1Pos;

        // 두 x좌표 중 큰 것, 작은 것을 구분함
        int xMin = b1Pos < b2Pos ? b1Pos : b2Pos;
        int xMax = b1Pos == xMin ? b2Pos : b1Pos;

        // 두 건물 사이에 있는 건물이 선분에 닿는지 검사
        for (int i = xMin + 1; i <= xMax - 1; i++)
        {
            if (lineSlope * i + lineIntercept <= array[i])
            {
                return false;
            }
        }
        return true;
    }
}