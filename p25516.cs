using System;
using System.IO;
using System.Collections.Generic;

// p25516 - 거리가 k이하인 트리 노드에서 사과 수확하기 (S2)
// #트리 #재귀 #그래프 탐색
// 2025.4.21 solved

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

        Console.WriteLine(SumOfKDistance(tree, tree[0], k, 0));
        sr.Close();
    }
    public static int SumOfKDistance(Node[] tree, Node cur, int k, int lv)
    {
        // base
        if (k == lv)
        {
            // 자신의 값을 반환
            return cur.v;
        }
        // recursive
        int sum = cur.v;
        foreach (Node node in cur.children)
        {
            // 자식들에 대하여 재귀
            sum += SumOfKDistance(tree, node, k, lv + 1);
        }
        return sum;
    }
}
