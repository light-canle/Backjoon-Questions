#pragma warning disable CS8604, CS8602, CS8600

// p2890 - 카약 (S5)
// #문자열 #구
// 2026.1.12 solved

public class Program
{
    public static void Main(string[] args)
    {
        int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        int r = input[0], c = input[1];
        int[] dist = new int[9];
        // 각 카약의 결승점까지의 거리를 측정한다.
        for (int i = 0; i < r; i++)
        {
            string line = Console.ReadLine();
            for (int j = c - 1; j >= 1; j--)
            {
                if (char.IsDigit(line[j]))
                {
                    dist[line[j] - '1'] = c - 1 - j;
                    break;
                }
            }
        }
        // 거리가 가까운 순으로 순위를 결정한다.
        int[] rank = new int[9];
        int curRank = 1, curMin = int.MaxValue;
        while (true)
        {
            // 모든 카약의 순위가 결정됨
            if (!rank.Any(x => x == 0)) break;
            // 최솟값을 찾음
            for (int i = 0; i < 9; i++)
            {
                if (rank[i] == 0 && curMin > dist[i])
                {
                    curMin = dist[i];
                }
            }
            // 최솟값과 같은 모든 카약은 현재 순위를 부여 받음
            for (int i = 0; i < 9; i++)
            {
                if (curMin == dist[i])
                {
                    rank[i] = curRank;
                }
            }
            curRank++;
            curMin = int.MaxValue;
        }
        foreach (int i in rank)
        {
            Console.WriteLine(i);
        }
    }
}
