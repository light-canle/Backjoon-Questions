using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

/// <summary>
/// p2178 - 미로 탐색, S1
/// 해결 날짜 : 2023/9/3
/// </summary>

/*
BFS를 이용해 (0,0)에서 (N-1, M-1)까지의 거리를 구하는 문제
여기서는 복잡한 구조를 사용했지만 훨씬 간단한 방법들도 많았을 것이다.
*/

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));

        int[] input = sr.ReadLine().Split().Select(int.Parse).ToArray();
        (int N, int M) = (input[0], input[1]);
        // 입력받은 미로판
        string[] space = new string[N];
        // 인접 리스트
        Dictionary<(int, int), List<(int, int)>> adj = 
            new Dictionary<(int, int), List<(int, int)>>();
        for (int i = 0; i < N; i++)
        {
            space[i] = sr.ReadLine();
        }

        // 모든 정점을 서로 연결시킴
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < M; j++)
            {
                // 벽은 건너뜀
                if (space[i][j] == '0') continue;
                // 해당 위치를 인접 리스트에 추가
                adj[(i, j)] = new List<(int, int)>();
                // 상하좌우 위치가 벽이 아니라면 인접 리스트에 추가
                // 반복문을 순회하면서 자연스럽게 양방향으로 연결되므로,
                // 한 번의 반복 내에서는 단방향으로 연결한다.
                if (i != 0)
                {
                    if (space[i - 1][j] == '1')
                    {
                        adj[(i, j)].Add((i - 1, j));
                    }
                }
                if (j != 0)
                {
                    if (space[i][j - 1] == '1')
                    {
                        adj[(i, j)].Add((i, j - 1));
                    }
                }
                if (i != N - 1)
                {
                    if (space[i + 1][j] == '1')
                    {
                        adj[(i, j)].Add((i + 1, j));
                    }
                }
                if (j != M - 1)
                {
                    if (space[i][j + 1] == '1')
                    {
                        adj[(i, j)].Add((i, j + 1));
                    }
                }
            }
        }
        int distance = BFS((0, 0), adj, N - 1, M - 1);
        Console.WriteLine(distance);
        sr.Close();
    }

    public static int BFS((int, int) start, 
        Dictionary<(int, int), List<(int, int)>> adj, int N, int M)
    {
        // 각 위치에서 시작점(0,0) 까지의 거리를 저장함
        Dictionary<(int, int), int> distance = new Dictionary<(int, int), int>();
        foreach(var pos in adj.Keys)
        {
            distance[pos] = -1;
        }
        // BFS를 위한 탐색 큐
        Queue<(int, int)> queue = new Queue<(int, int)>();
        // 시작점은 1로 잡고 시작
        distance[start] = 1;
        queue.Enqueue(start);
        while(queue.Count > 0)
        {
            (int, int) here = queue.First();
            queue.Dequeue();
            for (int i = 0; i < adj[here].Count; i++)
            {
                (int, int) there = adj[here][i];
                // 방문하지 않은 정점을 탐색함
                if (distance[there] == -1)
                {
                    queue.Enqueue(there);
                    distance[there] = distance[here] + 1;
                }
            }
        }
        // 원하는 위치까지와 시작점 사이의 거리 반환
        return distance[(N, M)];
    }
}
