using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int N = input[0], M = input[1];

        List<int> list = new List<int>();

        for (int i = 0; i < N; i++)
        {
            list.Add(int.Parse(Console.ReadLine()));
        }

        list.Sort();

        if (N == 1)
        {
            Console.WriteLine(0);
            return;
        }

        int s = 0, e = 0;
        int minDiff = int.MaxValue;
        while (true)
        {
            int diff = list[e] - list[s];
            if (diff >= M) 
            {
                s++;
                if (diff < minDiff)
                {
                    minDiff = diff;
                }
            }
            else if (diff < M) e++;
            if (s > e) e = s;
            if (e >= list.Count) break;
            
        }
        Console.WriteLine(minDiff);
    }
}
