#pragma warning disable CS8604, CS8602, CS8600

// p34846 - 이웃 마을 (S1)
// #그래프
// 2026.1.20 solved

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput()));
        int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        int n = input[0], m = input[1], q = input[2];

        // 특정 도시와 연결된 도시들의 리스트
        Dictionary<int, List<int>> adj = new();
        // 딕셔너리 초기화 (키 없음 오류 방지)
        for (int i = 1; i <= n; i++)
        {
            adj[i] = new();
        }
        // 두 도시를 연결한다.
        for (int i = 0; i < m; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int a = line[0], b = line[1];
            adj[a].Add(b);
            adj[b].Add(a);
        }

        // 해당 도시에 기차역이 있는가?
        bool[] builtTrainSt = new bool[n + 1];
        // 해당 도시의 이웃 도시 중 기차역을 가진 도시는 몇 개인가?
        int[] nearBuiltTrainSt = new int[n + 1];
        for (int i = 0; i < q; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int type = line[0], value = line[1];
            // 해당 도시에 기차역을 짓는다.
            if (type == 1)
            {
                // 지어지지 않은 경우에만 변경
                if (!builtTrainSt[value])
                {
                    builtTrainSt[value] = true;
                    // 인접한 도시의 nearBuiltTrainSt에 1씩 더함
                    foreach (var near in adj[value])
                    {
                        nearBuiltTrainSt[near]++;
                    }
                }
            }
            // 현재 기차역을 가진 이웃 도시 수 출력
            else
            {
                sw.WriteLine(nearBuiltTrainSt[value]);
            }
        }
        sw.Flush();
    }
}
