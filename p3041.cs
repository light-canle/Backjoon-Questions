#pragma warning disable CS8604, CS8602, CS8600

using System;
using System.Linq;
using System.Collections.Generic;

// p3041 - N-퍼즐 (B1)
// #구현
// 2025.3.27 solved

public class Program
{
    public static void Main(string[] args)
    {
        List<List<char>> list = new List<List<char>>();
        for (int i = 0; i < 4; i++)
        {
            list.Add(Console.ReadLine().ToCharArray().ToList());
        }
        (int, int)[] pos = new (int, int)[15];
        
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (list[i][j] != '.')
                {
                    pos[list[i][j] - 'A'] = (i, j);
                }
            }
        }

        int totalDist = 0;
        for (int i = 0; i < 15; i++) 
        {
            totalDist += Dist(pos[i], (i / 4, i % 4));
        }
        Console.WriteLine(totalDist);
    }

    public static int Dist((int, int) a, (int, int) b)
    {
        return Math.Abs(a.Item1 - b.Item1) + Math.Abs(a.Item2 - b.Item2);
    }
}
