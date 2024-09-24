using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

/// <summary>
/// p7576 - 토마토, G5
/// 시작 날짜 : 2023/9/12
/// </summary>

/*
시간 초과로 인한 미해결 문제
*/

public class Program
{
    public static List<List<int>> adj;
    public static List<bool> discovered;
    public static List<int> distance;
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));

        int[] input = sr.ReadLine().Split().Select(int.Parse).ToArray();
        (int M, int N) = (input[0], input[1]);

        List<List<int>> list = new List<List<int>>();
        
        for (int i = 0; i < N; i++)
        {
            list.Add(sr.ReadLine().Split().Select(int.Parse).ToList());
        }

        adj = new List<List<int>>();
        
        distance = Enumerable.Repeat(987654321, M * N).ToList();
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < M; j++)
            {
                adj.Add(new List<int>());
            }
        }

        int zeroNum = 0;
        List<int> start = new List<int>();
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < M; j++)
            {
                if (list[i][j] == -1)
                {
                    distance[i * M + j] = -1;
                    continue;
                }
                else if (list[i][j] == 0) { zeroNum++; }
                else if (list[i][j] == 1) { start.Add(i * M + j); }
                if (i != 0 && list[i - 1][j] != -1)
                    adj[i * M + j].Add((i - 1) * M + j);
                if (i != N - 1 && list[i + 1][j] != -1)
                    adj[i * M + j].Add((i + 1) * M + j);
                if (j != 0 && list[i][j - 1] != -1)
                    adj[i * M + j].Add(i * M + j - 1);
                if (j != M - 1 && list[i][j + 1] != -1)
                    adj[i * M + j].Add(i * M + j + 1);
            }
        }

        foreach (var item in start)
            BFS(item, M * N);
        if (zeroNum == 0) 
            Console.WriteLine(0);
        else 
            Console.WriteLine((distance.Max() == 987654321) ? -1 : distance.Max());
        sr.Close();
    }

    public static void BFS(int start, int totalNum)
    {
        Queue<int> queue = new Queue<int>();
        discovered = Enumerable.Repeat(false, totalNum).ToList();

        discovered[start] = true;
        queue.Enqueue(start);
        distance[start] = 0;
        while (queue.Count > 0)
        {
            int here = queue.Dequeue();

            for (int i = 0; i < adj[here].Count; i++)
            {
                int there = adj[here][i];
                if (!discovered[there])
                {
                    queue.Enqueue(there);
                    discovered[there] = true;
                    distance[there] = Math.Min(distance[here] + 1, distance[there]);
                }
            }
        }
    }
}