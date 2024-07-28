using System;
using System.IO;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new (new BufferedStream(Console.OpenStandardInput()));

        int N = int.Parse(sr.ReadLine());

        List<List<string>> paint = new();
        
        for (int i = 0; i < N; i++)
        {
            List<string> p = new();
            for (int j = 0; j < 5; j++)
            {
                p.Add(sr.ReadLine());
            }
            paint.Add(p);
        }

        int minDiff = 36;
        int a = 0, b = 0;
        for (int i = 0; i < N - 1; i++)
        {
            for (int j = i + 1; j < N; j++)
            {
                if (Diff(paint[i], paint[j]) < minDiff)
                {
                    minDiff = Diff(paint[i], paint[j]);
                    a = i + 1;
                    b = j + 1;
                }
            }
        }
        Console.WriteLine($"{a} {b}");
        sr.Close(); 
    }

    public static int Diff(List<string> a, List<string> b)
    {
        int diff = 0;
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                if (a[i][j] != b[i][j])
                {
                    diff++;
                }
            }
        }
        return diff;
    }
}
