using System;
using System.Linq;
using System.Collections.Generic;

/// <summary>
/// p11399 - ATM, S4
/// 해결 날짜 : 2023/8/31
/// </summary>

/*
이 문제의 경우 가장 시간이 적게 걸리는 사람을 먼저 배치하면 모든 시간의 합이
최소가 된다.
*/

public class Program
{
    public static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        List<int> list = Console.ReadLine().Split().Select(x => int.Parse(x)).ToList();
        // 크기 순 정렬
        list.Sort();
        // 총 소요시간을 계산
        int sum = 0;
        for (int i = 0; i < list.Count; i++)
        {
            sum += list.GetRange(0, i + 1).Sum();
        }
        Console.WriteLine(sum);
    }
}
