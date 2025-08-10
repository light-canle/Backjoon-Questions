using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

// p1238 - 파티 (G3)
// #그래프 #다익스트라
// 2025.8.10 solved

public class Program
{
    public static Dictionary<int, List<(int, int)>> adj; // 인접 리스트 : Key는 시작점, Value는 (도착점, 거리)로 이루어진 리스트
    public static List<List<int>> distance; // distance[i]는 i번 마을에서 각각의 다른 마을로 갈 때의 거리를 저장한다.
    public static void Main(string[] args)
    {
        StreamReader sr = new (new BufferedStream(Console.OpenStandardInput()));
        int[] size = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        int n = size[0], m = size[1], x = size[2];
        // 거리 초기화 (무한으로 설정)
        distance = Enumerable.Repeat(new List<int>(), n + 1).ToList();
        for (int i = 0; i < n + 1; i++)
        {
            distance[i] = Enumerable.Repeat(987654321, n + 1).ToList();
        }

        // 인접 리스트 - m개의 도로를 받고 도로의 양 끝 마을을 연결 (도로는 단방향이다.)
        adj = new();
        for (int i = 0; i < m; i++)
        {
            int[] info = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int start = info[0], end = info[1], time = info[2];
            if (!adj.ContainsKey(start)) adj[start] = new();
            adj[start].Add((end, time));
        }

        // 다익스트라 알고리즘으로 각각의 마을로 가는 최단 경로를 탐색
        for (int i = 0; i < n; i++)
        {
            Dijsktra(adj, i + 1, distance[i + 1]);
        }

        // 어떤 마을에서 X번 마을로 갔다가 다시 돌아오는 거리가 가장 큰 것을 구함
        int maxDist = 0;
        for (int i = 1; i <= n; i++)
        {
            maxDist = Math.Max(maxDist, distance[i][x] + distance[x][i]);
        }
        Console.WriteLine(maxDist);
        sr.Close();
    }
    public static void Dijsktra(Dictionary<int, List<(int, int)>> graph, int start, List<int> dist)
    {
        dist[start] = 0; // 시작점에서의 거리는 0으로 한다.

        // 우선순위 큐 정의
        // C#에서 우선순위 큐는 우선순위 값이 낮은 것을 우선적으로 내보낸다. 
        // 즉, 거리가 작은 쪽이 먼저 dequeue되도록 할 수 있다.
        PriorityQueue<(int, int), int> pq = new ();
        pq.Enqueue((start, 0), 0);

        while (pq.Count > 0)
        {
            // 거리가 제일 낮은 것을 꺼냄 - pq를 이용하면 자연스럽게 거리가 제일 짧은 것을 탐색하게 됨
            int cur = pq.Peek().Item1;
            int curDist = pq.Peek().Item2;
            pq.Dequeue();

            // 탐색하려는 경로 길이가 지금까지 구한 것 보다 길면 굳이 탐색할 이유가 없다.
            if (curDist > dist[cur])
                continue;
            // 인접한 경로가 있는 경우 탐색 실시
            if (graph[cur].Count > 0)
            {
                foreach (var (next, weight) in graph[cur])
                {
                    // 탐색한 경로에 따른 누적 거리 계산 (지금까지 경로에 cur를 거쳐서 next로 가는 경로)
                    int nextDist = curDist + weight;
                    // 그 구한 거리가 지금까지 구한 것 보다 짧으면 갱신
                    if (nextDist < dist[next])
                    {
                        dist[next] = nextDist;
                        pq.Enqueue((next, nextDist), nextDist);
                    }
                }
            }
        }
    }
}
