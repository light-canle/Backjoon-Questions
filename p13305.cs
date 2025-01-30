using System;

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        long[] road = Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
        long[] oil = Array.ConvertAll(Console.ReadLine().Split(), long.Parse);

        int pos = 0, nextTo = 1;
        long currentPrice = oil[pos];

        long minPrice = 0;
        while (nextTo < n)
        {
            // 가려고 하는 지점이 목적지 이거나(마지막 도시)
            // 현재 머물고 있는 도시보다 가격이 저렴한 경우 그 도시로 이동한다.
            // 이때 기름은 가려고 하는 도시까지 갈 수 있는 만큼 구입한다.
            // 즉, (현재 도시의 기름값) * (가려고 하는 도시까지의 거리)만큼 비용에 추가한다.
            if (nextTo == n - 1 || oil[nextTo] < currentPrice)
            {
                minPrice += currentPrice * Distance(road, pos, nextTo);
                currentPrice = oil[nextTo];
                pos = nextTo;
            }
            nextTo++;
        }
        Console.WriteLine(minPrice);
    }

    // from에서 to까지 가는데 거리를 계산한다. O(n)
    public static long Distance(long[] road, int from, int to)
    {
        if (from == to)
        {
            return 0;
        }

        long ret = 0;
        for (int i = from; i < to; i++)
        {
            ret += road[i];
        }

        return ret;
    }
}
