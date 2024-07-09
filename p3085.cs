using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());

        List<List<char>> map = new List<List<char>>();

        for (int j = 0; j < N; j++)
        {
            map.Add(Console.ReadLine().ToCharArray().ToList());
        }

        int maxLen = 1;
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N - 1; j++)
            {
                if (map[i][j] != map[i][j + 1])
                {
                    swap(map, i, j, i, j + 1);
                    maxLen = Math.Max(maxLen, MaxLen(map, N));
                    swap(map, i, j, i, j + 1);
                }
            }
        }

        for (int i = 0; i < N - 1; i++)
        {
            for (int j = 0; j < N; j++)
            {
                if (map[i][j] != map[i + 1][j])
                {
                    swap(map, i, j, i + 1, j);
                    maxLen = Math.Max(maxLen, MaxLen(map, N));
                    swap(map, i, j, i + 1, j);
                }
            }
        }

        Console.WriteLine(maxLen);
    }

    public static int MaxLen(List<List<char>> map, int N)
    {
        int max = 0;
        char curChar = ' ';
        int curLen = 0;
        
        for (int i = 0; i < N; i++)
        {
            
            for (int j = 0; j < N; j++)
            {
                if (map[i][j] == curChar)
                {
                    curLen++;
                }
                else
                {
                    max = Math.Max(max, curLen);
                    curLen = 1;
                    curChar = map[i][j];
                }
            }
            max = Math.Max(max, curLen);
            curChar = ' ';
            curLen = 0;
        }

        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                if (map[j][i] == curChar)
                {
                    curLen++;
                }
                else
                {
                    max = Math.Max(max, curLen);
                    curLen = 1;
                    curChar = map[j][i];
                }
            }
            max = Math.Max(max, curLen);
            curChar = ' ';
            curLen = 0;
        }

        return max;
    }

    public static void swap(List<List<char>> map, int y1, int x1, int y2, int x2)
    {
        char temp = map[y1][x1];
        map[y1][x1] = map[y2][x2];
        map[y2][x2] = temp;
    }
}
