#pragma warning disable CS8604, CS8602, CS8600

using System;
using System.Linq;
using System.Collections.Generic;

// p4386 - 별자리 만들기 (G3)
// #그래프 #MST #분리 집합
// 2025.10.28

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        // 점들의 위치를 받는다.
        List<(double, double)> dots = new();
        for (int i = 0; i < n; i++)
        {
            double[] dot = Array.ConvertAll(Console.ReadLine().Split(), double.Parse);
            dots.Add((dot[0], dot[1]));
        }

        // 점 하나에서 다른 것까지의 거리를 담는 리스트
        // (i, j, Distance(i, j))를 담음
        List<(int, int, double)> adj = new();

        // 각각의 점들 사이의 거리를 저장
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                adj.Add((i, j, Distance(dots[i], dots[j])));
            }
        }
        // 거리 순으로 오름차순 정렬
        adj.Sort((a, b) => a.Item3.CompareTo(b.Item3));
        // Union-Find를 위한 준비
        int[] parent = Enumerable.Range(0, n).ToArray();

        // 최소 거리의 합
        double sum = 0;
        int vertexCount = 0;
        // 두 점을 이은 선분들에 대해서 탐색
        for (int k = 0; k < adj.Count; k++)
        {
            int u = adj[k].Item1;
            int v = adj[k].Item2;
            // 이미 결합된 점이 아닌 경우에만 연결 (즉, 해당 직선을 선택한 뒤 연결)
            if (FindRoot(parent, u) != FindRoot(parent, v))
            {
                vertexCount++;
                Union(parent, u, v);
                sum += adj[k].Item3;
            }
            // n - 1의 선분으로 n개가 모두 연결되게 했으므로 종료
            if (vertexCount == n - 1) break;
        }
        // 거리의 합을 출력
        Console.WriteLine(sum);
    }
    // 두 점 사이 거리를 구함
    public static double Distance((double, double) a, (double, double) b)
    {
        return Math.Sqrt(Math.Pow(b.Item1 - a.Item1, 2) + Math.Pow(b.Item2 - a.Item2, 2));
    }
    // 해당 요소가 속한 트리의 루트를 찾는다.
    public static int FindRoot(int[] parent, int x)
    {
        if (parent[x] == x) return x;
        return parent[x] = FindRoot(parent, parent[x]);
    }
    // 두 요소를 같은 집합에 속하게 한다.
    public static void Union(int[] parent, int x, int y)
    {
        int rootX = FindRoot(parent, x);
        int rootY = FindRoot(parent, y);

        if (rootX != rootY) parent[rootX] = rootY;
    }
}
