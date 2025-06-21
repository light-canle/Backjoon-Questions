using System;

// p17389 - 보너스 점수 (B2)
// #구현
// 2025.6.21 solved

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        string ox = Console.ReadLine();
        int score = 0;
        int bonus = 0;
        for (int i = 1; i <= n; i++)
        {
            bool correct = ox[i - 1] == 'O';
            score += correct ? i + bonus : 0;
            bonus = correct ? bonus + 1 : 0;
        }
        Console.WriteLine(score);
    }
}
