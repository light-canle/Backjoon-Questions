using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    public static List<List<int>> adj;
    public static int[,] chain;
    public static void Main(string[] args)
    {
        int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int r = size[0], c = size[1];
        chain = new int[r, c];
        List<string> rows = new List<string>();
        adj = new List<List<int>>();

        for (int i = 0; i < r; i++)
        {
            string row = Console.ReadLine();
            rows.Add(row);
            for (int j = 0; j < c; j++)
            {
                adj.Add(new List<int>());
            }
        }

        for (int i = 0; i < r; i++)
        {
            for (int j = 0; j < c; j++)
            {
                int cur = i * c + j;
                if (i != 0) adj[cur].Add((i - 1) * c + j);
                if (i != r - 1) adj[cur].Add((i + 1) * c + j);
                if (j != 0) adj[cur].Add(i * c + j - 1);
                if (j != c - 1) adj[cur].Add(i * c + j + 1);
            }
        }

        DFS(0, c, rows, 1, "" + rows[0][0]);

        int max = 1;
        for (int i = 0; i < r; i++)
        {
            for (int j = 0; j < c; j++)
            {
                max = Math.Max(max, chain[i, j]);
            }
        }
        Console.WriteLine(max);
    }

    public static void DFS(int cur, int c, List<string> rows, int len, string visitedChar)
    {
        int y = cur / c, x = cur % c;
        char curChar = rows[y][x];
        chain[y, x] = Math.Max(len, chain[y, x]);
        for (int i = 0; i < adj[cur].Count; i++)
        {
            int next = adj[cur][i];
            if (!visitedChar.Contains(rows[next / c][next % c]))
            {
                DFS(next, c, rows, len + 1, visitedChar + rows[next / c][next % c]);
            }
        }
    }

    public static int Alphabet(char c) 
    {
        return (int)c - (int)'A';
    }
}
