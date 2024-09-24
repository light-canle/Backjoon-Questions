using System;
using System.Linq;
using System.Collections.Generic;

// p2753 - 윤년, B5
// 해결 날짜 : 2023/8/20

public class Program
{
    public static void Main(string[] args)
    {
        int year = int.Parse(Console.ReadLine());

        int answer = ((year % 4 == 0 && year % 100 != 0) || year % 400 == 0) ? 1 : 0;

        Console.WriteLine(answer);
    }
}