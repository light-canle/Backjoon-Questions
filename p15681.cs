using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

public class Node
{
    public int No;
    public List<int> children;

    public Node(int no)
    {
        No = no;
        children = new();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));

        int[] arr = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
        int N = arr[0], R = arr[1], Q = arr[2];
        
        Dictionary<int, List<int>> adj = new();

        for (int i = 0; i < N - 1; i++)
        {
            int[] edge = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
            int u = edge[0], v = edge[1];
            if (!adj.ContainsKey(u)) adj[u] = new();
            if (!adj.ContainsKey(v)) adj[v] = new();
            adj[u].Add(v);
            adj[v].Add(u);
        }

        List<Node> tree = new();

        tree.Add(new(0));
        for (int i = 1; i <= N; i++)
        {
            tree.Add(new Node(i));
        }
        MakeTree(R, -1, adj, tree);
        int[] size = new int[N + 1];
        CountSubTreeNodes(R, tree, size);

        StringBuilder sb = new();
        for (int i = 0; i < Q; i++)
        {
            int root = int.Parse(sr.ReadLine());

            sb.AppendLine(size[root].ToString());
        }
        Console.WriteLine(sb);
        sr.Close();
    }

    public static void MakeTree(int cur, int parent, Dictionary<int, List<int>> adj, List<Node> tree)
    {
        for (int i = 0; i < adj[cur].Count; i++)
        {
            if (adj[cur][i] != parent)
            {
                tree[cur].children.Add(adj[cur][i]);
                MakeTree(adj[cur][i], cur, adj, tree);
            }
        }
    }

    public static void CountSubTreeNodes(int cur, List<Node> tree, int[] size)
    {
        size[cur] = 1;
        foreach (int child in tree[cur].children)
        {
            CountSubTreeNodes(child, tree, size);
            size[cur] += size[child];
        }
    }
}
