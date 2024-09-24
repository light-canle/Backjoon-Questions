using System;
using System.Linq;

/// <summary>
/// p15964 - 이상한 기호, B5
/// 해결 날짜 : 2023/9/27
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        var input = Console.ReadLine().Split().Select(long.Parse).ToArray();
        (long a, long b) = (input[0], input[1]);

        long ret = (a + b) * (a - b);

        Console.WriteLine(ret);
    }
}