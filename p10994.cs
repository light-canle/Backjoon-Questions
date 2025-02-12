using System;
using System.Text;

// p10994 - 별 찍기 - 19 (S4)
// #재귀
// 2025.2.12 solved

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        bool[,] grid = new bool[4*n-3, 4*n-3];

        // 재귀적으로 별을 찍음
        SetStar(0, 0, n, grid);
        StringBuilder s = new StringBuilder();
        for (int i = 0; i < 4*n-3; i++)
        {
            for (int j = 0; j < 4*n-3; j++)
            {
                if (grid[i, j])
                {
                    s.Append("*");
                }
                else
                {
                    s.Append(" ");
                }
            }
            s.AppendLine();
        }
        Console.WriteLine(s);
    }

    public static void SetStar(int y, int x, int size, bool[,] grid)
    {
        if (size == 1) // 기저 사례
        {
            grid[y, x] = true;
            return;
        }

        int s = size * 4 - 3;

        // (x, y) 를 왼쪽 상단 모서리로 하는 
        // 한 변의 길이가 s인 정사각형 테두리를 그린다.
        for (int i = y; i < y + s; i++)
        {
            grid[i, x] = true;
            grid[i, x + s - 1] = true;
        }
        for (int i = x; i < x + s; i++)
        {
            grid[y, i] = true;
            grid[y + s - 1, i] = true;
        }
        // 기점을 기존의 위치에서 아래로 2, 오른쪽으로 2 이동시킨 뒤
        // 크기가 4만큼 줄어든 사각형을 재귀적으로 그린다.
        SetStar(y + 2, x + 2, size - 1, grid);
    }
}
