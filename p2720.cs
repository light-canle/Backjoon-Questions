using System;

/// <summary>
/// p2720 - 세탁소 사장 동혁, B3
/// 해결 날짜 : 2024/3/26
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        int T = int.Parse(Console.ReadLine()!);
        
        for (int i = 0; i < T; i++)
        {
            int money = int.Parse(Console.ReadLine()!);
            int[] result = FindChange(money);
            Console.WriteLine($"{result[0]} {result[1]} {result[2]} {result[3]}");
        }
    }

    public static int[] FindChange(int money)
    {
        int[] coins = { 25, 10, 5, 1 };
        int[] counts = { 0, 0, 0, 0 };

        for (int i = 0; i < 4; i++)
        {
            counts[i] = money / coins[i];
            money %= coins[i];
        }

        return counts;
    }
}