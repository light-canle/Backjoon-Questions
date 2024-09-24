using System;
using System.Linq;

/// <summary>
/// p25304 - 영수증, B4
/// 해결 날짜 : 2023/10/18
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());

        int count = int.Parse(Console.ReadLine());

        int sum = 0;
        for (int i = 0; i < count; i++)
        {
            int[] cur = Console.ReadLine().Split().Select(int.Parse).ToArray();
            sum += cur[0] * cur[1];
        }

        Console.WriteLine((sum == N) ? "Yes" : "No");
    }
}