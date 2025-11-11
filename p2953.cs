#pragma warning disable CS8604, CS8602, CS8600

using System;
using System.Linq;

// p2953 - 나는 요리사다 (B3)
// #수학
// 2025.11.12 solved (11.11)

public class Program
{
    public static void Main(string[] args)
    {
        int winner = 0;
        int winnerScore = 0;
        for (int i = 0; i < 5; i++)
        {
            int sum = Console.ReadLine().Split().Select(int.Parse).Sum();
            if (winnerScore < sum)
            {
                winnerScore = sum;
                winner = i + 1;
            }
        }
        Console.WriteLine($"{winner} {winnerScore}");
    }
}
