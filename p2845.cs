using System;
using System.Linq;

/// <summary>
/// p2845 - 파티가 끝나고 난 뒤, B4
/// 해결 날짜 : 2023/9/18
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        int[] area = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] predict_num = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int ans = area[0] * area[1];

        Console.WriteLine(string.Join(" ", predict_num.Select(x => x - ans)));
    }
}