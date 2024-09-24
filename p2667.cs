using System;
using System.Linq;
using System.Collections.Generic;

/// <summary>
/// p2667 - 단지번호붙이기, S1
/// 해결 날짜 : 2023/9/5
/// </summary>

/*
DFS를 사용하는 문제
그래프의 모든 정점을 하나씩 스캔하여, 방문하지 않았다면 DFS로
탐색한 뒤, 한번에 탐색한 정점의 개수를 저장한다.
그렇게 한 뒤 DFS를 한 덩어리 수와 한 덩어리에서 DFS를 실행한 횟수를
출력한다.
*/

public class Program
{
    public static List<List<int>> adj;
    public static List<bool> visited;
    public static void Main(string[] args)
    {
        adj = new List<List<int>>();
        
        int N = int.Parse(Console.ReadLine());

        List<string> list = new List<string>();
        for (int i = 0; i < N; i++)
        {
            list.Add(Console.ReadLine());
        }
        visited = Enumerable.Repeat(false, N * N).ToList();
        /*
        N * N의 2차원 배열이 주어졌을 때
        인접 리스트를 위한 인덱스를 i * N + j로 한다.
         111 -> 0~2
         011 -> 3~5
         000 -> 6~8
         */

        // 각 정점을 연결
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                adj.Add(new List<int>());
                if (list[i][j] == '0') 
                {
                    visited[i * N + j] = true; // DFS로 방문하는 것을 방지
                    continue; 
                }
                // 배열에서 상하좌우로 인접한 칸들을 연결한다.
                if (i != 0 && list[i - 1][j] == '1')
                    adj[i * N + j].Add((i - 1) * N + j);
                if (i != N-1 && list[i + 1][j] == '1')
                    adj[i * N + j].Add((i + 1) * N + j);
                if (j != 0 && list[i][j - 1] == '1')
                    adj[i * N + j].Add(i * N + j - 1);
                if (j != N-1 && list[i][j + 1] == '1')
                    adj[i * N + j].Add(i * N + j + 1);
            }
        }

        DFSAll();
    }

    public static void DFS(int current, ref int count)
    {
        // 정점 방문 후 방문했다고 표시함
        visited[current] = true;
        count++;
        // 해당 정점과 인접한 정점들을 모두 방문 
        for (int i = 0; i < adj[current].Count; i++)
        {
            int there = adj[current][i];
            if (!visited[there])
            {
                DFS(there, ref count);
            }
        }
    }

    public static void DFSAll()
    {
        int countArea = 0;
        List<int> numApart = new List<int>();
        for (int i = 0; i < adj.Count; i++)
        {
            if (!visited[i])
            {
                // DFS를 시작한 횟수(즉, 모여 있는 부분 그래프의 개수)를 센다.
                countArea++;
                int count = 0;
                // DFS를 하면서 부분 그래프 내의 정점의 개수를 센다.
                DFS(i, ref count);
                // 정점의 개수를 저장
                numApart.Add(count);
            }
        }
        // 작은 순으로 출력하기 위해 정렬
        numApart.Sort();
        Console.WriteLine(countArea);
        foreach(int i in numApart)
        {
            Console.WriteLine(i);
        }
    }
}