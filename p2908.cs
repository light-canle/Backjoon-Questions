using System;
using System.Linq;

/// <summary>
/// p2908 - 상수, B2
/// 해결 날짜 : 2023/9/14
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split().ToArray();

        int n1 = int.Parse(string.Join("", input[0].Reverse()));
        int n2 = int.Parse(string.Join("", input[1].Reverse()));

        Console.WriteLine((n1 > n2) ? n1: n2);
    }
}