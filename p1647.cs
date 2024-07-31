using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));

        int[] i = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
        List<(int, int, int)> graph = new();
        (int V, int E) = (i[0], i[1]);
        for (int j = 0; j < E; j++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);

            graph.Add((line[0], line[1], line[2]));
        }

        graph.Sort((a, b) => a.Item3.CompareTo(b.Item3));

        int[] parent = Enumerable.Range(0, V+1).ToArray();

        if (V == 2)
        {
            Console.WriteLine(0);
            return;
        }
        int sum = 0;
        int vertexCount = 0;
        for (int k = 0; k < E; k++)
        {
            int u = graph[k].Item1;
            int v = graph[k].Item2;
            if (FindRoot(parent, u) != FindRoot(parent, v))
            {
                vertexCount++;
                Union(parent, u, v);
                sum += graph[k].Item3;
            }
            if (vertexCount == V - 2) break;
        }
        Console.WriteLine(sum);
    }

    public static int FindRoot(int[] parent, int x)
    {
        if (parent[x] == x) return x;
        return parent[x] = FindRoot(parent, parent[x]);
    }

    public static void Union(int[] parent, int x, int y)
    {
        int rootX = FindRoot(parent, x);
        int rootY = FindRoot(parent, y);

        if (rootX != rootY) parent[rootX] = rootY;
    }
}
