using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

public class Program
{
    public static bool[] discovered;
    public static Dictionary<int, List<int>> graph;
    public static void Main(string[] args)
    {
        int T = int.Parse(Console.ReadLine());

        graph = new Dictionary<int, List<int>>();

        for (int i = 0; i < 10000; i++)
        {
            graph[i] = new();
            graph[i].Add((i * 2) % 10000);
            graph[i].Add(i == 0 ? 9999 : i - 1);
            graph[i].Add(Left(i));
            graph[i].Add(Right(i));
        }

        for (int i = 0; i < T; i++)
        {
            int[] line = Console.ReadLine().Split().Select(int.Parse).ToArray();
            discovered = new bool[10000];
            List<string> ret = BFS(line[0], line[1]);
            Console.WriteLine(ret[line[1]]);
        }
        
    }

    public static int Left(int n)
    {
        string s = $"{n:D04}";
        char[] c = new char[4];
        c[0] = s[1];
        c[1] = s[2];
        c[2] = s[3];
        c[3] = s[0];
        return int.Parse(new string(c));
    }

    public static int Right(int n)
    {
        string s = $"{n:D04}";
        char[] c = new char[4];
        c[0] = s[3];
        c[1] = s[0];
        c[2] = s[1];
        c[3] = s[2];
        return int.Parse(new string(c));
    }

    public static List<string> BFS(int start, int end)
    {
        Queue<int> queue = new Queue<int>();
        List<string> command = Enumerable.Repeat("", 10000).ToList();
        

        discovered[start] = true;
        queue.Enqueue(start);

        while (queue.Count > 0) 
        {
            int here = queue.First();
            queue.Dequeue();
            if (here == end) break;
            
            for (int i = 0; i < graph[here].Count; i++)
            {
                int there = graph[here][i];
                if (!discovered[there])
                {
                    queue.Enqueue(there);
                    discovered[there] = true;
                    command[there] = command[here]+Command(i);
                }
            }
        }
        return command;
    }

    public static string Command(int i)
    {
        switch (i)
        {
            case 0:
                return "D";
            case 1:
                return "S";
            case 2:
                return "L";
            case 3:
                return "R";
            default:
                return "";
        }
    }
}
