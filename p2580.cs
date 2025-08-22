using System;
using System.Linq;
using System.Collections.Generic;

// p2580 - 스도쿠 (G4)
// #백트래킹
// 2025.8.22 solved

public class Program
{
    public static List<List<int>> board;
    public static bool solved;
    public static void Main(string[] args)
    {
        board = new();
        solved = false;
        for (int i = 0; i < 9; i++)
        {
            board.Add(Console.ReadLine().Split().Select(int.Parse).ToList());
        }

        // 빈칸의 인덱스를 조사
        List<int> blank = new();
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (board[i][j] == 0)
                {
                    blank.Add(i * 9 + j);
                }
            }
        }      
        
        SudokuFill(0, blank);
        foreach (var line in board)
        {
            Console.WriteLine(string.Join(" ", line));
        }
    }

    public static void SudokuFill(int idx, List<int> blank)
    {
        if (solved) return;
        // 끝까지 다 채움
        if (idx >= blank.Count)
        {
            solved = true;
            return;
        }
        // 빈칸의 위치를 (y, x)로 변환
        int y = blank[idx] / 9;
        int x = blank[idx] % 9;
        // 가능한 목록 조사
        var candidate = FindCandidate(y, x);
        // 가능한 후보가 없음 - 이전으로 돌아감
        if (candidate.Count == 0) return;
        // 가능한 후보를 넣고 다음 칸을 채운다.
        // 그것이 안되어 돌아왔다면 다음 수를 채운다.
        foreach (var c in candidate)
        {
            board[y][x] = c;
            SudokuFill(idx + 1, blank);
            if (solved) return;
            board[y][x] = 0;
        }
    }

    public static List<int> FindCandidate(int y, int x)
    {
        List<int> possible = new();

        bool[] found = new bool[10];
        // 같은 가로, 세로 탐색
        for (int k = 0; k < 9; k++)
        {
            if (board[y][k] != 0) found[board[y][k]] = true;
            if (board[k][x] != 0) found[board[k][x]] = true;
        }
        // 그 수가 속한 3x3 영역 탐색
        int leftY = (y / 3) * 3, leftX = (x / 3) * 3;
        for (int yy = leftY; yy < leftY + 3; yy++)
        {
            for (int xx = leftX; xx < leftX + 3; xx++)
            {
                if (board[yy][xx] != 0) found[board[yy][xx]] = true;
            }
        }
        // 1~9 중 등장하지 않은 것들을 반환
        for (int k = 1; k <= 9; k++)
        {
            if (!found[k]) possible.Add(k);
        }
        return possible;
    }
}
