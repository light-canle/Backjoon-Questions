using System;
using System.Linq;
using System.Collections.Generic;

/// <summary>
/// p1205 - 등수 구하기, S4
/// 해결 날짜 : 2023/11/29
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        int[] input = Console.ReadLine()!.Split().Select(int.Parse).ToArray();
        (int N, int score, int P) = (input[0], input[1], input[2]);

        if (N == 0)
        {
            Console.WriteLine("1");
            return;
        }

        List<int> rank = Console.ReadLine()!.Split().Select(int.Parse).ToList();

        if (rank.Count == P && score <= rank.Last())
        {
            Console.WriteLine("-1");
            return;
        }

        int curRank = 1;
        int curScore = rank[0], same = 0;
        bool inScoreBoard = false;
        for (int i = 0; i < rank.Count; i++)
        {
            if (rank[i] > score)
            {
                if (curScore == rank[i])
                    same++;
                else
                {
                    curRank += same;
                    same = 1;
                }
            }
            else
            {
                inScoreBoard = true;
                curRank += same;
                break;
            }
        }
        if (!inScoreBoard)
            curRank += same;
        Console.WriteLine(curRank);
    }
}