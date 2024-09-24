using System;
using System.Linq;

/// <summary>
/// p3003 - 킹, 퀸, 룩, 비숍, 나이트, 폰, B5
/// 해결 날짜 : 2024/3/26
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        int[] input = Console.ReadLine()!.Split().Select(int.Parse).ToArray();

        int[] output = { 1 - input[0], 1 - input[1], 2 - input[2]
        , 2 - input[3], 2 - input[4], 8 - input[5] };

        Console.WriteLine(string.Join(' ', output));
    }
}