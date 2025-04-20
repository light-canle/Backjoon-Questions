using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

// p25511 - 값이 k인 트리 노드의 깊이 (S2)
// #트리 #재귀
// 2025.4.20 solved

public class Node
{
    public Node()
    {
        v = -1;
        children = new();
    }
    public int v;
    public List<Node> children;
}
public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new (new BufferedStream(Console.OpenStandardInput()));
        int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        int n = input[0], k = input[1];

        // 노드 배열 초기화
        Node[] tree = new Node[n];
        for (int i = 0; i < n; i++)
        {
            tree[i] = new Node();
        }
        // 노드에 자식을 연결
        for (int i = 0; i < n - 1; i++)
        {
            input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int p = input[0], c = input[1];
            tree[p].children.Add(tree[c]);
        }
        // 노드에 값을 넣는다.
        input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        for (int i = 0; i < n; i++)
        {
            tree[i].v = input[i];
        }
        // 루트 노드부터 k인 것을 찾음
        Console.WriteLine(FindKLevel(tree, tree[0], k, 0));
        sr.Close();
    }
    public static int FindKLevel(Node[] tree, Node cur, int k, int lv)
    {
        // base - k를 찾음
        if (k == cur.v)
        {
            return lv;
        }
        // recursive - 자식 노드에서 k인 것이 있는지 검사
        int found = -1;
        foreach (Node node in cur.children)
        {
            int f = FindKLevel(tree, node, k, lv + 1);
            if (f != -1)
            {
                found = f;
            }
        }
        return found;
    }
}
