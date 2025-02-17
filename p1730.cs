using System;

// p1730 - 판화 (S4)
// #시뮬레이션
// 2025.2.17 solved

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        string move = Console.ReadLine();

        int[,] board = new int[n, n];
        int y = 0, x = 0; // 현재 위치
        int py = 0, px = 0; // 기존 위치

        foreach (char c in move)
        {
            switch (c)
            {
                case 'U':
                    y--;
                    break;
                case 'D':
                    y++;
                    break;
                case 'L':
                    x--;
                    break;
                case 'R':
                    x++;
                    break;
            }
            // 범위가 벗어난 경우 기존 위치로 되돌리고 이번 명령은 무시
            if (x < 0 || x >= n || y < 0 || y >= n)
            {
                x = Math.Clamp(x, 0, n - 1);
                y = Math.Clamp(y, 0, n - 1);
                continue;
            }
            
            // 기존 위치, 이동한 위치 모두 변화를 줌
            Scratch(board, y, x, c);
            Scratch(board, py, px, c);

            py = y;
            px = x;
        }
        // 결과 출력
        Print(board, n);
    }

    // 현재 위치에 로봇 팔이 움직인 방향에 따라 스크래치를 낸다.
    // 0은 팔이 지나가지 않음
    // 1은 수직으로만 지나감
    // 2는 수평으로만 지나감
    // 3은 수직과 수평으로 지나감
    public static void Scratch(int[,] board, int y, int x, char move)
    {
        // 수직 이동
        if (move == 'U' || move == 'D')
        {
            int temp = board[y, x];
            if (temp == 0)
            {
                board[y, x] = 1;
            }
            else if (temp == 2)
            {
                board[y, x] = 3;
            }
        }
        // 수평 이동
        else if (move == 'L' || move == 'R')
        {
            int temp = board[y, x];
            if (temp == 0)
            {
                board[y, x] = 2;
            }
            else if (temp == 1)
            {
                board[y, x] = 3;
            }
        }
    }

    public static void Print(int[,] board, int n)
    {
        for (int y = 0; y < n; y++)
        {
            for (int x = 0; x < n; x++)
            {
                switch (board[y, x])
                {
                case 0: Console.Write("."); break;
                case 1: Console.Write("|"); break;
                case 2: Console.Write("-"); break;
                case 3: Console.Write("+"); break;
                }
            }
            Console.WriteLine();
        }
    }
}
