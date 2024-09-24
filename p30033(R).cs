using System;
using System.Linq;
using System.Collections.Generic;

/// <summary>
/// 유틸컵 Chapter2 - R번(1), Rust Study
/// p30033 - B4
/// 해결 날짜 : 2023/9/16
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        List<int> plan = Console.ReadLine().Split().Select(int.Parse).ToList();
        List<int> real = Console.ReadLine().Split().Select(int.Parse).ToList();

        int count = 0;
        for (int i = 0; i < N; i++)
        {
            if (real[i] >= plan[i]) { count++; }
        }

        Console.WriteLine(count);
    }
}