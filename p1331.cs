using System;
using System.Collections.Generic;

// p1331 - 나이트 투어 (S4)
// #시뮬레이션
// 2025.8.7 solved

public class Program
{
    public static void Main(string[] args)
    {
        // 나이트가 특정 칸에서 갈 수 있는 칸들을 저장하는 딕셔너리를 생성한다.
        // 칸들을 번호로 해서 인접한 칸 찾기
        Dictionary<int, List<int>> adj = new();
        (int, int)[] direction = { (-1, -2), (1, -2), (-2, -1), (2, -1), (-2, 1), (2, 1), (-1, 2), (1, 2) };
        for (int y = 0; y < 6; y++)
        {
            for (int x = 0; x < 6; x++)
            {
                adj[y * 6 + x] = new();
                for (int k = 0; k < 8; k++)
                {
                    int dx = direction[k].Item1, dy = direction[k].Item2;
                    if (0 <= y + dy && y + dy < 6 && 0 <= x + dx && x + dx < 6)
                    {
                        adj[y * 6 + x].Add((y + dy) * 6 + (x + dx));
                    }
                }
            }
        }
        // 칸에 대응하는 이름으로 변경해서 딕셔너리의 완성본 만들기
        Dictionary<string, List<string>> adjStr = new();
        for (int i = 0; i < 36; i++)
        {
            int y = i / 6, x = i % 6;
            adjStr[CellName(y, x)] = new();
            foreach (var other in adj[i])
            {
                adjStr[CellName(y, x)].Add(CellName(other / 6, other % 6));
            }
        }

        // 주어진 나이트 투어의 경로가 유효한지 판단하기
        // 경로 입력
        string[] road = new string[36];
        for (int i = 0; i < 36; i++)
        {
            road[i] = Console.ReadLine().Trim();
        }

        bool valid = true;
        List<string> visited = new();
        for (int i = 0; i < 35; i++)
        {
            // 현재 칸에서 다음 칸으로 갈 수 없거나 이미 방문한 곳이면 유효한 경로가 아니다.
            if (!adjStr[road[i]].Contains(road[i + 1])
                || visited.Contains(road[i]))
            {
                valid = false;
                break;
            }
            visited.Add(road[i]);
        }
        // 마지막 칸에서 처음 칸으로 갈 수 있어야 한다. 그리고 마지막 칸도 이미 지났는지 검사한다.
        if (visited.Contains(road[35]) || !adjStr[road[35]].Contains(road[0]))
            valid = false;
        Console.WriteLine(valid ? "Valid" : "Invalid");
    }

    public static string CellName(int y, int x)
    {
        return Convert.ToChar(('F' - y)).ToString() + (x + 1).ToString();
    }
}
