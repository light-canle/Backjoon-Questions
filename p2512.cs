using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

// p2512 - 예산 (S2)
// #이분 탐색
// 2025.7.13 solved

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        int n = int.Parse(sr.ReadLine().Trim());
        List<long> budget = sr.ReadLine().Trim().Split().Select(long.Parse).ToList();
        long total = long.Parse(sr.ReadLine().Trim());

        // 1부터 예산 요구량 최댓값까지를 범위로 잡음
        long low = 1, high = budget.Max();
        long sum = 0;
        // 가능한 예산의 최대치를 이분 탐색으로 찾음
        while (high - low > 1)
        {
            // 한 지방에 줄 수 있는 예산 최대치
            long limit = (low + high) / 2;
            // 정한 최대치 이하로 예산의 합을 계산
            sum = budget.Select(x => 
                x > limit ? limit : x).Sum();
            // 예산의 총합 초과
            if (sum > total)
            {
                high = limit - 1;
            }
            // 정확히 일치하면 그것이 정답이 됨
            else if (sum == total)
            {
                Console.WriteLine(limit);
                return;
            }
            else
            {
                low = limit; // limit + 1로 하니 결과가 이상해서 limit으로 했음
            }
        }
        // low와 high는 같거나 1 차이남
        // 둘 다 조건을 만족하면 high, high가 예산 초과시 low가 정답
        sum = budget.Select(x => 
                x > high ? high : x).Sum();
        if (sum > total)
        {
            Console.WriteLine(low);
        }
        else
        {
            Console.WriteLine(high);
        }
    }
}
