using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        int[] size = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        int n = size[0], m = size[1];
        List<List<int>> cards = 
new();
        for (int i = 0; i < n; i++)
        {
            var line = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            line.Sort();
            line.Reverse();
            cards.Add(line);
        }
        int[] score = new int[n];
        for (int i = 0; i < m; i++)
        {
            int turnMax = cards[0][i];
            for (int j = 1; j < n; j++)
            {
                turnMax = Math.Max(turnMax, cards[j][i]);
            }
            for (int j = 0; j < n; j++)
            {
                if (cards[j][i] == turnMax)
                {
                    score[j]++;
                }
            }
        }
        int maxScore = score.Max();
        List<int> winners = new();
        for (int i = 0; i < n; i++)
        {
            if (score[i] == maxScore)
            {
                winners.Add(i + 1);
            }
        }
        Console.WriteLine(string.Join(" ", winners));
    }
}
