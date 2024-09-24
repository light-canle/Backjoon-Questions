using System;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections.Generic;

/// <summary>
/// p14940 - 쉬운 최단거리, S1
/// 해결 날짜 : 2023/9/9
/// </summary>

/*
BFS를 이용해서 시작점까지의 거리를 출력하는 문제
벽으로 막힌 부분은 -1로 출력한다.
*/

public class Program
{
    public static List<List<int>> adj;
    public static List<bool> discovered;
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput()));
        StringBuilder output = new StringBuilder();
        int[] input = sr.ReadLine().Split().Select(int.Parse).ToArray();
        (int N, int M) = (input[0], input[1]);
        // 지도 데이터 입력
        List<int> list = new List<int>();
        for (int i = 0; i < N; i++)
        {
            list.AddRange(sr.ReadLine().Split().Select(int.Parse));
        }
        // 각 정점들의 발견 여부 저장
        discovered = Enumerable.Repeat(false, M * N).ToList();
        
        // 인접 리스트 초기화
        adj = new List<List<int>>();
        for (int i = 0; i < N * M; i++)
        {
            adj.Add(new List<int>());
        }

        int start = 0;
        for (int i = 0; i < N; ++i)
        {
            for (int j = 0; j < M; ++j)
            {
                // 시작점 위치 찾기
                if (list[i * M + j] == 2) start = i * M + j;
                // 벽인 경우 탐색 못하게 막음
                if (list[i * M + j] == 0)
                {
                    discovered[i * M + j] = true;
                    continue;
                }
                // 상하좌우 벽이 아닌 인접한 칸끼리 연결
                if (i != 0 && list[(i - 1) * M + j] != 0) 
                    adj[i * M + j].Add((i - 1) * M + j);
                if (i != N - 1 && list[(i + 1) * M + j] != 0)
                    adj[i * M + j].Add((i + 1) * M + j);
                if (j != 0 && list[i * M + j - 1] != 0)
                    adj[i * M + j].Add(i * M + j - 1);
                if (j != M - 1 && list[i * M + j + 1] != 0)
                    adj[i * M + j].Add(i * M + j + 1);
            }
        }
        // 너비 우선 탐색으로 시작점부터의 거리 측정
        List<int> distance = BFS(list, start, N, M);

        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < M; j++)
            {
                output.Append(distance[i * M + j] + " ");
            }
            output.AppendLine();
        }

        sw.WriteLine(output);

        sw.Flush();
        sr.Close();
        sw.Close();
    }

    public static List<int> BFS(List<int> list, int start, int N, int M)
    {
        // 방문할 정점의 순서 저장
        Queue<int> queue = new Queue<int>();
        // 거리를 저장(접근 불가능한 곳은 -1)
        List<int> distance = Enumerable.Repeat(-1, N * M).ToList();

        // 벽, 시작 위치는 0으로 바꿈
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < M; j++)
            {
                if (list[i * M + j] == 0 || list[i * M + j] == 2) 
                    distance[i * M + j] = 0;
            }
        }
        // 첫 번째 정점 발견
        discovered[start] = true;
        queue.Enqueue(start);

        while (queue.Count > 0) 
        {
            int here = queue.First();
            queue.Dequeue();
            // 인접한 정점들 모두 탐색
            for (int i = 0; i < adj[here].Count; i++)
            {
                int there = adj[here][i];
                if (!discovered[there])
                {
                    queue.Enqueue(there);
                    discovered[there] = true;
                    // 거리는 현재 정점보다 1 크게 설정
                    distance[there] = distance[here]+1;
                }
            }
        }
        return distance;
    }
}