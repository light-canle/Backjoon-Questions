using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

/// <summary>
/// p1926 - 그림, S1
/// 해결 날짜 : 2023/11/8
/// </summary>

// DFS로 부분 그래프의 개수와 인접한 노드의 수가 
// 가장많은 부분 그래프의 노드 수를 세는 문제

public class Program
{
    public static List<List<int>> adj;
    public static List<List<int>> list;
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        int[] size = sr.ReadLine().Split().Select(int.Parse).ToArray();

        (int N, int M) = (size[0], size[1]);

        adj = new List<List<int>>();
        // 기본 영역을 받음
        list = new List<List<int>>();
        for (int i = 0; i < N; i++)
        {
            list.Add(sr.ReadLine().Split().Select(int.Parse).ToList());
        }

        List<bool> visited = Enumerable.Repeat(false, N * M).ToList();
        // 리스트의 정보를 통해 인접 리스트를 만든다.
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < M; j++)
            {
                adj.Add(new List<int>());
                // 상하좌우에 서로 연결된 1은 인접 리스트에 추가한다.
                int current = list[i][j];
                // 0은 수에 포함하지 않음
                if (current == 0) {
                    visited[i * M + j] = true;
                    continue; 
                }

                if (i != 0 && current == list[i - 1][j] && current == 1)
                    adj[i * M + j].Add((i - 1) * M + j);
                if (i != N - 1 && current == list[i + 1][j] && current == 1)
                    adj[i * M + j].Add((i + 1) * M + j);
                if (j != 0 && current == list[i][j - 1] && current == 1)
                    adj[i * M + j].Add(i * M + j - 1);
                if (j != M - 1 && current == list[i][j + 1] && current == 1)
                    adj[i * M + j].Add(i * M + j + 1);
            }
        }

        
        // DFS로 탐색
        (int areaNum, int maxArea) = DFSAll(adj, visited, N, M);

        Console.WriteLine($"{areaNum}");
        Console.WriteLine($"{maxArea}");
        sr.Close();
    }

    public static void DFS(List<List<int>> adj, List<bool> visited, int current, int M, ref int area)
    {
        visited[current] = true;
        // 1을 발견한 경우 현재 넓이에 1 추가
        if (list[current / M][current % M] == 1) { area++; }

        for (int i = 0; i < adj[current].Count; i++)
        {
            int there = adj[current][i];
            if (!visited[there])
            {
                DFS(adj, visited, there, M, ref area);
            }
        }
    }

    public static (int,int) DFSAll(List<List<int>> adj, List<bool> visited, int N, int M)
    {
        int areaCount = 0;
        int max_area = 0;
        for (int i = 0; i < adj.Count; i++)
        {
            int area = 0;
            if (!visited[i])
            {
                areaCount++;
                DFS(adj, visited, i, M, ref area);
            }
            max_area = Math.Max(max_area, area); // 넓이 중 가장 큰 것을 찾음
        }

        return (areaCount, max_area);
    }
}