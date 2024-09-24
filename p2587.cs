using System;
using System.Linq;
using System.Collections.Generic;

/// <summary>
/// p2587 - 대표값2, B2
/// 해결 날짜 : 2024/3/27
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        List<int> list = new List<int>();

        for (int i = 0; i < 5; i++)
        {
            list.Add(int.Parse(Console.ReadLine()!));
        }
        
        list.Sort();

        Console.WriteLine(list.Sum(x => x) / 5);
        Console.WriteLine(list[2]);
    }
}