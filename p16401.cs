using System;
using System.IO;

// p16401 - 과자 나눠주기 (S2)
// #이분 탐색
// 2025.4.18 solved

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new (new BufferedStream(Console.OpenStandardInput()));
        int[] c = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

        int m = c[0], n = c[1];

        long[] l = Array.ConvertAll(sr.ReadLine().Split(), long.Parse);

        // 과자 길이의 전체 합이 사람 수보다 작으면
        // 정수 길이로 나눌 수 없다.
        long sum = l.Sum();
        if (m > sum)
        {
            Console.WriteLine(0);
            return;
        }

        // 최적의 길이를 이분 탐색을 통해 찾는다.
        long low = 1, high = 1_000_000_000;
        // 이렇게 하면 후보가 low, high 2개만 남는다.
        while (Math.Abs(high - low) > 1)
        {
            long mid = (low + high) / 2;
            long count = 0;
            for (int i = 0; i < n; i++)
            {
                count += l[i] / mid;
            }
            if (count >= m)
            {
                low = mid;
            }
            else
            {
                high = mid - 1;
            }
        }
        // high 기준으로 줄 수 있는 과자 조각의 수를 센다.
        long cl = 0;
        for (int i = 0; i < n; i++)
        {
            cl += l[i] / high;
        }
        // high일 때 가능하면 high가, 아니면 low가 정답
        if (cl >= m)
        {
            Console.WriteLine(high);
        }
        else
        {
            Console.WriteLine(low);
        }
    }
}
