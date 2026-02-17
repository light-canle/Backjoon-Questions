#pragma warning disable CS8604, CS8602, CS8600

// p10971 - 외판원 순회 2 (S2)
// #TSP #백트래킹 #완전 탐색
// 2026.2.18 solved (2.17)

public class Program
{
    public static int[] order;                           // 도시 방문 순서
    public static bool[] visited;                        // 이 도시에 방문했는지 여부
    public static int minDistance = int.MaxValue;        // 구하고자 하는 최소 거리
    public static List<List<int>> distance;              // 도시와 도시 사이 거리
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        distance = new();
        order = new int[n];
        visited = new bool[n];
        for (int i = 0; i < n; i++)
        {
            distance.Add(Console.ReadLine().Split().Select(int.Parse).ToList());
        }
        TSP(n, 0);
        Console.WriteLine(minDistance);
    }

    public static void TSP(int n, int depth)
    {
        if (n == depth)
        {
            GetDistance(n);
            return;
        }

        for (int i = 0; i < n; i++)
        {
            if (!visited[i])
            {
                visited[i] = true;
                order[depth] = i;
                TSP(n, depth + 1);
                visited[i] = false;
            }
        }
    }

    public static void GetDistance(int n)
    {
        // 계산된 거리
        int totalDist = 0;
        // 주어진 순서를 탐색하는 도중 W[i][j] = 0인 것을 만나면 길이 없다는 뜻이다.
        // 이 경우 즉시 반복을 중단한 뒤 최솟값 갱신을 하지 않는다.
        bool noRoad = false;
        for (int i = 0; i < n; i++)
        {
            // 마지막 도시는 처음 도시와 연결
            if (i == n - 1)
            {
                if (distance[order[i]][order[0]] == 0)
                {
                    noRoad = true; break;
                }
                totalDist += distance[order[i]][order[0]];
            }
            // 현재 도시와 순서 상으로 다음 도시 사이 연결 확인
            else
            {
                if (distance[order[i]][order[i + 1]] == 0)
                {
                    noRoad = true; break;
                }
                totalDist += distance[order[i]][order[i + 1]];
            }
        }
        if (!noRoad)
        {
            minDistance = Math.Min(minDistance, totalDist);
        }
    }
}
