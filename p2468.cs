#pragma warning disable CS8604, CS8602, CS8600

using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    public static Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        List<List<int>> height = new();
        for (int i = 0; i < n; i++)
        {
            height.Add(Console.ReadLine().Split().Select(int.Parse).ToList());
        }

        int maxArea = 0;
        for (int h = 0; h < 101; h++)
        {
            graph.Clear();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    graph[i * n + j] = new();
                    if (i != n - 1 && height[i + 1][j] > h)
                        graph[i * n + j].Add((i + 1) * n + j);
                    if (i != 0 && height[i - 1][j] > h)
                        graph[i * n + j].Add((i - 1) * n + j);
                    if (j != n - 1 && height[i][j + 1] > h)
                        graph[i * n + j].Add(i * n + j + 1);
                    if (j != 0 && height[i][j - 1] > h)
                        graph[i * n + j].Add(i * n + j - 1);
                }
            }
            maxArea = Math.Max(CountArea(n, h, height), maxArea);
        }
        Console.WriteLine(maxArea);
    }

    public static int CountArea(int n, int h, List<List<int>> height)
    {
        bool[] visited = new bool[n * n];

        int count = 0;
        for (int i = 0; i < n * n; i++)
        {
            if (!visited[i] && height[i / n][i % n] > h)
            {
                count++;
                DFS(i, visited);
            }
        }

        return count;
    }

    public static void DFS(int n, bool[] visited)
    {
        visited[n] = true;

        foreach (int i in graph[n])
        {
            if (!visited[i])
            {
                DFS(i, visited);
            }
        }
    }
}
