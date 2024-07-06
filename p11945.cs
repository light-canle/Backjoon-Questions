using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int N = size[0];
        int M = size[1];

        List<List<char>> shape = new ();
        for (int i = 0; i < N; i++)
        {
            shape.Add(Console.ReadLine().ToCharArray().ToList());
        }
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < M / 2; j++)
            {
                char temp = shape[i][j];
                shape[i][j] = shape[i][M - j - 1];
                shape[i][M - j - 1] = temp;
            }
        }

        foreach (var row in shape)
        {
            Console.WriteLine(string.Join("", row));
        }
    }
}
