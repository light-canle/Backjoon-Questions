using System;
using System.IO;
using System.Collections.Generic;

// 200th silver problem

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new (new BufferedStream(Console.OpenStandardInput()));
        int N = int.Parse(sr.ReadLine());

        List<int> list = new List<int>();
        for (int i = 0; i < N; i++)
        {
            list.Add(int.Parse(sr.ReadLine()));
        }

        list.Sort();

        int curIdx = list.Count - 3;

        int max = -1;
        while (curIdx >= 0)
        {
            if (CamMakeTriangle(list[curIdx + 0], list[curIdx + 1], list[curIdx + 2]))
            {
                int cur = list[curIdx + 0] + list[curIdx + 1] + list[curIdx + 2];
                if (cur > max)
                {
                    max = cur;
                    break;
                }
            }
            curIdx--;
        }
        
        Console.WriteLine(max);
        sr.Close();
    }

    public static bool CamMakeTriangle(int a, int b, int c)

    {
        int max = Math.Max(a, Math.Max(b, c));
        return max < a + b + c - max;
    }
}
