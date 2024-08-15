using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));

        int P = int.Parse(sr.ReadLine());

        int INF = 987987;

        int[,] dist = new int[52, 52];

        for (int i = 0; i < 52; i++)
        {
            for (int j = 0; j < 52; j++)
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
            int a = Convert(line[0][0]);
            int b = Convert(line[2][0]);
            
            dist[a, b] = 0;
        }

        for (int k = 0; k < 52; k++)
        {
            for (int i = 0; i < 52; i++)
            {
                for (int j = 0; j < 52; j++)
                {
                    dist[i, j] = Math.Min(dist[i, j], dist[i, k] + dist[k, j]);
                }
            }
        }

        List<(char, char)> ans = new();
        for (int i = 0; i < 52; i++)
        {
            for (int j = 0; j < 52; j++)
            {
                if (dist[i, j] == 0 && i != j)
                {
                    ans.Add((Inverse(i), Inverse(j)));
                }
            }
        }
        Console.WriteLine(ans.Count);
        foreach (var item in ans)
        {
            Console.WriteLine(item.Item1 + " => " + item.Item2);
        }
        sr.Close();
    }

    // 대문자이면 0-25, 소문자이면 26-51을 반환한다.
    public static int Convert(char c)
    {
        if (c >= 'A' && c <= 'Z')
        {
            return c - 'A';
        }
        else
        {
            return c - 'a' + 26;
        }
    }

    // 0-25면 A-Z, 26-51이면 a-z를 반환한다.
    public static char Inverse(int i)
    {
        if (0 <= i && i <= 25)
        {
            return (char)(i + 'A');
        }
        else
        {
            return (char)(i - 26 + 'a');
        }
    }
}
