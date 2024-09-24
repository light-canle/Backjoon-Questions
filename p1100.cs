using System;
using System.Collections.Generic;

/// <summary>
/// p1100 - 하얀 칸, B2
/// 해결 날짜 : 2023/9/8
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        List<string> chessBoard = new List<string>();
        for (int i = 0; i < 8; i++)
        {
            chessBoard.Add(Console.ReadLine());
        }
        int pieceInWhite = 0;
        // (0,0)이 하얀 칸이고, 체스 보드는 하얀 칸, 검은 칸이 번갈아 나타난다.
        // 즉, 하얀 칸인 좌표는 x, y좌표의 합이 짝수가 된다.
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if ((i + j) % 2 == 0 && chessBoard[i][j] == 'F')
                    pieceInWhite++;
            }
        }
        Console.WriteLine(pieceInWhite);
    }
}