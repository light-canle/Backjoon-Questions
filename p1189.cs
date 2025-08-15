using System;
using System.IO;
using System.Collections.Generic;

// p1189 - 컴백홈 (S1)
// #그래프 #DFS #백트래킹
// 2025.8.15 solved

public class Program
{
    public static Dictionary<int, List<int>> adj;
    public static int roadCount;
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        int[] size = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        int r = size[0], c = size[1], k = size[2];
        roadCount = 0;
        
        List<string> arr = new();
        for (int i = 0; i < r; i++)
        {
            arr.Add(sr.ReadLine());
        }
        // 인접 리스트 - 4방향 인접한 상하좌우로 칸을 연결한다.
        adj = new();
        // 0 -> 위, 1 -> 왼쪽, 2 -> 오른쪽, 3 -> 아래
        (int, int)[] direction = { (-1, 0), (0, -1), (0, 1), (1, 0) };
        for (int i = 0; i < r; i++)
        {
            for (int j = 0; j < c; j++)
            {
                adj[i * c + j] = new();
                if (arr[i][j] == 'T')
                {
                    continue;
                }
                // 인덱스 초과 방지
                int[] possible = { 1, 1, 1, 1 };
                if (i == 0) { possible[0] = -1; }
                if (i == r - 1) { possible[3] = -1; }
                if (j == 0) { possible[1] = -1; }
                if (j == c - 1) { possible[2] = -1; }
                // T가 아닌 칸끼리만 인접 리스트에 추가
                for (int l = 0; l < 4; l++)
                {
                    if (possible[l] != -1 && arr[i + direction[l].Item1][j + direction[l].Item2] != 'T')
                    {
                        adj[i * c + j].Add((i + direction[l].Item1) * c + (j + direction[l].Item2));
                    }
                }
            }
        }
        
        DFS((r - 1) * c, 0, new bool[r * c], k, c - 1);
        Console.WriteLine(roadCount);
        sr.Close();
    }
    public static void DFS(int cur, int curLen, bool[] visited, int k, int goal)
    {
        if (visited[cur])
            return;
        visited[cur] = true;
        curLen++;
        // k 길이만큼을 방문
        if (curLen == k)
        {
            // 도착지점에 도달한 경우 이 경로는 정답이 된다.
            roadCount += (cur == goal) ? 1 : 0;
            return;
        }
        foreach (var next in adj[cur])
        {
            // 새로 visited를 복제해주어야 한다.
            bool[] newV = new bool[visited.Length];
            Array.Copy(visited, newV, visited.Length);
            DFS(next, curLen, newV, k, goal);
        }
    }
}
