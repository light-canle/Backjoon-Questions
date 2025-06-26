using System;
using System.IO;
using System.Collections.Generic;

// p25512 - 트리를 간단하게 색칠하는 최소 비용 (S1)
// #트리 #재귀 #그래프 탐색
// 2025.6.26 solved

public class Node
{
    // 노드를 흰색, 검정색으로 칠할 때 비용
    public long white;
    public long black;

    // 자식 노드 리스트
    public List<Node> children;

    public Node()
    {
        white = 0;
        black = 0;
        children = new();
    }
}
public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        int n = int.Parse(sr.ReadLine().Trim());
        // 트리 초기화
        Node[] tree = new Node[n];
        for (int i = 0; i < n; i++)
        {
            tree[i] = new Node();
        }
        // 간선으로 부모, 자식 노드 연결
        for (int i = 0; i < n - 1; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Trim().Split(), int.Parse);
            tree[line[0]].children.Add(tree[line[1]]);
        }
        // 각 정점을 흰색, 검정색으로 칠하는 비용
        for (int i = 0; i < n; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Trim().Split(), int.Parse);
            tree[i].white = line[0];
            tree[i].black = line[1];
        }
        /*
        트리에 색을 칠할 때, 인접한 노드는 다른 색을 칠하는 조건이 있다.
        즉, 부모 노드와 그 노드의 직계 자식 노드는 서로 다른 색을 가져야 한다.
        트리를 칠하는 경우의 수는 루트를 흰색으로 칠할 때와 검은 색으로 칠할 때의 2가지로
        둘 중 더 비용이 작은 쪽이 정답이다.
        */
        Console.WriteLine(Math.Min(Cost(tree[0], "white"), Cost(tree[0], "black")));
    }

    // 현재 서브트리의 루트를 color로 칠할 때의 트리 색칠의 비용
    public static long Cost(Node cur, string color)
    {
        long sum = 0;
        // cur을 칠하는 비용 반영
        if (color == "white")
        {
            sum += cur.white;
        }
        else
        {
            sum += cur.black;
        }
        // cur의 자식 노드들은 cur과 다른 색으로 칠한다.
        foreach (var c in cur.children)
        {
            sum += Cost(c, color == "white" ? "black" : "white");
        }
        return sum;
    }
}
