using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

/// <summary>
/// p10026 - 적록색약, G5
/// 해결 날짜 : 2023/9/8
/// 이 문제를 풀고 Class 3으로 승격
/// </summary>

/*
DFS를 이용해서 부분 그래프의 수를 세는 문제이다.
상하좌우가 같은 문자인 것은 연결되어 있는 것으로 하고,
서로 다른 색깔 영역의 수를 세는 문제였는데,
적록색약의 경우에는 R, G를 같은 것으로 보고 인접 리스트를 다르게 했다.
*/

public class Program
{
    public static List<List<int>> adj;
    public static List<List<int>> adj2;
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        int size = int.Parse(sr.ReadLine());
        adj = new List<List<int>>();
        adj2 = new List<List<int>>();
        // 기본 영역을 받음
        List<string> list = new List<string>();
        for (int i = 0; i < size; i++)
        {
            list.Add(sr.ReadLine());
        }
        // 새로운 리스트를 하나 더 만들고 여기서는 R, G를 동일 문자로 바꾼다.
        List<string> colBList = new List<string>();
        for (int i = 0; i < size; i++)
        {
            colBList.Add(list[i]);
            for (int j = 0; j < size; j++)
            {
                colBList[i] = colBList[i].Replace('R', 'r');
                colBList[i] = colBList[i].Replace('G', 'r');
            }
        }
        // 두 리스트의 정보를 통해 2개의 인접 리스트를 만든다.
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                adj.Add(new List<int>());
                adj2.Add(new List<int>());
                // 상하좌우에 서로 같은 문자끼리는 인접 리스트에 추가한다.
                char current = list[i][j];

                if (i != 0 && current == list[i - 1][j])
                    adj[i * size + j].Add((i - 1) * size + j);
                if (i != size - 1 && current == list[i + 1][j])
                    adj[i * size + j].Add((i + 1) * size + j);
                if (j != 0 && current == list[i][j - 1])
                    adj[i * size + j].Add(i * size + j - 1);
                if (j != size - 1 && current == list[i][j + 1])
                    adj[i * size + j].Add(i * size + j + 1);

                current = colBList[i][j];
                if (i != 0 && current == colBList[i - 1][j])
                    adj2[i * size + j].Add((i - 1) * size + j);
                if (i != size - 1 && current == colBList[i + 1][j])
                    adj2[i * size + j].Add((i + 1) * size + j);
                if (j != 0 && current == colBList[i][j - 1])
                    adj2[i * size + j].Add(i * size + j - 1);
                if (j != size - 1 && current == colBList[i][j + 1])
                    adj2[i * size + j].Add(i * size + j + 1);
            }
        }
        // DFS로 탐색
        int areaNum = DFSAll(adj, size);
        int colBareaNum = DFSAll(adj2, size);

        Console.WriteLine($"{areaNum} {colBareaNum}");
        sr.Close();
    }

    public static void DFS(List<List<int>> adj, List<bool> visited, int current)
    {
        visited[current] = true;

        for (int i = 0; i < adj[current].Count; i++)
        {
            int there = adj[current][i];
            if (!visited[there])
            {
                DFS(adj, visited, there);
            }
        }
    }

    public static int DFSAll(List<List<int>> adj, int size)
    {
        List<bool> visited = Enumerable.Repeat(false, size * size).ToList();

        int areaCount = 0;
        for (int i = 0; i < adj.Count; i++)
        {
            if (!visited[i])
            {
                areaCount++;
                DFS(adj, visited, i);
            }
        }

        return areaCount;
    }
}