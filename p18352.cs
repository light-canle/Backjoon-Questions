using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

// p18352 - 특정 거리의 도시 찾기 (S2)
// #그래프 #다익스트라 #너비 우선 탐색 #우선순위 큐
// 2025.4.28 solved

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput()));
        int[] input = sr.ReadLine().Split().Select(int.Parse).ToArray();
        // 정점의 수, 도로의 수(단방향), 찾으려는 거리, 시작점
        int n = input[0], m = input[1], k = input[2], x = input[3];

        // 정점, 연결된 정점으로 이루어진 딕셔너리
        Dictionary<int, List<(int, int)>> graph = new();
        // 연결된 정점끼리의 정보 추가
        for (int i = 0; i < m; i++)
        {
            input = sr.ReadLine().Split().Select(int.Parse).ToArray();
            int a = input[0];
            int b = input[1];
            int c = 1; // 정점 사이 거리는 1이다.
            // 없는 정점에 대한 정보 추가
            if (!graph.ContainsKey(a))
            {
                graph[a] = new List<(int, int)>();
            }
            if (!graph.ContainsKey(b))
            {
                graph[b] = new List<(int, int)>();
            }
            // a에서 b로 단방향 연결
            graph[a].Add((b, c));
        }

        int[] dist = new int[n + 1];
        List<int> ret = new(); // 거리가 k인 정점들을 담을 리스트
        Dijsktra(graph, n, x, dist);
        // 거리가 k인 것을 찾음
        for (int i = 1; i <= n; i++)
        {
            if (dist[i] == k)
            {
                ret.Add(i);
            }
        }

        // 거리가 k인 정점이 없으면 -1, 있으면 오름차순으로 출력
        if (ret.Count == 0)
        {
            sw.WriteLine(-1);
        }
        else
        {
            foreach (int v in ret)
            {
                sw.WriteLine(v);
            }
        }

        sw.Flush();
        sw.Close();
        sr.Close();
    }

    public static void Dijsktra(Dictionary<int, List<(int, int)>> graph, int vertexCount, int start, int[] dist)
    {
        int N = vertexCount;
        // 거리를 무한으로 초기화하고 시작점의 거리는 0으로
        for (int i = 1; i <= N; i++)
        {
            dist[i] = 987654321;
        }
        dist[start] = 0;

        // 우선순위 큐 사용 - (int, int), int에서 (a, b)는 다음 정점, 거리를 나타내고, c는 우선도이다.
        // 우선도가 '낮은' 요소가 먼저 PQ에서 나오게 된다.
        PriorityQueue<(int, int), int> pq = new();
        pq.Enqueue((start, 0), 0);

        while (pq.Count > 0)
        {

            int cur = pq.Peek().Item1;
            int curDist = pq.Peek().Item2;
            pq.Dequeue();

            // 거리가 더 멀면 갱신하지 않는다.
            if (curDist > dist[cur])
                continue;

            // 연결된 정점들에 대하여 계산
            if (graph[cur].Count > 0)
            {
                foreach (var (next, weight) in graph[cur])
                {
                    // 현재 간선 + 다음 간선의 길이를 합함
                    int nextDist = curDist + weight;
                    // 거리가 더 짧은 경우 갱신하고, 큐에 넣는다.
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
