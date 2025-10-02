using System;
using System.IO;

// p28357 - 사탕 나눠주기 (S2)
// #이분 탐색
// 2025.10.2 solved

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        long[] input = Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
        long n = input[0], k = input[1];

        long[] scores = Array.ConvertAll(Console.ReadLine().Split(), long.Parse);

        // 기준 하한과 상한
        long low = 0, high = 1_000_000_000_000L;
        long ret = -1;
        // 후보 값이 2개 이하가 될 때까지 반복한다.
        while (high - low >= 2)
        {
            long mid = (low + high) / 2;
            long need = CandyNeed(scores, mid);
            // 필요한 양이 가지고 있는 양보다 많다.
            if (need > k)
            {
                low = mid;
            }
            // 그 외에는 최소 점수를 찾기 위해 high를 줄인다.
            else
            {
                high = mid;
            }
        }
        // 후보값이 2개 이하로 좁혀짐
        // 둘 중 작은 점수로도 개수를 충족할 수 있으면 low, 아니면 high
        if (CandyNeed(scores, low) <= k)
        {
            ret = low;
        }
        else
        {
            ret = high;
        }

        Console.WriteLine(ret);
        sr.Close();
    }

    // 기준 점수가 x점일 때, 필요한 사탕의 총 개수를 구한다.
    public static long CandyNeed(long[] scores, long x)
    {
        long need = 0;
        foreach (long s in scores)
        {
            need += s > x ? s - x : 0;
        }
        return need;
    }
}
