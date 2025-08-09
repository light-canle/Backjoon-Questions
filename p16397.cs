using System;
using System.Collections.Generic;

// p16397 - 탈출 (G4)
// #그래프 #BFS
// 2025.8.9 solved

public class Program
{
    public static Dictionary<int, List<int>> adj;
    public static bool[] visited;
    public static int[] distance;
    public static void Main(string[] args)
    {
        int[] size = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        int n = size[0], t = size[1], g = size[2];
        visited = new bool[100000];
        distance = Enumerable.Repeat(987654321, 100000).ToArray(); // 거리 무한으로 초기화함

        // 인접 리스트 - 0 ~ 99999까지 A, B 규칙으로 서로 만들 수 있는 수끼리 연결한다.
        adj = new();
        for (int i = 0; i < 100000; i++)
        {
            adj[i] = new();
            // 규칙 A (1을 더함)
            if (i != 99999)
            {
                adj[i].Add(i + 1);
            }
            // 규칙 B (0이거나 2배 했을 때 99999를 초과하면 적용하지 않음)
            if (i * 2 > 99999 || i == 0) continue;
            adj[i].Add(RuleB(i));

            // 중복 방지 (예시로 11은 12 2개가 들어간다.)
            adj[i] = adj[i].Distinct().ToList();
        }
        distance[n] = 0; // 시작점의 거리는 0이다.
        BFS(n);
        // 원하는 수에 t번 안에 도달 가능한가?
        Console.WriteLine(distance[g] <= t ? distance[g] : "ANG");
    }
    public static void BFS(int s)
    {
        Queue<int> queue = new();
        queue.Enqueue(s);
        while (queue.Count > 0)
        {
            int r = queue.Dequeue();
            if (visited[r]) continue;
            visited[r] = true; // 방문 표시
            for (int i = 0; i < adj[r].Count; i++)
            {
                int w = adj[r][i];
                if (!visited[w]){
                    queue.Enqueue(w);
                    // 거리 갱신 (기존 것이 더 작을 수도 있으므로 Min 사용)
                    distance[w] = Math.Min(distance[w], distance[r] + 1);
                }
            }
        }
    }

    // 수를 2배한 뒤, 가장 큰 자리 수를 1 뺀다.
    // ex) 8764 -> 17528 -> (가장 큰 만자리 수를 1 뺌) 7528
    // ex) 385 -> 770 -> 670 
    public static int RuleB(int n)
    {
        n *= 2;
        int digit = n.ToString().Length;
        int pow = (int)Math.Pow(10, digit - 1);
        return n - pow;
    }
}
