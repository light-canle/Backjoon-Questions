using System;
using System.Linq;
using System.Collections.Generic;

/// <summary>
/// p14425 - 문자열 집합, S4
/// 해결 날짜 : 2024/3/27
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        int[] input = Console.ReadLine()!.Split().Select(int.Parse).ToArray();
        (int N, int M) = (input[0], input[1]);
        List<string> list = new List<string>();
        List<string> list2 = new List<string>();

        for (int i = 0; i < N; i++)
        {
            string s = Console.ReadLine()!;
            list.Add(s);
        }

        for (int i = 0; i < M; i++)
        {
            string s = Console.ReadLine()!;
            list2.Add(s);
        }

        int count = 0;
        foreach (string s in list2)
        {
            if (list.Contains(s)) count++;
        }

        Console.WriteLine(count);
    }
}