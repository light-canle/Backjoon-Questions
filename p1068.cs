using System;
using System.Collections.Generic;
using System.Linq;

public class Node
{
    public int parent;
    public List<int> children;

    public Node()
    {
        parent = -1;
        children = new();
    }

    public bool IsLeaf()
    {
        return children.Count == 0;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        Node[] tree = new Node[n];
        for (int i = 0; i < n; i++)
        {
            tree[i] = new();
        }
        int[] parents = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        int removed = int.Parse(Console.ReadLine());
        List<int> root = new();
        for (int i = 0; i < n; i++)
        {
            tree[i].parent = parents[i];
            if (parents[i] != -1)
            {
                tree[parents[i]].children.Add(i);
            }
            else
            {
                root.Add(i);
            }
        }

        int ans = 0;
        foreach (int r in root)
        {
            ans += CountLeaves(r, tree, removed);
        }
        Console.WriteLine(ans);
    }

    public static int CountLeaves(int cur, Node[] tree, int removed)
    {
        if (cur == removed)
            return 0;
        if (tree[cur].IsLeaf())
            return 1;
        if (tree[cur].children.Count == 1 && tree[cur].children[0] == removed)
            return 1;
        int count = 0;
        foreach (var node in tree[cur].children)
        {
            count += CountLeaves(node, tree, removed);
        }
        return count;
    }
}
