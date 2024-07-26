using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));

        int T = int.Parse(sr.ReadLine());
        Dictionary<int, List<int>> adj = new();
        List<int> time = new();
        int[] dp = new int[T + 1];
        int[] inDegree = new int[T + 1];
        for (int t = 1; t <= T; t++)
        {
            int[] i = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
            int k = i.Length - 1;
            int n = i[0];
            time.Add(n);
            
            for (int j = 1; j < k; j++)
            {
                if (!adj.ContainsKey(i[j]))
                    adj[i[j]] = new();
                adj[i[j]].Add(t);
                inDegree[t]++;
            }
        }

        Queue<int> q = new();
        for (int j = 1; j <= T; j++)
        {
            if (inDegree[j] == 0)
            {
                q.Enqueue(j);
                dp[j] = time[j - 1];
            }

        }

        while (q.Count > 0)
        {
            int node = q.Dequeue();
            if (adj.ContainsKey(node))
            {
                foreach (int n in adj[node])
                {
                    inDegree[n]--;
                    dp[n] = Math.Max(dp[n], dp[node] + time[n - 1]);
                    if (inDegree[n] == 0)
                        q.Enqueue(n);
                }
                adj[node].Clear();
            }  
        }
        for (int j = 1; j <= T; j++)
            Console.WriteLine(dp[j]);

    }       
}
