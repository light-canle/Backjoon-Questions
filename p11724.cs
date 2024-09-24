using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

/// <summary>
/// p11724 - 연결 요소의 개수
/// 해결 날짜 : 2023/9/10
/// </summary>

/*
연결 요소(서로 연결되지 않은 부분 그래프)의 수를 세는 문제
DFS로 탐색해서 해결했다.
*/

public class Program
{
    public static List<List<int>> adj;
    public static List<bool> visited;
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        int[] input = sr.ReadLine().Split().Select(int.Parse).ToArray();
        (int numVer, int numEdge) = (input[0], input[1]);
        
        // 인접 리스트 초기화
        adj = new List<List<int>>();
        for (int i = 0; i < numVer; i++)
            adj.Add(new List<int>());
        visited = Enumerable.Repeat(false, numVer).ToList();

        // 간선들을 입력받고, 서로의 인접 리스트에 추가해서 정점을 연결함
        for (int i = 0; i < numEdge; ++i)
        {
            int[] pos = sr.ReadLine().Split().Select(int.Parse).ToArray();
            adj[pos[0] - 1].Add(pos[1] - 1);
            adj[pos[1] - 1].Add(pos[0] - 1);
        }

        int areaNum = DFSAll();

        Console.WriteLine(areaNum);
        
    }

    public static void DFS(int current)
    {
        // 정점을 탐색한 것으로 표시
        visited[current] = true;
        // 인접한 정점 모두 탐색
        for (int i = 0; i < adj[current].Count; ++i)
        {
            int there = adj[current][i];
            if (!visited[there])
            {
                DFS(there);
            }
        }
    }

    public static int DFSAll()
    {
        int areaNum = 0;
        for (int i = 0; i < adj.Count; ++i)
        {
            // 방문하지 않은 정점과 그것과 연결된 모든 정점을 탐색
            if (!visited[i])
            {
                areaNum++;
                DFS(i);
            }
        }

        return areaNum;
    }
}