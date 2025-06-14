using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

// p25708 - 만남의 광장 (S1)
// #완전 탐색 #누적 합
// 2025.6.14 solved

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        int[] size = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        int n = size[0], m = size[1];

        List<List<int>> board = new();
        for (int i = 0; i < n; i++)
        {
            board.Add(sr.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList());
        }

        // 한 행의 m개의 수의 합
        List<int> horizontalSum = new();
        // 한 열의 n개의 수의 합
        List<int> verticalSum = new();

        // 각 열과 행에 있는 녹지의 가치 합을 미리 구해둔다.
        for (int i = 0; i < n; i++)
        {
            horizontalSum.Add(board[i].Sum());
        }
        for (int i = 0; i < m; i++)
        {
            int vertSum = 0;
            for (int j = 0; j < n; j++)
            {
                vertSum += board[j][i];
            }
            verticalSum.Add(vertSum);
        }

        // 길을 놓을 2개의 열, 2개의 행을 각각 선택한 다음
        // 두 열과 두 행에 놓인 녹지의 가치 합과, 네 길로 둘러싸인 녹지의 면적의 합을 구한 뒤 최댓값을 갱신한다.
        int maxBeauty = -(1_999_999_999); // 최댓값이 음수일 수도 있다.
        for (int c1 = 0; c1 < m - 1; c1++)
        {
            for (int c2 = c1 + 1; c2 < m; c2++)
            {
                for (int r1 = 0; r1 < n - 1; r1++)
                {
                    for (int r2 = r1 + 1; r2 < n; r2++)
                    {
                        // 선택한 행과 열의 가치 합을 더함
                        int currentBeauty = horizontalSum[r1] + horizontalSum[r2];
                        currentBeauty += verticalSum[c1] + verticalSum[c2];
                        // 교차점 4개는 중복되므로 빼주어야 한다.
                        currentBeauty -= (board[r1][c1] + board[r2][c1] + board[r1][c2] + board[r2][c2]);
                        // 길로 둘러싸인 녹지의 면적 계산
                        currentBeauty += (r2 - r1 - 1) * (c2 - c1 - 1);
                        // 최댓값 갱신
                        maxBeauty = Math.Max(maxBeauty, currentBeauty);
                    }
                }
            }
        }
        Console.WriteLine(maxBeauty);
    }
}
