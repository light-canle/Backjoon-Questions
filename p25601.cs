// p25601 - 자바의 형변환 (S1)
// #DFS #트리
// 2026.3.9 solved

public class Program
{
    // DFS에서 쓰는 해당 정점을 방문했는지 여부를 담는 맵
    public static Dictionary<string, bool> visited = new();
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        int n = int.Parse(sr.ReadLine());
        // key가 자식 노드, Value가 key의 부모 노드를 담은 리스트이다.
        // 실제로 부모 노드는 1개이지만, DFS 함수의 인자를 일치시키기 위해 리스트를 썼다.
        Dictionary<string, List<string>> toParent = new();
        // key가 부모 노드, value가 key의 자식 노드를 담은 리스트이다.
        Dictionary<string, List<string>> toChild = new();
        for (int i = 0; i < n - 1; i++)
        {
            string[] input = sr.ReadLine().Split(' ');
            string child = input[0], parent = input[1];

            // DFS에서 값이 없는 경우를 방지하기 위해 이름이 등장할 때마다 각 딕셔너리에 넣어준다.
            if (!toParent.ContainsKey(child)) toParent[child] = new();
            if (!toParent.ContainsKey(parent)) toParent[parent] = new();
            if (!toChild.ContainsKey(child)) toChild[child] = new();
            if (!toChild.ContainsKey(parent)) toChild[parent] = new();
            if (!visited.ContainsKey(child)) visited[child] = false;
            if (!visited.ContainsKey(parent)) visited[parent] = false;

            // 해당 자식 노드의 부모 저장
            toParent[child].Add(parent);
            // 부모 노드의 자식 저장
            toChild[parent].Add(child);
        }

        // 형변환 가능 한가? = 자식 노드에서 부모 노드로 가거나, 부모 노드에서 자식 노드로 가는 방식으로 이동했을 때 도달 가능한가?
        bool canReach = false;
        // 형변환 테스트 할 두 클래스
        string[] fromTo = sr.ReadLine().Split(' ');
        // 우선 자식에서 부모 노드로만 이동할 때 도달할 수 있는지 검사
        canReach |= CanReach(fromTo[0], fromTo[1], toParent);
        // 사용했으므로 초기화
        foreach (string key in visited.Keys)
        {
            visited[key] = false;
        }
        // 부모 노드에서 자식 노드로만 이동할 때 도달할 수 있는지 검사ㅣ
        canReach |= CanReach(fromTo[0], fromTo[1], toChild);
        Console.WriteLine(canReach ? 1 : 0);
    }

    // current에서 target으로 갈 수 있는지 판단해서 갈 수 있으면 true 반환
    public static bool CanReach(string current, string target, Dictionary<string, List<string>> adj)
    {
        // 방문 표시
        visited[current] = true;
        // base : 목표 정점을 찾음
        if (current == target) return true;
        bool canReach = false;
        foreach (string other in adj[current])
        {
            // 방문하지 않은 정점에 대해 DFS로 탐색
            // 1개라도 도달가능한 경로가 있다면 true, 아니면 false
            if (!visited[other])
            {
                canReach |= CanReach(other, target, adj);
            }
        }
        // 함수 종료
        return canReach;
    }
}
