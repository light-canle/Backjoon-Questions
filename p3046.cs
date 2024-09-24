using System;
using System.Linq;

/// <summary>
/// p3046 - R2, B4
/// 해결 날짜 : 2023/10/5
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int R1 = input[0];
        int S = input[1];
        int R2 = 2 * S - R1;
        Console.WriteLine(R2);
    }
}