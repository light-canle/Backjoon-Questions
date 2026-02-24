// p1389 - 케빈 베이컨의 6단계 법칙 (S1)
// #BFS #완전 탐색 #최단 경로
// 2026.2.22 solved

StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
int n = input[0], m = input[1];
Dictionary<int, List<int>> graph = new();
for (int i = 1; i <= n; i++)
{
    graph[i] = new();
}

for (int i = 0; i < m; i++)
{
    int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    int a = line[0], b = line[1];
    // 양방향 연결
    graph[a].Add(b);
    graph[b].Add(a);
}

int minDist = int.MaxValue;
int num = 0;
for (int i = 1; i <= n; i++)
{
    int d = Distance(graph, i, n);
    if (minDist > d)
    {
        minDist = d;
        num = i;
    }
}
Console.WriteLine(num);

// 그래프에서 start를 기점으로 다른 정점에 이르는 데에 드는 거리의 합을 구한다.
int Distance(Dictionary<int, List<int>> graph, int start, int total)
{
    // 거리 리스트 (start는 0으로)
    int[] dist = Enumerable.Repeat(int.MaxValue, total + 1).ToArray();
    dist[start] = 0;
    // 해당 정점을 방문했는가
    bool[] visited = new bool[total + 1];
    // 방문 순서 큐
    Queue<int> q = new Queue<int>();
    q.Enqueue(start);
    while (q.Count > 0)
    {
        int r = q.Dequeue();
        if (visited[r]) continue; // 이미 방문한 정점 skip
        visited[r] = true;
        // 그 정점의 인접한 정점에 대해서 그 정점을 큐에 넣고 거리를 갱신한다.
        for (int i = 0; i < graph[r].Count; i++)
        {
            int w = graph[r][i];
            if (!visited[w])
            {
                q.Enqueue(w);
                dist[w] = Math.Min(dist[w], dist[r] + 1); // 모든 거리는 1이다.
            }
        }
    }
    int distSum = 0;
    for (int i = 1; i < dist.Length; i++)
    {
        distSum += dist[i];
    }
    return distSum;
}
