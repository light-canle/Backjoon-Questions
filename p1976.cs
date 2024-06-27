using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        int M = int.Parse(Console.ReadLine());

        List<List<int>> graph = new List<List<int>>();

        for (int i = 0; i < N; i++)
        {
            graph.Add(Console.ReadLine().Split(' ').Select(int.Parse).ToList());
        }

        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < M; j++)
            {
                if (i == j)
                    graph[i][j] = 1;
            }
        }

        for (int k = 0; k < N; k++)
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    graph[i][j] = graph[i][k] == 1 && graph[k][j] == 1 ? 1 : graph[i][j];
                }
            }
        }

        int[] route = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        int from = route[0];
        int to;
        bool valid = true;
        for (int i = 1; i < route.Length; i++)
        {
            to = route[i];
            int canApporach = graph[from - 1][to - 1];
            if (canApporach == 0)
            {
                valid = false;
                break;
            }
            from = to;
        }

        Console.WriteLine(valid ? "YES" : "NO");
    }
}
