#pragma warning disable CS8604, CS8602, CS8600

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// p24482 - 알고리즘 수업 - 깊이 우선 탐색 4 (S2)
// #그래프 #DFS #정렬
// 2025.12.30 solved (12.29)

public class Program
{
    public static Dictionary<int, List<int>> graph;
    public static int[] distance;        // 깊이 (최단 거리가 아닌 방문한 순서에 따른 값)
    public static bool[] visited;        // 방문 여부
    public const int INF = 987654321;    // 무한 (문제 조건으로 달성 불가한 값)
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput()));
        int[] info = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        int n = info[0], m = info[1], start = info[2];

        graph = new();
        distance = Enumerable.Repeat(INF, n + 1).ToArray();
        visited = new bool[n + 1];
        for (int i = 1; i <= n; i++)
        {
            graph[i] = new();
        }
        // 간선을 받아 정점끼리 연결
        for (int i = 0; i < m; i++)
        {
            int[] vertices = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            graph[vertices[0]].Add(vertices[1]);
            graph[vertices[1]].Add(vertices[0]);
        }
        // 정점 내림차순 방문을 위한 정렬
        for (int i = 1; i <= n; i++)
        {
            graph[i].Sort();
            graph[i].Reverse();
        }
        
        DFS(start, 0);
        for (int i = 1; i <= n; i++)
        {
            sw.WriteLine(distance[i] == INF ? -1 : distance[i]);
        }

        sw.Flush();
    }

    public static void DFS(int current, int dist)
    {
        distance[current] = dist;
        visited[current] = true;

        foreach (var next in graph[current])
        {
            if (!visited[next])
            {
                DFS(next, dist + 1);
            }
        }
    }
}
