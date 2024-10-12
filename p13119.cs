using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        int[] size = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
        int n = size[0];
        int m = size[1];
        int h = size[2];
        List<int> heights = sr.ReadLine().Split(' ').Select(int.Parse).ToList();

        char[,] map = new char[n, m];

        for (int i = 0; i < m; i++)
        {
            // draw Mountain
            for (int j = 0; j < heights[i]; j++)
            {
                map[n - 1 - j, i] = '#';
            }
            // draw road
            map[n - h, i] = heights[i] >= h ? '*' : '-';
            // draw pier
            if ((i + 1) % 3 == 0)
            {
                for (int j = heights[i] + 1; j < h; j++)
                {
                    map[n - j, i] = '|';
                }
            }
        }

        StringBuilder ret = new();
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                ret.Append(map[i, j] == '\0' ? '.' : map[i, j]);
            }
            ret.AppendLine();
        }

        Console.WriteLine(ret);
        sr.Close();
    }
}
