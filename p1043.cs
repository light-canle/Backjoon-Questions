#pragma warning disable CS8604, CS8602, CS8600

using System;
using System.Linq;
using System.Collections.Generic;

// p1043 - 거짓말 (G4)
// #그래프 #DFS
// 2025.9.21 solved

public class Program
{
    public static Dictionary<int, List<int>> adj;
    public static bool[] visited;
    public static bool[] know; // 진실을 아는 사람들의 명단
    public static void Main(string[] args)
    {
        int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        int n = input[0], m = input[1];

        
        know = new bool[n + 1];
        int[] knowTruth = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        for (int i = 1; i <= knowTruth[0]; i++)
        {
            know[knowTruth[i]] = true;
        }

        visited = new bool[n + 1];
        adj = new();
        for (int i = 1; i <= n; i++)
        {
            adj[i] = new();
        }

        // 각 파티에 대해서 참석한 모두를 그래프로 연결한다.
        List<List<int>> party = new();
        for (int i = 0; i < m; i++)
        {
            party.Add(Console.ReadLine().Split().Select(int.Parse).ToList());
            party[i].RemoveAt(0);

            // 서로 연결하기
            for (int j = 0; j < party[i].Count - 1; j++)
            {
                for (int k = j + 1; k < party[i].Count; k++)
                {
                    if (!adj[party[i][j]].Contains(party[i][k]))
                        adj[party[i][j]].Add(party[i][k]);
                    if (!adj[party[i][k]].Contains(party[i][j]))
                        adj[party[i][k]].Add(party[i][j]);
                }
            }
        }

        // DFS를 사용해서 진실을 듣게 되는 사람을 알아낸다.
        for (int i = 1; i <= knowTruth[0]; i++)
        {
            DFS(knowTruth[i]);
        }

        // 위에서 갱신한 정보를 바탕으로 진실을 끝까지 알지 못하는 사람들만으로
        // 이루어진 파티의 개수를 구한다.
        int canTellLie = 0;
        foreach (var p in party)
        {
            bool knownPersonExist = false;
            foreach (var person in p)
            {
                knownPersonExist = knownPersonExist || know[person];
            }
            if (!knownPersonExist) canTellLie++;
        }

        Console.WriteLine(canTellLie);
    }

    public static void DFS(int cur)
    {
        know[cur] = true;
        visited[cur] = true;

        foreach (var next in adj[cur])
        {
            if (!visited[next])
            {
                DFS(next);
            }
        }
    }
}
