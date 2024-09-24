using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

/// <summary>
/// p2559 - 수열, S3
/// 해결 날짜 : 2023/9/4
/// 이 문제를 풀로 골드 5로 승급
/// </summary>

/*
부분합의 성질을 이용한 문제
*/

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        int[] input = sr.ReadLine().Split().Select(int.Parse).ToArray();

        int N = input[0];
        int K = input[1];
        List<int> list = sr.ReadLine().Split().Select(int.Parse).ToList();

        int maxSum = list.GetRange(0, K).Sum();
        int currentSum = maxSum;
        for (int i = 0; i < N - K; i++)
        {
            currentSum = currentSum + list[K + i] - list[i];
            maxSum = Math.Max(maxSum, currentSum);
        }

        Console.WriteLine(maxSum);
        sr.Close();
    }
}