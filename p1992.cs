using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());

        List<List<int>> image = new List<List<int>>();

        for (int i = 0; i < N; i++)
        {
            image.Add(Console.ReadLine().ToCharArray().Select(x => Convert.ToInt32(x) - 48).ToList());
        }

        string compressed = QuadTree(image, 0, 0, N);
        Console.WriteLine(compressed);
    }

    public static string QuadTree(List<List<int>> image, int startY, int startX, int size)
    {
        if (size == 1)
            return image[startY][startX].ToString();
        int half = size / 2;
        int same = SamePart(image, startY, startX, size);
        if (same != -1)
        {
            return $"{same.ToString()}";
        }
        return $"({QuadTree(image, startY, startX, half)}{QuadTree(image, startY, startX + half, half)}{QuadTree(image, startY + half, startX, half)}{QuadTree(image, startY + half, startX + half, half)})";
    }

    
    public static int SamePart(List<List<int>> image, int y, int x, int size)
    {
        int start = image[y][x];
        for (int i = y; i < y + size; i++)
        {
            for (int j = x; j < x + size; j++)
            {
                if (image[i][j] != start)
                {
                    return -1;
                }
            }
        }
        return start;
    }
}
