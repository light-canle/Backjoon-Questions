using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

// p14502 - 연구소 (G4)
// #격자 그래프 #DFS #완전 탐색
// 2025.8.21 solved

public class Program
{
    public static Dictionary<int, List<int>> adj; // 인접 리스트
    public static bool[] visited; // 방문 여부
    public static int maxSafetyCount; // 안전 영역의 최댓값
    public static int curSafetyCount; // 현재 반복에서의 안전 영역의 수
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        maxSafetyCount = 0;
        int[] size = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        int n = size[0], m = size[1];
        List<List<int>> init = new();
        for (int i = 0; i < n; i++)
        {
            init.Add(sr.ReadLine().Split().Select(int.Parse).ToList());
        }

        // 빈칸의 위치를 모두 구한다.
        List<int> blank = new();
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (init[i][j] == 0)
                {
                    blank.Add(i * m + j);
                }
            }
        }
        int c = blank.Count;
        // 모든 빈칸 증 3개를 골라서 그 3개에 벽을 세웠을 때의 안전 영역의 수를 구한다.
        for (int i = 0; i < c - 2; i++)
        {
            for (int j = i + 1; j < c - 1; j++)
            {
                for (int k = j + 1; k < c; k++)
                {
                    FindSafetyCount(init, blank[i], blank[j], blank[k], n, m);                  
                }             
            }
        }
        Console.WriteLine(maxSafetyCount);
        sr.Close();
    }
    public static void DFSAll(int gridCount, List<List<int>> arr, int n, int m)
    {
        curSafetyCount = 0;
        for (int k = 0; k < gridCount; k++)
        {
            // 만약 방문하지 않은 영역이 있으면, 그 영역의 모든 칸을 방문한다.
            // 바이러스만 전염성이 있으므로 방문하지 않은 바이러스만 DFS 수행
            if (!visited[k] && arr[k / m][k % m] == 2)
            {
                DFS(k, arr, m);
            }
        }
        // 바이러스가 다 퍼진 뒤 0의 개수를 센다.
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                curSafetyCount += arr[i][j] == 0 ? 1 : 0;
            }
        }
    }
    public static void DFS(int cur, List<List<int>> arr, int m)
    {
        if (visited[cur]) return;
        visited[cur] = true;
        // 바이러스가 없는 칸에 바이러스를 퍼뜨린다.
        if (arr[cur / m][cur % m] == 0)
        {
            arr[cur / m][cur % m] = 2;
        }
        // 인접한 칸으로 전염 시도
        foreach (var next in adj[cur])
        {
            DFS(next, arr, m);
        }
    }

    public static void FindSafetyCount(List<List<int>> init, int w1, int w2, int w3, int n, int m)
    {
        visited = new bool[n * m];
        // 주어진 위치 3개에 벽을 세운 새로운 보드를 만든다.
        List<List<int>> board = new();
        for (int i = 0; i < n; i++)
        {
            board.Add(new());
            for (int j = 0; j < m; j++)
            {
                int idx = i * m + j;
                board[i].Add((idx == w1 || idx == w2 || idx == w3) ? 1 : init[i][j]);
            }
        }
        // 그 보드를 기반으로 인접 리스트를 만든다.
        MakeAdjList(board, n, m);
        // DFS로 전체 탐색
        DFSAll(n * m, board, n, m);
        // 안전 영역의 최댓값을 갱신
        maxSafetyCount = Math.Max(curSafetyCount, maxSafetyCount);
    }

    public static void MakeAdjList(List<List<int>> arr, int n, int m)
    {
        adj = new();
        // 0 -> 위, 1 -> 왼쪽, 2 -> 오른쪽, 3 -> 아래
        (int, int)[] direction = { (-1, 0), (0, -1), (0, 1), (1, 0) };
        for (int j = 0; j < n; j++)
        {
            for (int k = 0; k < m; k++)
            {
                adj[j * m + k] = new();
                // 1(벽)은 인접 리스트를 연결하지 않음
                if (arr[j][k] == 1)
                {
                    visited[j * m + k] = true;
                    continue;
                }
                // 인덱스 초과 방지
                int[] possible = { 1, 1, 1, 1 };
                if (j == 0) { possible[0] = -1; }
                if (j == n - 1) { possible[3] = -1; }
                if (k == 0) { possible[1] = -1; }
                if (k == m - 1) { possible[2] = -1; }

                // 인접한 칸이 0(빈칸)이면 인접 리스트에 추가
                for (int l = 0; l < 4; l++)
                {
                    if (possible[l] != -1 && arr[j + direction[l].Item1][k + direction[l].Item2] == 0)
                    {
                        adj[j * m + k].Add((j + direction[l].Item1) * m + (k + direction[l].Item2));
                    }
                }
            }
        }
    }
}
