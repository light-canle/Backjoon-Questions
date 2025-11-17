#pragma warning disable CS8604, CS8602

using System;
using System.Linq;
using System.Collections.Generic;

// p10282 - 해킹 (G4)
// #다익스트라 #그래프
// 2025.11.17 solved

public class Program
{
    public const int INF = 987654321;
    // <정점 번호, 정점 리스트 : (다른 정점 번호, 거리)>
    public static Dictionary<int, List<(int, int)>> adj;
    public static bool[] visited;
    public static int[] distance;
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        int t = int.Parse(sr.ReadLine());

        for (int i = 0; i < t; i++)
        {
            int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int n = input[0], d = input[1], c = input[2];

            adj = new();
            visited = new bool[n + 1];
            distance = Enumerable.Repeat(INF, n + 1).ToArray();
            distance[c] = 0;

            for (int j = 1; j <= n; j++)
            {
                adj[j] = new();
            }

            for (int j = 0; j < d; j++)
            {
                int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                int a = line[0], b = line[1], s = line[2];
                adj[b].Add((a, s));
            }

            Dijkstra(c);
            // 감염된 컴퓨터 수를 센다. (INF가 아니면 감염됨)
            int infectedComputer = 0;
            int maxTime = 0;
            for (int j = 1; j <= n; j++)
            {
                if (distance[j] == INF) continue;
                infectedComputer++;
                maxTime = Math.Max(maxTime, distance[j]);
            }
            Console.WriteLine($"{infectedComputer} {maxTime}");
        }
        sr.Close();
    }

    public static void Dijkstra(int start)
    {
        // <(정점 번호, 거리), 거리>
        PriorityQueue<(int, int), int> pq = new();
        pq.Enqueue((start, 0), 0);

        while (pq.Count > 0)
        {
            (int curNode, int cost) = pq.Dequeue();
            // 지금 꺼낸 정보보다 더 짧은 경로가 이미 있다.
            if (distance[curNode] < cost) continue;
            // 인접한 정점에 대해 조사
            foreach (var next in adj[curNode])
            {
                (int nextNode, int nextCost) = next;
                nextCost += cost;
                // 더 짧은 경로를 발견한 경우 갱신
                if (distance[nextNode] > nextCost)
                {
                    distance[nextNode] = nextCost;
                    pq.Enqueue((nextNode, nextCost), nextCost);
                }
            }
        }
    }
}
