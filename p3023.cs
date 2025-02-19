using System;
using System.Linq;
using System.Collections.Generic;

// p3023 - 마술사 이민혁 (B1)
// #문자열
// 2025.2.19 solved

public class Program
{
    public static void Main(string[] args)
    {
        int[] size = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

        int r = size[0];
        int c = size[1];

        List<List<char>> quarter = new();
        for (int i = 0; i < r; i++)
        {
            quarter.Add(Console.ReadLine().ToCharArray().ToList());
        }

        // 받은 쿼터의 좌우/상하를 반전시켜 대칭이 되도록 만든다.
        char[,] card = new char[2*r, 2*c];
        for (int i = 0; i < r; i++)
        {
            for (int j = 0; j < c; j++)
            {
                // upper left
                card[i, j] = quarter[i][j];
                // upper right : flip horizontally
                card[i, 2 * c - 1 - j] = quarter[i][j];
                // lower left : flip vertically
                card[2 * r - 1 - i, j] = quarter[i][j];
                // lower right : flip horizontally and vertically
                card[2 * r - 1 - i, 2 * c - 1 - j] = quarter[i][j];
            }
        }

        // 지정된 한 자리의 에러를 넣는다.
        int[] inversePosition = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        int y = inversePosition[0] - 1;
        int x = inversePosition[1] - 1;
        card[y, x] = card[y, x] == '.' ? '#' : '.';

        for (int i = 0; i < 2 * r; i++)
        {
            for (int j = 0; j < 2 * c; j++)
            {
                Console.Write(card[i, j]);
            }
            Console.WriteLine();
        }
    }
}
