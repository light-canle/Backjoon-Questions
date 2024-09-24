using System;
using System.Linq;

/// <summary>
/// p2480 - 주사위 세개, B4
/// 해결 날짜 : 2023/9/8
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        int[] dice = Console.ReadLine().Split().Select(int.Parse).ToArray();
        (int d1, int d2, int d3) = (dice[0], dice[1], dice[2]);

        int score;
        // 모두 같은 경우
        if (d1 == d2 && d2 == d3)       score = 10000 + 1000 * d3;
        // 2개가 같은 경우 - 같은 수 * 100이 필요해서 2가지로 나누었다.
        else if (d2 == d3 || d3 == d1)  score = 1000 + 100 * d3;
        else if (d1 == d2)              score = 1000 + 100 * d2;
        // 모두 다른 경우
        else                            score = dice.Max() * 100;
        Console.WriteLine(score);
    }
}