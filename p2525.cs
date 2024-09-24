using System;

/// <summary>
/// p2525 - 오븐 시계, B3
/// 해결 날짜 : 2023/11/5
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split();
        int addMin = int.Parse(Console.ReadLine());

        var h = int.Parse(input[0]);
        var m = int.Parse(input[1]);

        var toMin = h * 60 + m;
        toMin = ( toMin + addMin ) % 1440;

        h = toMin / 60;
        m = toMin % 60;

        Console.WriteLine($"{h} {m}");
    }
}