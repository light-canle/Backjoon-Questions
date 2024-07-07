using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        List<(int, int)> rects = new();
        for (int i = 1; i <= 149; i++)
        {
            for (int j = i + 1; j <= 150; j++)
            {
                rects.Add((i, j));
            }
        }
        rects = rects.OrderBy(x => x.Item1 * x.Item1 + x.Item2 * x.Item2).ThenBy(x => x.Item1).ToList();

        while (true)
        {
            int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int h = size[0], w = size[1];
            if (h == 0 && w == 0)
                break;
            int index = rects.IndexOf((h, w)) + 1;
            int nextW = rects[index].Item1;
            int nextH = rects[index].Item2;
            Console.WriteLine($"{nextW} {nextH}");
        }
    }
}
