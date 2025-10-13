#pragma warning disable CS8604, CS8602, CS8600

using System;
using System.Linq;
using System.Collections.Generic;

// p18428 - 감시 피하기 (G5)
// #완전 탐색 #구현
// 2025.10.13 solved

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        char[,] hallway = new char[n, n];
        for (int i = 0; i < n; i++)
        {
            char[] line = Console.ReadLine().Split().Select(char.Parse).ToArray();
            for (int j = 0; j < n; j++)
            {
                hallway[i, j] = line[j];
            }
        }

        // 빈 칸의 위치와 선생님들의 위치를 저장해 둔다.
        List<int> blanks = new();
        List<int> teachers = new();
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (hallway[i, j] == 'X')
                {
                    blanks.Add(i * n + j);
                }
                else if (hallway[i, j] == 'T')
                {
                    teachers.Add(i * n + j);
                }
            }
        }

        // 3중 반복을 이용해서, 가능한 모든 위치에 장애물을 설치하고,
        // 해당 위치에서 학생들을 숨길 수 있는지 판정한다.
        bool canHide = false;
        for (int i = 0; i < blanks.Count - 2; i++)
        {
            if (canHide) break;
            for (int j = i + 1; j < blanks.Count - 1; j++)
            {
                if (canHide) break;
                for (int k = j + 1; k < blanks.Count; k++)
                {
                    if (canHide) break;
                    // 장애물을 놓음
                    hallway[blanks[i] / n, blanks[i] % n] = 'O';
                    hallway[blanks[j] / n, blanks[j] % n] = 'O';
                    hallway[blanks[k] / n, blanks[k] % n] = 'O';

                    // 각각의 선생님들의 위치에서 학생들이 한 명이라도 보이는지 판정
                    bool seen = false;
                    foreach (var t in teachers)
                    {
                        if (seen) break;
                        int ty = t / n, tx = t % n;

                        int x, y;
                        // 4방향 탐색
                        for (y = ty; y >= 0; y--)
                        {
                            // 장애물 뒤는 탐색하지 않음
                            if (hallway[y, tx] == 'O') break;
                            // 학생이 보이면 seen을 true로 바꿈
                            else if (hallway[y, tx] == 'S')
                            {
                                seen = true;
                                break;
                            }
                        }

                        for (y = ty; y < n; y++)
                        {
                            if (hallway[y, tx] == 'O') break;
                            else if (hallway[y, tx] == 'S')
                            {
                                seen = true;
                                break;
                            }
                        }

                        for (x = tx; x >= 0; x--)
                        {
                            if (hallway[ty, x] == 'O') break;
                            else if (hallway[ty, x] == 'S')
                            {
                                seen = true;
                                break;
                            }
                        }

                        for (x = tx; x < n; x++)
                        {
                            if (hallway[ty, x] == 'O') break;
                            else if (hallway[ty, x] == 'S')
                            {
                                seen = true;
                                break;
                            }
                        }
                    }
                    // 단 1명이라도 보지 못한 경우가 있으면 canHide는 true가 됨
                    canHide |= !seen;
                    // 다시 되돌림
                    hallway[blanks[i] / n, blanks[i] % n] = 'X';
                    hallway[blanks[j] / n, blanks[j] % n] = 'X';
                    hallway[blanks[k] / n, blanks[k] % n] = 'X';
                }
            }
        }
        Console.WriteLine(canHide ? "YES" : "NO");
    }
}
