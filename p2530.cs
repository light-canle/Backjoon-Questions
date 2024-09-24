using System;
using System.Linq;

/// <summary>
/// p2530 - 인공지능 시계, B4
/// 해결 날짜 : 2023/9/13
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
        (int h, int m, int s) = (input[0], input[1], input[2]);
        int time = int.Parse(Console.ReadLine());

        s += time;
        if (s >= 60) m += s / 60; s %= 60;
        if (m >= 60) h += m / 60; m %= 60;
        if (h >= 24) h %= 24;
        Console.WriteLine($"{h} {m} {s}");
    }
}