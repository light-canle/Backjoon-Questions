#pragma warning disable CS8604, CS8602, CS8600

using System;
using System.Collections.Generic;
using System.Linq;

// p10427 - 빚 (G5)
// #누적 합 #정렬 #그리디
// 2025.12.22 solved

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            List<int> costs = Console.ReadLine().Split().Select(int.Parse).ToList();
            costs.RemoveAt(0);
            Console.WriteLine(FindSum(costs));
        }
    }

    public static long FindSum(List<int> list)
    {
        // 정렬
        list.Sort();
        int len = list.Count;

        // 부분 합 배열 생성
        long[] sum = new long[len + 1];
        long current = 0;
        for (int i = 0; i < len; i++)
        {
            current += list[i];
            sum[i + 1] = current;
        }

        // S(k) 구하기 - 연속된 k개의 원소 중 가장 큰 것 * k에
        // k개의 원소의 합을 뺴었을 때 최소를 구한다.
        long ret = 0;
        for (int size = 1; size <= len; size++)
        {
            long minValue = long.MaxValue;
            for (int i = 0; i + size <= len; i++)
            {
                minValue = Math.Min(minValue, size * list[i + size - 1] - (sum[i + size] - sum[i]));
            }
            ret += minValue;
        }
        return ret;
    }
}
