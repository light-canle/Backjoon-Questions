using System;

/// <summary>
/// p2163 - 초콜릿 자르기, B1
/// 해결 날짜 : 2023/12/4
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        int[] ints = Console.ReadLine()!.Split().Select(int.Parse).ToArray();

        // 최소 횟수로 N*M을 자르기 위해 우선 가로로 N - 1번을 자른 다음
        // N개의 조각을 M - 1번 자르게 된다.
        // 최소 횟수는 N - 1 + N * (M - 1) = N - 1 + N*M - N = N*M - 1이 된다.
        Console.Write(ints[0] * ints[1] - 1);
    }
}