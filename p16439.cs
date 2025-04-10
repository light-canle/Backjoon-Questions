using System;
using System.Linq;
using System.Collections.Generic;

// p16439 - 치킨치킨치킨 (S4)
// #완전 탐색
// 2025.4.10 solved

public class Program
{
    public static void Main(string[] args)
    {
        int[] size = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        int n = size[0], m = size[1];

        List<List<int>> prefer = new();
        for (int i = 0; i < n; i++)
        {
            prefer.Add(Console.ReadLine().Split().Select(int.Parse).ToList());
        }

        int maxSum = 0;
        // i, j, k번째 치킨을 골랐을 때 각 사람마다 최고 선호도를 고르고
        // 그 선호도의 합을 구한 뒤 그 합의 최댓값을 갱신한다.
        for (int i = 0; i < m - 2; i++)
        {
            for (int j = i + 1; j < m - 1; j++)
            {
                for (int k = j + 1; k < m; k++)
                {
                    int sumPrefer = 0;
                    for (int p = 0; p < n; p++)
                    {
                        int maxPrefer = Math.Max(prefer[p][i], Math.Max(prefer[p][j], prefer[p][k]));
                        sumPrefer += maxPrefer;
                    }
                    maxSum = Math.Max(maxSum, sumPrefer);
                }
            }
        }
        Console.WriteLine(maxSum);
    }
}
