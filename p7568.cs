using System;
using System.Linq;
using System.Collections.Generic;

/// <summary>
/// p7568 - 덩치, S5
/// 해결 날짜 : 2023/8/28
/// </summary>

public class Info
{
    public int weight;
    public int height;
    
    public Info(int w, int h) { weight = w; height = h; }
}

public class Program
{
    public static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());

        List<Info> list = new List<Info>();

        for (int i = 0; i < N; i++)
        {
            int[] input = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            list.Add(new Info(input[0], input[1]));
        }

        int[] rank_list = Enumerable.Repeat(1, N).ToArray();
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                if (list[j].weight > list[i].weight
                 && list[j].height > list[i].height)
                {
                    rank_list[i]++;
                }
            }
        }
        for(int i = 0; i < N; i++)
        {
            Console.Write(rank_list[i].ToString() + " ");
        }
    }
}
