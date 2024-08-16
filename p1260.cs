using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));

        int[] arr = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
        int V = arr[0], E = arr[1], S = arr[2];
        Dictionary<int, List<int>> graph = new();
        graph[S] = new();
        for (int i = 0; i < E; i++)
        {
            int[] edge = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
            int a = edge[0], b = edge[1];
            if (!graph.ContainsKey(a)) graph[a] = new();
            if (!graph.ContainsKey(b)) graph[b] = new();
            graph[a].Add(b);
            graph[b].Add(a);
        }

        foreach (var l in graph)
        {
            l.Value.Sort();
        }
        List<int> dfsOrder = new();
        List<int> bfsOrder = new();
        bool[] visited = new bool[V + 1];

        DFS(S, graph, visited, dfsOrder);

        for (int i = 0; i < V + 1; i++)
            visited[i] = false;

        BFS(S, graph, visited, bfsOrder);

        Console.WriteLine(string.Join(" ", dfsOrder));
        Console.WriteLine(string.Join(" ", bfsOrder));
        sr.Close();
    }

    public static void DFS(int s, Dictionary<int, List<int>> graph, bool[] visited, List<int> dfsOrder)
    {
        Stack<int> stack = new();
        stack.Push(s);

        while (stack.Count > 0)
        {
            int v = stack.Pop();
            if (visited[v]) continue;
            visited[v] = true;
            dfsOrder.Add(v);
            for (int i = graph[v].Count - 1; i >= 0; i--)
            {
                int w = graph[v][i];
                if (!visited[w]) stack.Push(w);
            }
        }
    }

    public static void BFS(int s, Dictionary<int, List<int>> graph, bool[] visited, List<int> bfsOrder)
    {
        Queue<int> queue = new();
        queue.Enqueue(s);
        while (queue.Count > 0)
        {
            int r = queue.Dequeue();
            if (visited[r]) continue;
            visited[r] = true;
            bfsOrder.Add(r);
            for (int i = 0; i < graph[r].Count; i++)
            {
                int w = graph[r][i];
                if (!visited[w]){
                    queue.Enqueue(w);
                }
            }
        }
    }
}
