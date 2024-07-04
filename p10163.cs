using System;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());

        int[,] plane = new int[1001, 1001];
        for (int i = 1; i <= N; i++)
        {
            int[] line = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int x = line[0];
            int y = line[1];
            int w = line[2];
            int h = line[3];
            for (int j = x; j < x + w; j++)
            {
                for (int k = y; k < y + h; k++)
                {
                    plane[j, k] = i;
                }
            }
        }

        int[] area = new int[N];

        for (int i = 0; i < 1001; i++)
        {
            for (int j = 0; j < 1001; j++)
            {
                if (plane[i, j] != 0)
                {
                    area[plane[i, j] - 1]++;
                }
            }
        }

        foreach (int a in area)
        {
            Console.WriteLine(a);
        }
    }
}
