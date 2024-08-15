using System;
using System.Linq;
using System.IO;

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));

        int P = int.Parse(sr.ReadLine());

        int INF = 987987;

        int[,] dist = new int[26, 26];

        for (int i = 0; i < 26; i++)
        {
            for (int j = 0; j < 26; j++)
            {
                dist[i, j] = INF;
                if (i == j)
                {
                    dist[i, j] = 0;
                }
            }
        }

        for (int i = 0; i < P; i++)
        {
            string[] line = sr.ReadLine().Split();
            int a = line[0][0] - 'a';
            int b = line[2][0] - 'a';
            dist[a, b] = 0;
        }

        for (int k = 0; k < 26; k++)
        {
            for (int i = 0; i < 26; i++)
            {
                for (int j = 0; j < 26; j++)
                {
                    dist[i, j] = Math.Min(dist[i, j], dist[i, k] + dist[k, j]);
                }
            }
        }

        int Q = int.Parse(sr.ReadLine());

        for (int i = 0; i < Q; i++)
        {
            string[] line = sr.ReadLine().Split();
            int a = line[0][0] - 'a';
            int b = line[2][0] - 'a';
            Console.WriteLine(dist[a, b] == 0 ? "T" : "F");
        }
        sr.Close();
    }
}
