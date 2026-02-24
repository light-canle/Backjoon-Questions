// p25418 - 정수 a를 k로 만들기 (S3)
// #BFS
// 2026.2.22 solved

int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0], m = input[1];
Dictionary<int, List<int>> graph = new();
for (int i = n; i <= m; i++)
{
    graph[i] = new();
}

// 1 더한 수, 2 곱한 수에 대한 단방향 간선 추가
for (int i = n; i < m; i++)
{
    graph[i].Add(i + 1);
    if (i * 2 <= m) graph[i].Add(i * 2);
}

Console.WriteLine(Distance(graph, n, m));

// start부터 end까지의 거리를 구한다.
int Distance(Dictionary<int, List<int>> graph, int start, int end)
{
    int len = end - start + 1;
    // 시작점 빼고 거리 최댓값으로 초기화
    // start가 dist[0], end가 dist[len - 1]이다.
    int[] dist = Enumerable.Repeat(int.MaxValue, len).ToArray();
    dist[0] = 0;
    // 방문 여부
    // start 방문 여부가 visited[0]에, end 방문 여부가 visited[len - 1]에 저장된다.
    bool[] visited = new bool[len];
    Queue<int> q = new Queue<int>();
    q.Enqueue(start);
    while (q.Count > 0)
    {
        int r = q.Dequeue();
        // 위에서 visited와 dist의 정의에 의해 start를 빼주어야 한다.
        if (visited[r - start]) continue;
        visited[r - start] = true;
        for (int i = 0; i < graph[r].Count; i++)
        {
            int w = graph[r][i];
            if (!visited[w - start])
            {
                // 큐에 넣음
                q.Enqueue(w);
                // 거리 최솟값 갱신
                dist[w - start] = Math.Min(dist[w - start], dist[r - start] + 1);
                // 종점을 만났으면 반복을 끝낸다.
                if (w == end) break;
            }
        }
    }
    return dist[end - start];
}
