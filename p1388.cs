using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        int[] size = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        int n = size[0], m = size[1];

        List<string> floor = new();
        for (int y = 0; y < n; y++)
        {
            floor.Add(Console.ReadLine());
        }
        
        int count = 0;
        int len = 0;
        for (int y = 0; y < n; y++)
        {
            for (int x = 0; x < m; x++)
            {
                if (floor[y][x] == '-')
                {
                    len++;
                }
                else
                {
                    count += len > 0 ? 1 : 0;
                    len = 0;
                }
            }
            count += len > 0 ? 1 : 0;
            len = 0;
        }

        len = 0;
        for (int x = 0; x < m; x++)
        {
            for (int y = 0; y < n; y++)
            {
                if (floor[y][x] == '|')
                {
                    len++;
                }
                else
                {
                    count += len > 0 ? 1 : 0;
                    len = 0;
                }
            }
            count += len > 0 ? 1 : 0;
            len = 0;
        }

        Console.WriteLine(count);
    }
}
