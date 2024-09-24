using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

/// <summary>
/// p21736 - 헌내기는 친구가 필요해, S2
/// 해결 날짜 : 2023/9/7
/// </summary>

/*
시작점(I)에서 부터 DFS를 수행해서 X에 막히지 않고 만날 수 있는
사람(P)의 수를 세는 문제
*/

public class Program
{
    public static List<List<int>> adj;
    public static List<bool> visited;
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        int[] size = sr.ReadLine().Split().Select(int.Parse).ToArray();
        (int N, int M) = (size[0], size[1]);
        
        List<string> list = new List<string>();
        adj = new List<List<int>>();
        visited = Enumerable.Repeat(false, N*M).ToList();
        for (int i = 0; i < N; i++)
        {
            string input = sr.ReadLine() ?? "";
            if (input == "" || input == null) continue;
            list.Add(input);
        }

        for (int i = 0; i < N * M; i++)
        {
            adj.Add(new List<int>());
        }

        int start = 0;
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < M; j++)
            {
                // 벽인 경우 스킵, 방문하지 못하게 막음
                if (list[i][j] == 'X')
                {
                    visited[i * M + j] = true;
                    continue;
                }
                // 탐색 시작 위치
                if (list[i][j] == 'I')
                {
                    start = i * M + j;
                }
                // 상하좌우로 벽이 아닌 곳을 연결
                if (i != 0 && list[i - 1][j] != 'X')
                    adj[i * M + j].Add((i - 1) * M + j);
                if (i != N - 1 && list[i + 1][j] != 'X')
                    adj[i * M + j].Add((i + 1) * M + j);
                if (j != 0 && list[i][j - 1] != 'X')
                    adj[i * M + j].Add(i * M + j - 1);
                if (j != M - 1 && list[i][j + 1] != 'X')
                    adj[i * M + j].Add(i * M + j + 1);
            }
        }
        int count = 0;
        DFS(list, start, N, M, ref count);

        if (count == 0) { Console.WriteLine("TT"); }
        else { Console.WriteLine(count); }
        sr.Close();
    }

    public static void DFS(List<string> list, int current, 
        int N, int M, ref int count)
    {
        visited[current] = true;
        // 탐색하면서 만난 사람 수를 추가
        if (list[current / M][current % M] == 'P') { count++; }

        for (int i = 0; i < adj[current].Count; i++)
        {
            // DFS로 인접한 정점 방문
            int there = adj[current][i];
            if (!visited[there])
            {
                DFS(list, there, N, M, ref count);
            }
        }
    }
}