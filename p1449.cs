using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int N = size[0];
        int L = size[1];

        List<int> point = Console.ReadLine().Split().Select(int.Parse).ToList();

        point.Sort();

        int count = 1;
        int left = point[0];
        for (int i = 0; i < N; i++)
        {
            if (point[i] - left > L - 1)
            {
                count++;
                left = point[i];
            }
        }

        Console.WriteLine(count);
    }
}
