#pragma warning disable CS8604, CS8602, CS8600

using System;

// p10819 - 차이를 최대로 (S2)
// #백트래킹 #완전 탐색
// 2025.10.27 solved (10.26)

public class Program
{
    public static int[] order;
    public static bool[] visited;
    public static int maxValue;
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        order = new int[n];
        visited = new bool[n];
        maxValue = int.MinValue;

        FindMax(input, 0, n);

        Console.WriteLine(maxValue);
    }

    // 길이 n의 모든 순열을 제작
    public static void FindMax(int[] list, int depth, int n)
    {
        if (depth == n)
        {
            UpdateMax(n);
        }

        for (int i = 0; i < n; i++)
        {
            if (!visited[i])
            {
                visited[i] = true;
                order[depth] = list[i];
                FindMax(list, depth + 1, n);
                visited[i] = false;
            }
        }
    }

    // |n[0] - n[1]| + |n[1] - n[2]| + ... + |n[l-2] - n[l-1]|의 최댓값을 갱신
    public static void UpdateMax(int n)
    {
        int sum = 0;
        for (int i = 0; i < n - 1; i++)
        {
            sum += Math.Abs(order[i] - order[i + 1]);
        }
        maxValue = Math.Max(maxValue, sum);
    }
}
