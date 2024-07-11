using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());

        List<List<int>> grid = new List<List<int>>();

        for (int i = 0; i < N; i++)
        {
            grid.Add(Console.ReadLine().Split(' ').Select(int.Parse).ToList());
        }

        (int a, int b, int c) = Count(grid, 0, 0, N);

        Console.WriteLine(a);
        Console.WriteLine(b);
        Console.WriteLine(c);
    }

    public static (int, int, int) Count(List<List<int>> grid, int i, int j, int size)
    {
        if (IsSame(grid, i, j, size))
        {
            return grid[i][j] == -1 ? (1, 0, 0) : (grid[i][j] == 0 ? (0, 1, 0) : (0, 0, 1));
        }
        else
        {
            int third = size / 3;
            int a = 0, b = 0, c = 0;
            for (int k = 0; k < 3; k++)
            {
                for (int l = 0; l < 3; l++)
                {
                    (int x, int y, int z) = Count(grid, i + k * third, j + l * third, third);
                    a += x;
                    b += y;
                    c += z;
                }
            }

            return (a, b, c);
        }
    }

    public static bool IsSame(List<List<int>> grid, int i, int j, int size)
    {
        int value = grid[i][j];
        for (int x = i; x < i + size; x++)
        {
            for (int y = j; y < j + size; y++)
            {
                if (grid[x][y] != value)
                {
                    return false;
                }
            }
        }
        return true;
    }
}
