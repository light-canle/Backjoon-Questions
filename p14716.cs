using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

// p14716 - 현수막 (S1)
// #DFS #그래프
// 2025.8.6 solved

public class Program
{
    public static Dictionary<int, List<int>> adj; // 인접 리스트. i * n + j번 키에 (i, j)와 인접한 칸의 번호가 들어감
    public static bool[] visited; // 해당 정점 방문 여부. i * n + j번 인덱스에 (i, j)위치의 방문 여부가 들어감
    public static int areaCount; // 구하려는 영역의 개수
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        int[] size = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        int m = size[0], n = size[1];
        // 값 초기화
        areaCount = 0;
        visited = new bool[m * n];

        List<List<int>> arr = new();
        for (int i = 0; i < m; i++)
        {
            arr.Add(sr.ReadLine().Split().Select(int.Parse).ToList());
        }
        // 인접 리스트 - 8방향 인접한 대각선으로 연결한다.
        adj = new();
        /*
        0 1 2
        3 s 4
        5 6 7 -> s를 중심으로 0 ~ 7번 인덱스에 있는 변화량이 나타내는 위치를 나타낸 그림
        */
        (int, int)[] direction = { (-1, -1), (-1, 0), (-1, 1), (0, -1), (0, 1), (1, -1), (1, 0), (1, 1) };
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                adj[i * n + j] = new();
                // 0은 영역에 미포함 되므로 탐색 대상이 되지 않음
                if (arr[i][j] == 0)
                {
                    visited[i * n + j] = true;
                    continue;
                }
                // 해당 위치가 경계에 걸쳐있지 않은지 살펴본다. 경계에 걸쳐서 해당 위치가 존재하지 않으면
                // -1로 만들어서 추가하지 못하게 방지함
                int[] possible = { 1, 1, 1, 1, 1, 1, 1, 1 };
                if (i == 0) { possible[0] = possible[1] = possible[2] = -1; } // 위쪽 없음
                if (i == m - 1) { possible[5] = possible[6] = possible[7] = -1; } // 아래쪽 없음
                if (j == 0) { possible[0] = possible[3] = possible[5] = -1; } // 왼쪽 없음
                if (j == n - 1) { possible[2] = possible[4] = possible[7] = -1; } // 오른쪽 없음
                for (int k = 0; k < 8; k++)
                {
                    // 해당 칸이 유효 범위 내이고, 값이 1인 경우에만 인접 리스트에 추가한다.
                    if (possible[k] != -1 && arr[i + direction[k].Item1][j + direction[k].Item2] == 1)
                    {
                        adj[i * n + j].Add((i + direction[k].Item1) * n + (j + direction[k].Item2));
                    }
                }
            }
        }
        // 전체 탐색 - '1'이 인접한 칸으로 연결되어 이루어진 영역의 개수를 센다. 
        DFSAll(m * n);
        Console.WriteLine(areaCount);
    }

    public static void DFSAll(int gridCount)
    {
        for (int k = 0; k < gridCount; k++)
        {
            // 탐색하지 않은 영역에 대해 개수를 증가하고, 연결된 모든 칸을 DFS로 순회
            // 이러면 DFS 재귀에 의해 영역에 속한 모든 칸의 visited가 true가 되어 또 방문하지 않게 된다.
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
        visited[cur] = true; // 방문 여부 표시
        // 인접한 모든 칸을 방문
        foreach (var next in adj[cur])
        {
            DFS(next);
        }
    }
}
