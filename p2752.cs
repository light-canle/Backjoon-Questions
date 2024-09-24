using System;
using System.Linq;

/// <summary>
/// p2752 - 세수정렬, B4
/// 해결 날짜 : 2023/9/12
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        List<int> input = Console.ReadLine().Split().Select(int.Parse).ToList();
        input.Sort();
        Console.WriteLine(string.Join(" ", input));
    }
}