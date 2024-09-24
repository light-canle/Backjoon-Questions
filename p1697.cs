using System;
using System.Linq;
using System.Collections.Generic;

/// <summary>
/// p1697 - 숨바꼭질, S1
/// 해결 날짜 : 2023/9/10 (Solved.ac에는 9/9로 기록)
/// </summary>

/*
BFS를 이용해서 풀 수 있는 문제
각각의 수를 -1, +1, *2한 수와 연결된 것으로 보고 start부터 end까지
BFS로 순회하며 거리를 측정하는 방식으로 최소 시간을 구할 수 있다.
단, start가 end보다 클 수도 있는데 이때는 x2하는 방법은 쓸 수 없으므로
이 둘의 차이가 최소 시간이 된다.
*/

public class Program
{
    public static List<List<int>> adj;
    public static List<bool> discovered;
    public static void Main(string[] args)
    {
        int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
        (int start, int end) = (input[0], input[1]);
        if (start < end)
        {
            adj = new List<List<int>>();
            discovered = Enumerable.Repeat(false, end * 2 + 1).ToList();
            // 0 ~ end * 2까지 각각의 인접 리스트 생성
            for (int i = 0; i <= end * 2; i++)
            {
                adj.Add(new List<int>());
            }
            // 각 정점끼리 연결
            for (int i = 0; i <= end * 2; ++i)
            {
                // end 이후부터는 x2를 해줄 필요가 없다.
                if (0 < i && i <= end)
                    adj[i].Add(i * 2);
                if (i != 0)
                    adj[i].Add(i - 1);
                if (i != end * 2)
                    adj[i].Add(i + 1);
                adj[i] = adj[i].Distinct().ToList();
            }

            List<int> distance = BFS(start, end);

            Console.WriteLine(distance[end]);
        }
        // start가 end보다 클 경우에는 둘의 차이가 최소 시간이다.
        else
        {
            Console.WriteLine(start - end);
        }
    }

    public static List<int> BFS(int start, int end)
    {
        Queue<int> queue = new Queue<int>();
        // 거리 수열
        List<int> distance = Enumerable.Repeat(0, end * 2 + 1).ToList();

        discovered[start] = true;
        queue.Enqueue(start);

        while (queue.Count > 0) 
        {
            // 해당 정점 탐색
            int here = queue.First();
            queue.Dequeue();
            // 목표 지점을 찾은 경우 탐색 종료
            if (here == end) break;
            // 인접한 모든 정점에 대해 반복
            for (int i = 0; i < adj[here].Count; i++)
            {
                int there = adj[here][i];
                if (!discovered[there])
                {
                    queue.Enqueue(there);
                    discovered[there] = true;
                    // 거리는 기존의 정점보다 1 큰 것으로 한다.
                    distance[there] = distance[here]+1;
                }
            }
        }
        return distance;
    }
}