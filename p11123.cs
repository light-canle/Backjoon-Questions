using System;
using System.IO;
using System.Collections.Generic;

// p11123 - 양 한마리... 양 두마리... (S2)
// #그래프 #DFS
// 2025.8.18 solved

public class Program
{
    public static Dictionary<int, List<int>> adj; // 인접 리스트
    public static bool[] visited; // 방문 여부
    public static int areaCount; // 영역의 갯수
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        int t = int.Parse(sr.ReadLine());
        for (int i = 0; i < t; i++)
        {
            int[] size = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int h = size[0], w = size[1];
            // 변수 초기화
            areaCount = 0;
            visited = new bool[h * w];
            // 그리드의 상태를 받음
            List<string> arr = new();
            for (int j = 0; j < h; j++)
            {
                arr.Add(sr.ReadLine());
            }

            // 인접 리스트 초기화
            adj = new();
            // 0 -> 위, 1 -> 왼쪽, 2 -> 오른쪽, 3 -> 아래
            (int, int)[] direction = { (-1, 0), (0, -1), (0, 1), (1, 0) };
            for (int j = 0; j < h; j++)
            {
                for (int k = 0; k < w; k++)
                {
                    adj[j * w + k] = new();
                    if (arr[j][k] == '.')
                    {
                        visited[j * w + k] = true;
                        continue;
                    }
                    // 인덱스 초과 방지
                    int[] possible = { 1, 1, 1, 1 };
                    if (j == 0) { possible[0] = -1; }
                    if (j == h - 1) { possible[3] = -1; }
                    if (k == 0) { possible[1] = -1; }
                    if (k == w - 1) { possible[2] = -1; }

                    // 인접한 칸이 #이면 인접 리스트에 추가
                    for (int l = 0; l < 4; l++)
                    {
                        if (possible[l] != -1 && arr[j + direction[l].Item1][k + direction[l].Item2] == '#')
                        {
                            adj[j * w + k].Add((j + direction[l].Item1) * w + (k + direction[l].Item2));
                        }
                    }
                }      
            }
            // 모든 정점을 탐색
            DFSAll(w * h);
            Console.WriteLine(areaCount);            
        }
        sr.Close();
    }
    public static void DFSAll(int gridCount)
    {
        for (int k = 0; k < gridCount; k++)
        {
            // 만약 방문하지 않은 영역이 있으면, 그 영역의 모든 칸을 방문한다.
            if (!visited[k])
            {
                areaCount++;
                DFS(k);
            }
        }
    }
    public static void DFS(int cur)
    {
        if (visited[cur]) return;
        visited[cur] = true;
        foreach (var next in adj[cur])
        {
            DFS(next);
        }
    }
}
