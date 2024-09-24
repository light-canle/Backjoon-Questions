using System;
using System.Linq;
using System.Collections.Generic;

/// <summary>
/// p2630 - 색종이 만들기, S2
/// 해결 날짜 : 2023/9/6
/// </summary>

/*
2차원 배열을 분할 정복해서 푼 문제
어디를 기준으로, n*n을 기준으로 해당 영역의 색이 같은지
비교한 뒤, 모두 같으면 해당 색의 변수를 1증가 시키고 아닌 경우
해당 영역을 4등분 한 뒤 재귀 호출을 했다.
*/

public class Program
{
    public static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());

        // 2차원 배열 입력
        List<List<int>> list = new List<List<int>>();

        for (int i = 0; i < N; i++)
        {
            list.Add(new List<int>());
            list[i] = Console.ReadLine().Split().Select(int.Parse).ToList();
        }

        int white = 0;
        int blue = 0;
        // 재귀 호출
        CountPaper(list, 0, 0, N, ref white, ref blue);

        Console.WriteLine(white);
        Console.WriteLine(blue);
    }

    public static void CountPaper(List<List<int>> list, int startX, int startY,
        int currentSize, ref int white, ref int blue)
    {
        // 기저 사례 - 1x1 크기인 경우 색종이 1장만 있으면 된다.
        if (currentSize == 1)
        {
            if (list[startY][startX] == 0) { white++; }
            else { blue++; }
            return;
        } 

        // 모두 같은지 검사
        int first = list[startY][startX];
        bool allSame = true;
        for (int i = startY; i < startY + currentSize; i++)
        {
            for (int j = startX; j < startX + currentSize; j++)
            {
                if (list[i][j] != first)
                {
                    allSame = false;
                    break;
                }
            }
        }
        // 영역의 모든 색이 같으면 색종이 한 장만 있으면 된다.
        if (allSame)
        {
            if (first == 0) white++;
            else { blue++; }
            return; 
        }

        // 4등분으로 쪼개서 다시 같은 과정을 수행
        // 크기는 반이 되고, 시작 위치는 처음 사각형과 같거나 처음을 기준으로
        // 그 크기의 반만큼 x 또는 y로 이동한 것이다.
        CountPaper(list, startX, startY, 
            currentSize / 2, ref white, ref blue);
        CountPaper(list, startX + currentSize / 2, startY, 
            currentSize / 2, ref white, ref blue);
        CountPaper(list, startX, startY + currentSize / 2, 
            currentSize / 2, ref white, ref blue);
        CountPaper(list, startX + currentSize / 2, startY + currentSize / 2, 
            currentSize / 2, ref white, ref blue);
    }
}