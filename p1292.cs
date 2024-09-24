using System;
using System.Linq;
using System.Collections.Generic;

/// <summary>
/// p1292 - 쉽게 푸는 문제, B1
/// 해결 날짜 : 2023/9/16
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        List<int> list = new List<int>();

        int j = 1, current = 0;
        while (list.Count < 1000)
        {
            list.Add(j);
            current++;
            if (current >= j)
            {
                j++;
                current = 0;
            }
        }
        int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine(list.GetRange(input[0] - 1, input[1] - input[0] + 1).Sum());
    }
}