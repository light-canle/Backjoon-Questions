using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

// p1743 - 음식물 피하기 (S1)
// #DFS #그래프
// 2025.8.8 solved

public class Program
{
    public static Dictionary<int, List<int>> adj; // 인접 리스트
    public static bool[] visited; // 방문 여부
    public static int maxSize; // 가장 큰 영역의 크기
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        int[] size = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        int n = size[0], m = size[1], k = size[2];
        // 변수 초기화
        maxSize = 0;
        visited = new bool[m * n];

        // 음식물 쓰레기의 위치를 받음
        List<(int, int)> foodPos = new();
        for (int i = 0; i < k; i++)
        {
            int[] p = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int y = p[0], x = p[1];
            foodPos.Add((y - 1, x - 1));
        }
        // n x m 격자를 만들고, 음식물 쓰레기의 위치를 표시한다.
        List<List<bool>> arr = new();
        for (int i = 0; i < n; i++)
        {
            arr.Add(new());
            for (int j = 0; j < m; j++)
            {
                arr[i].Add(false);
            }
        }
        foreach (var pos in foodPos)
        {
            arr[pos.Item1][pos.Item2] = true;
        }

        // 인접 리스트 - 4방향 인접한 상하좌우로 음식물 쓰레기들을 연결한다.
        adj = new();
        // 0 -> 위, 1 -> 왼쪽, 2 -> 오른쪽, 3 -> 아래
        (int, int)[] direction = { (-1, 0), (0, -1), (0, 1), (1, 0) };
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                adj[i * m + j] = new();
                if (arr[i][j] == false)
                {
                    visited[i * m + j] = true;
                    continue;
                }
                // 인덱스 초과 방지
                int[] possible = { 1, 1, 1, 1 };
                if (i == 0) { possible[0] = -1; }
                if (i == n - 1) { possible[3] = -1; }
                if (j == 0) { possible[1] = -1; }
                if (j == m - 1) { possible[2] = -1; }
                // 음식물 쓰레기끼리만 인접 리스트에 추가한다.
                for (int l = 0; l < 4; l++)
                {
                    if (possible[l] != -1 && arr[i + direction[l].Item1][j + direction[l].Item2])
                    {
                        adj[i * m + j].Add((i + direction[l].Item1) * m + (j + direction[l].Item2));
                    }
                }
            }
        }
        // 모든 정점을 탐색
        DFSAll(m * n);
        Console.WriteLine(maxSize);
        sr.Close();
    }
    public static void DFSAll(int gridCount)
    {
        for (int k = 0; k < gridCount; k++)
        {
            int curArea = 0;
            // 만약 방문하지 않은 영역이 있으면, 그 영역의 모든 칸을 방문한 뒤
            // 그 영역의 칸의 개수를 센다. (칸의 개수는 정수 레퍼런스를 사용해서 센다.)
            if (!visited[k])
            {
                DFS(k, ref curArea);
            }
            // 최대 크기 갱신
            maxSize = Math.Max(maxSize, curArea);
        }
    }
    public static void DFS(int cur, ref int curArea)
    {
        if (visited[cur]) return;
        visited[cur] = true;
        curArea++;
        foreach (var next in adj[cur])
        {
            DFS(next, ref curArea);
        }
    }
}
