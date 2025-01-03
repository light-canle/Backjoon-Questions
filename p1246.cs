using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        int[] size = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        int n = size[0], m = size[1];

        List<int> price = new();
        for (int i = 0; i < m; i++)
        {
            price.Add(int.Parse(Console.ReadLine()));
        }

        price.Sort();
        price.Reverse();

        int bestPrice = 1;
        int maxTotal = 0;

        int searchCount = Math.Min(n, m);
        for (int i = 0; i < searchCount; i++)
        {
            int total = price[i] * (i + 1);
            if (total >= maxTotal)
            {
                maxTotal = total;
                bestPrice = price[i];
            }
        }
        Console.WriteLine($"{bestPrice} {maxTotal}");
    }
}
