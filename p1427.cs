using System;
using System.Linq;
using System.Collections.Generic;

/// <summary>
/// p1427 - 소트인사이드, S5
/// 해결 날짜 : 2023/9/1
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        string number = Console.ReadLine();

        List<char> list = new List<char>();
        for (int i = 0; i < number.Length; i++)
        {
            list.Add(number[i]);
        }

        list.Sort();
        list.Reverse();

        foreach (char c in list) 
        {
            Console.Write(c);
        }
        Console.WriteLine();
    }
}
