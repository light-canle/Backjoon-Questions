using System;
using System.Linq;
using System.Collections.Generic;

// p14241 - 슬라임 합치기 (S3)
// #정렬 #수학
// 2025.4.15 solved

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        List<long> list = Console.ReadLine().Split().Select(long.Parse).ToList();
        // 문제에서 구하는 최대 점수는 리스트를 정렬한 후
        // 맨 앞부터 두 수를 더한 뒤 그 합을 다음 수와 더하는 방식으로
        // 마지막 수까지 반복하면 얻을 수 있다.
        list.Sort();

        long score = 0;

        long cur = list[0];
        for (int i = 1; i < n; i++)
        {
            score += cur * list[i];
            cur += list[i];
        }
        Console.WriteLine(score);
    }
}
