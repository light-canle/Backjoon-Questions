using System;
using System.Collections.Generic;

// p17290 - Crazy_aRcade_Good (S5)
// #구현 #맨해튼 거리
// 2025.5.8 solved

public class Program
{
    public static void Main(string[] args)
    {
        // 플레이어 현재 좌표
        int[] pos = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        // 보드 정보 불러오기
        List<string> board = new();
        for (int i = 0; i < 10; i++)
        {
            board.Add(Console.ReadLine());
        }

        // 폭탄의 영향을 받지 않는지를 저장하는 배열
        bool[,] isSafe = new bool[10, 10];
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                isSafe[i, j] = true;
            }
        }

        // 폭탄과 같은 행과 열에 있는 칸의 isSafe는 false이다.
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                if (board[i][j] == 'o')
                {
                    for (int y = 0; y < 10; y++)
                    {
                        isSafe[y, j] = false;
                    }
                    for (int x = 0; x < 10; x++)
                    {
                        isSafe[i, x] = false;
                    }
                }
            }
        }

        // 각 칸과 플레이어 위치 사이의 거리 (맨해튼 거리)
        int[,] distance = new int[10, 10];
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                distance[i, j] = Math.Abs(i - pos[0] + 1) + Math.Abs(j - pos[1] + 1);
            }
        }

        // 안전한 칸 중 가장 가까운 것을 구한다.
        int minDist = 999999;
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                if (isSafe[i, j])
                {
                    minDist = Math.Min(minDist, distance[i, j]);
                }
            }
        }
        Console.WriteLine(minDist);
    }
}
