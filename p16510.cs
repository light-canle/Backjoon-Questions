using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

// p16510 - Predictable Queue (S1)
// #이분 탐색 #누적 합
// 2025.7.14 solved

/*
누적 합을 이용해 처음부터 순서대로 k개의 일을 하는데
걸리는 시간을 미리 구해 놓는다.
이후 시간 t만큼이 주어졌을 때 처음부터 몇 개의 일을 할 수 있는지를
이분 탐색으로 알아낸다. (m이 최대 20만)
*/
public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput()));
        int[] size = Array.ConvertAll(sr.ReadLine().Trim().Split(), int.Parse);
        int n = size[0], m = size[1];
        List<long> time = sr.ReadLine().Trim().Split().Select(long.Parse).ToList();

        // 누적 합으로 처음부터 k(0~n)개의 일을 하는데 걸리는 누적 합을 구함
        List<long> prefix = new();
        prefix.Add(0);

        long s = 0;
        for (int i = 0; i < n; i++)
        {
            s += time[i];
            prefix.Add(s);
        }

        // 이분 탐색으로 시간 t로 할 수 있는 최대 일의 개수를 구한다.
        for (int i = 0; i < m; i++)
        {
            long t = long.Parse(sr.ReadLine().Trim());
            sw.WriteLine(Find(prefix, t));
        }
        sw.Flush();
        sr.Close();
        sw.Close();
    }

    // list(정렬됨) 에서 t이하인 최댓값의 인덱스를 구한다.
    public static int Find(List<long> list, long t)
    {
        int low = 0, high = list.Count - 1;

        while (high - low > 1)
        {
            int mid = (low + high) / 2;
            if (list[mid] > t)
            {
                high = mid - 1; // mid는 답이 될 수 없음
            }
            else if (list[mid] == t)
            {
                return mid; // mid가 정답
            }
            else
            {
                low = mid; // mid가 답이 될 가능성이 있음
            }
        }
        if (list[high] > t)
        {
            return low;
        }
        return high;
    }
}
