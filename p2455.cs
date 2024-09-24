using System;
using System.Linq;

/// <summary>
/// p2455 - 지능형 기차, B3
/// 해결 날짜 : 2023/11/14
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        int currentPassenger = 0;
        int maxPassenger = 0;
        for (int i = 0; i < 4; i++)
        {
            int[] input = Console.ReadLine()!.Split().Select(int.Parse).ToArray();
            currentPassenger += input[1] - input[0];
            maxPassenger = Math.Max(currentPassenger, maxPassenger);
        }
        Console.WriteLine(maxPassenger);
    }
}