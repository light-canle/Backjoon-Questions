using System;
using System.Linq;
using System.Collections.Generic;

/// <summary>
/// p10867 - 중복 빼고 정렬하기, S5
/// 해결 날짜 : 2023/9/18
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        int[] list = Console.ReadLine().Split().Select(int.Parse).ToArray();

        var ans = list.Distinct().ToList();
        ans.Sort();
        Console.WriteLine(string.Join(" ", ans));
    }
}