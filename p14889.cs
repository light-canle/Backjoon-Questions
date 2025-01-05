using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    public static List<List<int>> point;
    public static int minDiff;
    public static void Main(string[] args)
    {
        // input
        int n = int.Parse(Console.ReadLine());
        point = new();
        minDiff = int.MaxValue;
        for (int i = 0; i < n; i++)
        {
            point.Add(Console.ReadLine().Split().Select(int.Parse).ToList());
        }

        // backtracking
        bool[] visited = new bool[n];
        Backtracking(visited, new int[n / 2], 0, n, n / 2, 0);

        Console.WriteLine(minDiff);
    }

    // n개 중 k개를 골라주는 백트래킹 재귀함수
    public static void Backtracking(bool[] visited, int[] outList, int count, int n, int k, int start)
    {
        if (count == k)
        {
            minDiff = Math.Min(CalculateDiff(n, outList), minDiff);
            return;
        }

        for (int i = start; i < n; i++)
        {
            if (!visited[i])
            {
                visited[i] = true;
                outList[count] = i;
                Backtracking(visited, outList, count + 1, n, k, i + 1);
                visited[i] = false;
            }
        }
    }

    public static int CalculateDiff(int n, int[] startTeam)
    {
        int start = 0;
        int link = 0;

        int len = startTeam.Length;

        for (int i = 0; i < len - 1; i++)
        {
            for (int j = i + 1; j < len; j++)
            {
                int first = startTeam[i], second = startTeam[j];
                start += point[first][second] + point[second][first];
            }
        }

        int[] linkTeam = Difference(Enumerable.Range(0, n).ToArray(), startTeam);
        for (int i = 0; i < len - 1; i++)
        {
            for (int j = i + 1; j < len; j++)
            {
                int first = linkTeam[i], second = linkTeam[j];
                link += point[first][second] + point[second][first];
            }
        }

        return Math.Abs(start - link);
    }

    // 차집합 A - B를 구한다. 
    public static int[] Difference(int[] A, int[] B)
    {
        int aLen = A.Length, bLen = B.Length;
        int[] result = new int[aLen - bLen];

        int index = 0;
        for (int i = 0; i < aLen; i++)
        {
            if (Array.IndexOf(B, A[i]) == -1)
            {
                result[index++] = A[i];
            }
        }

        return result;
    }
}
