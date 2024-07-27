using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new (new BufferedStream(Console.OpenStandardInput()));
        int[] size = sr.ReadLine().Split().Select(int.Parse).ToArray();
        (int V, int E) = (size[0], size[1]);
        Dictionary<int, List<(int, int)>> graph = new ();
        for (int i = 0; i < E; i++)
        {
            int[] input = sr.ReadLine().Split().Select(int.Parse).ToArray();
            int a = input[0];
            int b = input[1];
            int c = input[2];
            if (!graph.ContainsKey(a))
            {
                graph[a] = new List<(int, int)>();
            }
            if (!graph.ContainsKey(b))
            {
                graph[b] = new List<(int, int)>();
            }
            graph[a].Add((b, c));
            graph[b].Add((a, c));
        }
        int[] stopover = sr.ReadLine().Split().Select(int.Parse).ToArray();

        int[] distFromStart = new int[V + 1];
        int[] distFromSO1 = new int[V + 1];
        int[] distFromSO2 = new int[V + 1];

        if (E == 0)
        {
            Console.WriteLine(-1);
            return;
        }
        Dijsktra(graph, V, 1, distFromStart);
        Dijsktra(graph, V, stopover[0], distFromSO1);
        Dijsktra(graph, V, stopover[1], distFromSO2);

        int s_to_a = distFromStart[stopover[0]];
        int s_to_b = distFromStart[stopover[1]];
        int a_to_b = distFromSO1[stopover[1]];
        int b_to_a = distFromSO2[stopover[0]];
        int a_to_end = distFromSO1[V];
        int b_to_end = distFromSO2[V];

        int INF = 987654321;
        bool possible1 = s_to_a != INF && a_to_b != INF && b_to_end != INF;
        bool possible2 = s_to_b != INF && b_to_a != INF && a_to_end != INF;
        if (!possible1 && !possible2)
        {
            Console.WriteLine(-1);
        }
        else
        {
            int ret = Math.Min((possible1 ? s_to_a + a_to_b + b_to_end : INF), (possible2 ? s_to_b + b_to_a + a_to_end : INF));
            Console.WriteLine(ret);
        }
        sr.Close();
    }

    public static void Dijsktra(Dictionary<int, List<(int, int)>> graph, int vertexCount, int start, int[] dist)
    {
        int N = vertexCount;

        for (int i = 1; i <= N; i++)
        {
            dist[i] = 987654321;
        }
        dist[start] = 0;

        PriorityQueue<(int, int), int> pq = new ();
        pq.Enqueue((start, 0), 0);

        while (pq.Count > 0)
        {

            int cur = pq.Peek().Item1;
            int curDist = pq.Peek().Item2;
            pq.Dequeue();

            if (curDist > dist[cur])
                continue;

            if (graph[cur].Count > 0)
            {
                foreach (var (next, weight) in graph[cur])
                {
                    int nextDist = curDist + weight;
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
