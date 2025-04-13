using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

// p14566 - Dongjak N1 (B1)
// #정렬 #완전 탐색
// 2025.4.13 solved

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();
        list.Sort();

        // find minimum distance
        int minDist = int.MaxValue;
        for (int i = 0; i < n - 1; i++)
        {
            minDist = Math.Min(minDist, list[i + 1] - list[i]);
        }

        // count #'s of pair that difference of two number is equal to "minDist"
        // 수들이 정렬되어 있으므로, 차이가 minDist와 같은지 확인하려면 인접한 두 수만 비교하면 된다.
        // 두 수 사이의 차이 중에 minDist가 있을 것이므로 차이가 더 나는 다른 수끼리(두 칸 이상 차이나는 수) 추가로 비교할 필요는 없다.
        int count = 0;
        for (int i = 0; i < n - 1; i++)
        {
            count += (minDist == list[i + 1] - list[i]) ? 1 : 0;
        }
        Console.WriteLine($"{minDist} {count}");
    }
}
