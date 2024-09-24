using System;
using System.Linq;
using System.Collections.Generic;

/// <summary>
/// p1551 - 수열의 변화, B1
/// 해결 날짜 : 2023/11/19
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        int[] i = Console.ReadLine()!.Split().Select(int.Parse).ToArray();

        (int N, int K) = (i[0], i[1]);

        List<int> list = Console.ReadLine()!.Split(',').Select(int.Parse).ToList();

        for (int j = 0; j < K; j++)
        {
            var newList = new List<int>();
            for (int l = 0; l < list.Count - 1; l++) 
            {
                newList.Add(list[l + 1] - list[l]);
            }
            list = newList;
        }

        Console.WriteLine(string.Join(",", list));
    }
}