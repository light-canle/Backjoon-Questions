using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

public class Program
{
    public static List<List<int>> adj;
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        while (true)
        {
            int[] size = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
            int w = size[0], h = size[1];
            if (w == 0 && h == 0) break;
            adj = new List<List<int>>();
            List<List<int>> list = new();
            for (int i = 0; i < h; i++)
            {
                list.Add(sr.ReadLine().Split(' ').Select(int.Parse).ToList());
            }

            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    adj.Add(new List<int>());
                    int current = list[i][j];

                    if (current == 0) continue;

                    // 상하좌우
                    if (i != 0 && current == list[i - 1][j])
                        adj[i * w + j].Add((i - 1) * w + j);
                    if (i != h - 1 && current == list[i + 1][j])
                        adj[i * w + j].Add((i + 1) * w + j);
                    if (j != 0 && current == list[i][j - 1])
                        adj[i * w + j].Add(i * w + j - 1);
                    if (j != w - 1 && current == list[i][j + 1])
                        adj[i * w + j].Add(i * w + j + 1);

                    // 대각선
                    if (i != 0 && j != 0 && current == list[i - 1][j - 1])
                        adj[i * w + j].Add((i - 1) * w + j - 1);
                    if (i != 0 && j != w - 1 && current == list[i - 1][j + 1])
                        adj[i * w + j].Add((i - 1) * w + j + 1);
                    if (i != h - 1 && j != 0 && current == list[i + 1][j - 1])
                        adj[i * w + j].Add((i + 1) * w + j - 1);
                    if (i != h - 1 && j != w - 1 && current == list[i + 1][j + 1])
                        adj[i * w + j].Add((i + 1) * w + j + 1);
                }
            }

            int areaNum = DFSAll(adj, list, w, h);

            Console.WriteLine($"{areaNum}");
        }

        sr.Close();
    }

    public static void DFS(List<List<int>> adj, List<bool> visited, int current)
    {
        visited[current] = true;

        for (int i = 0; i < adj[current].Count; i++)
        {
            int there = adj[current][i];
            if (!visited[there])
            {
                DFS(adj, visited, there);
            }
        }
    }

    public static int DFSAll(List<List<int>> adj, List<List<int>> list, int w, int h)
    {
        List<bool> visited = Enumerable.Repeat(false, w * h).ToList();

        int areaCount = 0;
        for (int i = 0; i < adj.Count; i++)
        {
            int cur = list[i / w][i % w];
            if (cur == 0)
                visited[i] = true;
            if (!visited[i])
            {
                areaCount++;
                DFS(adj, visited, i);
            }
        }

        return areaCount;
    }
}
