using System;
using System.Linq;
using System.Collections.Generic;

/// <summary>
/// p1158 - 요세푸스 문제, S4
/// 해결 날짜 : 2023/12/2
/// 300번째 문제
/// </summary>

public class Program
{
    public static List<long> list;
    public static void Main(string[] args)
    {
        int[] ints = Console.ReadLine()!.Split().Select(int.Parse).ToArray();
        (int N, int K) = (ints[0], ints[1]);

        int curIndex = K - 1;
        List<int> list = Enumerable.Range(1, N).ToList();
        List<int> ret = new List<int>();

        while (N > 0)
        {
            int cur = list[curIndex];
            ret.Add(cur);
            list.Remove(cur);
            N--;
            if (N == 0) break;
            curIndex = (curIndex + K - 1) % N;
        }

        Console.WriteLine($"<{string.Join(", ", ret)}>");
    }
}