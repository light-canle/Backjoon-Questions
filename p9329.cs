using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine());

        for (int i = 0; i < t; i++)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int kind = input[0];
            int sticker = input[1];

            List<List<int>> info = new List<List<int>>();
            for (int j = 0; j < kind; j++)
            {
                info.Add(Console.ReadLine().Split().Select(int.Parse).ToList());
            }
            
            List<int> stickers = Console.ReadLine().Split().Select(int.Parse).ToList();
            int sum = 0;
            
            for (int j = 0; j < kind; j++)
            {
                int c = info[j][0];
                int minCount = 99999;
                for (int k = 1; k <= c; k++)
                {
                    minCount = Math.Min(minCount, stickers[info[j][k] - 1]);
                }
                sum += minCount * info[j][^1];
            }
            Console.WriteLine(sum);
        }
    }
}
