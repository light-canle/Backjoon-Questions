using System;
using System.Linq;
using System.Collections.Generic;

/// <summary>
/// p2164 - 카드2, S4
/// 해결 날짜 : 2023/8/23
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        Queue<int> deck = new Queue<int>();

        for (int i = 1; i <= N; i++)
        {
            deck.Enqueue(i);
        }

        while (deck.Count > 1)
        {
            deck.Dequeue();
            deck.Enqueue(deck.Dequeue());
        }

        Console.WriteLine(deck.Dequeue());
    }
}