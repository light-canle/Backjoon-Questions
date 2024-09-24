using System;
using System.Linq;
using System.Collections.Generic;

/// <summary>
/// p27866 - 문자와 문자열, B5
/// 해결 날짜 : 2023/8/19(solved.ac에서는 8/18)
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        string str = Console.ReadLine();
        int index = int.Parse(Console.ReadLine());

        Console.WriteLine(str[index - 1]);
    }
}
