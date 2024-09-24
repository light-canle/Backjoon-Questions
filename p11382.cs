using System;
using System.Linq;

/// <summary>
/// p11382 - 꼬마 정민, B5
/// 해결 날짜 : 2023/8/24
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        long[] list = Console.ReadLine().Split().Select(x => long.Parse(x)).ToArray();

        Console.WriteLine(list[0] + list[1] + list[2]);
    }
}