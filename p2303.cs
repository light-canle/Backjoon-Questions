using System;
using System.Linq;

/// <summary>
/// p2303 - 숫자 게임, S5
/// 해결 날짜 : 2023/11/26 (solved.ac 기준 11/25)
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine()!);

        int totalMax = 0;
        int winPerson = 1;
        for (int i = 1; i <= N; i++)
        {
            int[] cards = Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int curMax = 0;
            for (int c1 = 0; c1 < 3; c1++)
            {
                for (int c2 = c1 + 1; c2 < 4; c2++)
                {
                    for (int c3 = c2 + 1; c3 < 5; c3++)
                    {
                        int sum = cards[c1] + cards[c2] + cards[c3];
                        int score = sum % 10;
                        if (curMax < score)
                        {
                            curMax = score;
                        }
                    }
                }
            }

            if (totalMax <= curMax)
            {
                totalMax = curMax;
                winPerson = i;
            }
        }
        Console.WriteLine(winPerson);
    }
}