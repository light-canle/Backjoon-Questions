using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

/// <summary>
/// p2217 - 로프, S4
/// 해결 날짜 : 2023/9/4
/// </summary>

/*
그리디 알고리즘을 이용하는 문제
*/

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        int N = int.Parse(sr.ReadLine());

        List<int> rope = new List<int>();
        for (int i = 0; i < N; i++)
        {
            rope.Add(int.Parse(sr.ReadLine()));
        }

        int max_weight = 0;
        rope.Sort();
        // 우선 모든 로프를 다 고르고, 들 수 있는 중량을 로프 개수 * 원래 중량으로 한다.
        // 그런 뒤, 변화된 중량의 최솟값을 구한 것이 들 수 있는 최대 중량이다.
        int currentCount = rope.Count;
        while (currentCount > 0){
            int currentMax = 0;
            currentMax = rope[0] * currentCount;
            // 들 수 있는 중량이 가장 작은 로프를 하나씩 빼면서 들 수 있는 중량을 체크한다.
            max_weight = Math.Max(max_weight, currentMax);
            rope.RemoveAt(0);
            currentCount--;
        }

        // 가장 큰 값을 출력한다.
        Console.WriteLine(max_weight);
    }
}