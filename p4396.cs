using System;
using System.Collections.Generic;

// p4396 - 지뢰 찾기 (S4)
// #구현
// 2025.2.20 solved

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        List<string> mines = new List<string>();
        List<string> clicked = new List<string>();
        for (int i = 0; i < n; i++)
        {
            mines.Add(Console.ReadLine());
        }
        for (int i = 0; i < n; i++)
        {
            clicked.Add(Console.ReadLine());
        }

        List<List<char>> result = new List<List<char>>();
        bool mineOpened = false;
        for (int i = 0; i < n; i++)
        {
            List<char> row = new List<char>();
            for (int j = 0; j < n; j++)
            {
                if (clicked[i][j] == 'x')
                {
                    // 지뢰칸을 눌렀는지 판단
                    if (mines[i][j] == '*')
                    {
                        mineOpened = true;
                        row.Add('*');
                    }
                    // 선택되었으나 지뢰가 아님 : 주변 지뢰 수 표시
                    else
                    {
                        row.Add(MineCount(mines, i, j, n).ToString()[0]);
                    }
                }
                // 빈칸 표시
                else
                {
                    row.Add('.');
                }
            }
            result.Add(row);
        }

        // 만약 지뢰가 하나라도 열린 경우 모든 지뢰의 위치를 개방
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (mineOpened && mines[i][j] == '*')
                {
                    result[i][j] = '*';
                }
            }
        }
        foreach (var row in result)
        {
            Console.WriteLine(string.Join("", row));
        }
    }

    public static int MineCount(List<string> mines, int y, int x, int n)
    {
        int count = 0;
        // 현재 위치를 중심으로 3×3영역의 지뢰 수 조사
        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                // 자신의 위치는 건너뜀
                if (i == 0 && j == 0)
                {
                    continue;
                }
                // 범위를 벗어난 칸도 건너뜀
                if (y + i < 0 || y + i >= n || x + j < 0 || x + j >= n)
                {
                    continue;
                }
                // 지뢰인 경우 +1
                if (mines[y + i][x + j] == '*') count++;
            }
        }
        return count;
    }
}
