using System;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections.Generic;

/// <summary>
/// p1012 - 유기농 배추, S2
/// 해결 날짜 : 2023/9/2
/// </summary>

/*
배추의 위치를 정점으로 하고, 상하좌우로 인접한 위치는
인접 리스트로 연결시킨다.
그래프를 만든 뒤 인접 리스트를 DFS로 순회하면서, 전체 그래프가
몇 개의 연결되어 있지 않은 부분 그래프로 이루어졌는지를 계산해서 출력한다.
*/

public class Program
{
    // 그래프 정점 위치 리스트
    public static List<(int, int)> list;
    // 그래프의 인접 리스트 표현
    // list에서 i번째 인덱스에 있는 정점의 인접 리스트는 adj[i]가 된다.
    public static List<List<(int, int)>> adj;
    // 해당 정점을 방문했는지 여부
    // list에서 i번째 인덱스에 있는 정점의 방문 여부는 visited[i]가 된다.
    public static List<bool> visited;
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        StringBuilder output = new StringBuilder();

        list = new List<(int, int)>();
        adj = new List<List<(int, int)>>();
        visited = new List<bool>();
        // 테스트 케이스의 수
        int caseNum = int.Parse(sr.ReadLine());
        for (int i = 0; i < caseNum; i++)
        {
            // 케이스마다 격자의 크기가 달라지므로 초기화 한다.
            list.Clear();
            adj.Clear();
            visited.Clear();
            // 격자의 크기, 배추의 수를 받음
            int[] info = sr.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            (int M, int N, int numCab) = (info[0], info[1], info[2]);
            // 각 배추의 위치를 받아 리스트에 추가
            for (int j = 0; j < numCab; j++)
            {
                int[] pos = sr.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
                list.Add((pos[0], pos[1]));
                // 해당 위치에 대응하는 인접 리스트
                adj.Add(new List<(int, int)>());
                // list 안에 있는 원소들을 순회하면서 서로 인접해 있는지 확인한다.
                // 만약 인접한 경우 서로의 인접 리스트에 추가한다.
                for (int k = 0; k < list.Count; k++)
                {
                    if (IsAdjoining(list[k], list[j]))
                    {
                        adj[j].Add(list[k]);
                        adj[k].Add(list[j]);
                    }
                }
                // 방문 여부 초기화
                visited.Add(false);
            }
            // DFS로 탐색한 뒤 부분 그래프의 개수를 출력
            int areaCount = DFSAll();
            output.AppendLine(areaCount.ToString());
        }
        Console.WriteLine(output);
        sr.Close();
    }
    // 두 점이 인접한지를 체크함
    // x, y의 좌표를 각각 조사한 뒤, 두 차이의 합이 1이면 인접한 것이다.
    // 대각선 위치에 있거나 같은 것은 인접하지 않은 것으로 간주한다.
    public static bool IsAdjoining((int, int) first, (int, int) second)
    {
        int difX = Math.Abs(first.Item1 - second.Item1);
        int difY = Math.Abs(first.Item2 - second.Item2);
        return (difX + difY == 1) ? true : false;
    }

    // 깊이 우선 탐색
    public static void DFS((int, int) current)
    {
        // 현재 정점을 방문한 것으로 표시
        visited[list.IndexOf(current)] = true;
        // 현재 정점과 연결된 다른 정점들에 대해
        // 해당 정점을 방문하지 않은 경우 DFS로 다시 방문
        for (int i = 0; i < adj[list.IndexOf(current)].Count; i++)
        {
            (int, int) there = adj[list.IndexOf(current)][i];
            if (!visited[list.IndexOf(there)])
            {
                DFS(there);
            }
        }
    }
    // 모든 정점 방문
    // 그래프 중 연결된 간선이 없어 갈 수 없는 정점이 있어도 모두 방문할 수 있도록 한다.
    public static int DFSAll()
    {
        int areaCount = 0;
        // 한 정점씩 순회하면서 방문하지 않은 경우 DFS로 순회
        for (int i = 0; i < list.Count; i++)
        {
            if (!visited[i])
            {
                areaCount++;
                DFS(list[i]);
            }
        }
        return areaCount;
    }
}
