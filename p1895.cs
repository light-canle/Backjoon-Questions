using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new (new BufferedStream(Console.OpenStandardInput()));

        int[] size = Array.ConvertAll(sr.ReadLine().Trim().Split(), int.Parse);
        int r = size[0], c = size[1];
        List<List<int>> grid = new();
        for (int i = 0; i < r; i++)
        {
            grid.Add(sr.ReadLine().Trim().Split().Select(int.Parse).ToList());
        }

        List<List<int>> filtered = new();
        for (int i = 0; i < r - 2; i++)
        {
            filtered.Add(new());
            for (int j = 0; j < c - 2; j++)
            {
                filtered[i].Add(Median(grid, i, j));
            }
        }

        int T = int.Parse(sr.ReadLine().Trim());
        int count = 0;
        foreach (var item in filtered)
        {
            foreach(int k in item)
            {
                if (k >= T)
                {
                    count++;
                }
            }
        }
        Console.WriteLine(count);
        sr.Close();
    }

    public static int Median(List<List<int>> grid, int y, int x)
    {
        List<int> list = new();
        for (int i = y; i < y + 3; i++)
        {
            for (int j = x; j < x + 3; j++)
            {
                list.Add(grid[i][j]);
            }
        }
        list.Sort();
        return list[4];
    }
}
