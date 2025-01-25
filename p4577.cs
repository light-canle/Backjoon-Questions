using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        int gameNum = 1;
        while (true)
        {
            int[] size = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int h = size[0], w = size[1];
            if (h == 0 && w == 0)
            {
                break;
            }

            List<List<char>> map = new();
            for (int i = 0; i < h; i++)
            {
                map.Add(Console.ReadLine().Trim().ToCharArray().ToList());
            }

            string move = Console.ReadLine();
            int moveTime = move.Length;

            // 플레이어 위치 설정
            int px = 0, py = 0;
            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    if (map[y][x] == 'w' || map[y][x] == 'W')
                    {
                        px = x; py = y;
                    }
                }
            }

            bool gameEnd = false;

            // 플레이어 이동
            for (int m = 0; m < moveTime; m++)
            {
                int dx = 0, dy = 0;
                switch (move[m])
                {
                    case 'U':
                        dy = -1;
                        break;
                    case 'D':
                        dy = 1;
                        break;
                    case 'L':
                        dx = -1;
                        break;
                    case 'R':
                        dx = 1;
                        break;
                }
                // 이동할 위치에 있는 게 뭔지 검사
                switch (map[py + dy][px + dx])
                {
                    case '#':
                        break;
                    case '.':
                        map[py + dy][px + dx] = 'w';
                        map[py][px] = map[py][px] == 'W' ? '+' : '.';

                        px += dx;
                        py += dy;
                        break;
                    case '+':
                        map[py + dy][px + dx] = 'W';
                        map[py][px] = map[py][px] == 'W' ? '+' : '.';

                        px += dx;
                        py += dy;
                        break;
                    case 'b':
                    case 'B':
                        char nextTo = map[py + 2 * dy][px + 2 * dx];
                        switch (nextTo)
                        {
                            case 'b':
                            case 'B':
                            case '#':
                                break;
                            case '.':
                                map[py + 2 * dy][px + 2 * dx] = 'b';
                                map[py + dy][px + dx] = map[py + dy][px + dx] == 'B' ? 'W' : 'w';
                                map[py][px] = map[py][px] == 'W' ? '+' : '.';

                                px += dx;
                                py += dy;
                                break;
                            case '+':
                                map[py + 2 * dy][px + 2 * dx] = 'B';
                                map[py + dy][px + dx] = map[py + dy][px + dx] == 'B' ? 'W' : 'w';
                                map[py][px] = map[py][px] == 'W' ? '+' : '.';

                                px += dx;
                                py += dy;
                                break;
                        }
                        break;
                }

                // 게임이 끝났는지 확인
                int left = 0;
                for (int y = 0; y < h; y++)
                {
                    for (int x = 0; x < w; x++)
                    {
                        if (map[y][x] == '+' || map[y][x] == 'W')
                        {
                            left++;
                        }
                    }
                }
                if (left == 0)
                {
                    gameEnd = true;
                    break;
                }
            }

            // 결과 출력
            string result = gameEnd ? "complete" : "incomplete";
            Console.WriteLine($"Game {gameNum}: {result}");
            foreach (var line in map)
            {
                foreach (var c in line)
                {
                    Console.Write(c);
                }
                Console.WriteLine();
            }
            gameNum++;
        }
    }
}
