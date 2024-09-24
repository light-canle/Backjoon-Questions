using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

/// <summary>
/// p2606 - 바이러스, S3
/// 해결 날짜 : 2023/9/4
/// </summary>

public class Program
{
    public static List<List<int>> adj;
    public static List<bool> visited;
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        int N = int.Parse(sr.ReadLine());
        int connect = int.Parse(sr.ReadLine());

        adj = new List<List<int>>();
        visited = Enumerable.Repeat(false, N).ToList();
        for (int i = 0; i < N; i++)
        {
            adj.Add(new List<int>());
        }
        for (int i = 0; i < connect; i++)
        {
            int[] input = sr.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray();
            adj[input[0]].Add(input[1]);
            adj[input[1]].Add(input[0]);
        }

        int count = 0;
        DFS(0, visited, ref count);
        
        Console.WriteLine(count - 1);
    }

    public static void DFS(int current, List<bool> visited, ref int count)
    {
        // 현재 정점을 수에 추가
        count++;
        // 현재 정점을 방문한 것으로 표시
        visited[current] = true;
        // 현재 정점과 연결된 다른 정점들에 대해
        // 해당 정점을 방문하지 않은 경우 DFS로 다시 방문
        for (int i = 0; i < adj[current].Count; i++)
        {
            int there = adj[current][i];
            if (!visited[there])
            {
                DFS(there, visited, ref count);
            }
        }
    }
}