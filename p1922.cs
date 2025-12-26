#pragma warning disable CS8604, CS8602, CS8600

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

// p1922 - 네트워크 연결 (G4)
// #그래프 #최소 스패닝 트리 #크루스칼 알고리즘
// 2025.12.27 solved (12.26)

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        
        int n = int.Parse(sr.ReadLine());
        int m = int.Parse(sr.ReadLine());

        List<(int, int, int)> graph = new(); // a, b, c -> a, b는 연결된 정점이고, c는 간선의 가중치

        for (int i = 0; i < m; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
            graph.Add((line[0], line[1], line[2]));
        }

        // 가중치가 낮은 것이 앞에 오도록 정렬
        graph.Sort((a, b) => a.Item3.CompareTo(b.Item3));
        // Union-Find에 쓰는 루트를 가리키는 배열
        int[] parent = Enumerable.Range(0, n + 1).ToArray();

        int sum = 0; // MST의 가중치 합
        int vertexCount = 0; // 현재 선택된 간선의 개수
        for (int i = 0; i < m; i++)
        {
            // 해당 간선에 연결된 두 정점을 찾는다.
            int u = graph[i].Item1;
            int v = graph[i].Item2;
            if (u == v) continue; // 자신을 가리키는 사이클은 무시
            // 두 정점이 사이클을 이루는 지 확인
            if (Find(parent, u) != Find(parent, v))
            {
                vertexCount++;
                // 둘을 같은 트리에 합쳐서 u-v를 잇는 다른 간선이 선택되지 않게 함
                Union(parent, u, v);
                sum += graph[i].Item3;
            }
            // MST의 총 간선 수는 총 정점의 수 - 1이다.
            if (vertexCount == n - 1) break;
        }
        Console.WriteLine(sum);
        sr.Close();
    }

    // x가 속한 트리의 루트 노드를 반환한다.
    public static int Find(int[] parent, int x)
    {
        // 루트 노드는 parent가 자기 자신이다.
        if (parent[x] == x) return x;
        // 재귀로 거슬러 올라가면서 자신의 parent가 루트가 되게 한다.
        return parent[x] = Find(parent, parent[x]);
    }

    // x와 y가 속한 트리를 합친다.
    public static void Union(int[] parent, int x, int y)
    {
        // 루트를 찾음
        int rootX = Find(parent, x);
        int rootY = Find(parent, y);

        // 한쪽의 루트를 다른 쪽으로 만든다.
        if (rootX != rootY) parent[rootX] = rootY;
    }
}
