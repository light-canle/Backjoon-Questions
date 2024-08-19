using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));

        int[] size = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
        int singer = size[0], PD = size[1];

        Dictionary<int, List<int>> adj = new();
        int[] inDegree = new int[singer + 1];

        for (int i = 1; i <= singer; i++)
        {
            adj[i] = new();
        }

        for (int i = 0; i < PD; i++)
        {
            int[] order = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);

            for (int j = 1; j < order.Length - 1; j++)
            {
                adj[order[j]].Add(order[j + 1]);
                inDegree[order[j + 1]]++;
            }
        }

        Queue<int> q = new();

        for (int i = 1; i <= singer; i++)
        {
            if (inDegree[i] == 0)
            {
                q.Enqueue(i);
            }
        }
        List<int> result = new();

        while (q.Count > 0)
        {
            int cur = q.Dequeue();
            result.Add(cur);

            for (int k = 0; k < adj[cur].Count; k++)
            {
                inDegree[adj[cur][k]]--;
                if (inDegree[adj[cur][k]] == 0)
                    q.Enqueue(adj[cur][k]);
            }
            adj[cur].Clear();
        }
        for (int i = 1; i <= singer; i++)
        {
            if (inDegree[i] != 0)
            {
                Console.WriteLine("0");
                return;
            }
        }
        foreach(int i in result)
        {
            Console.WriteLine(i);
        }
    }
}
