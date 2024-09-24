using System;
using System.Collections.Generic;

/// <summary>
/// p1835 - 카드, S4
/// 해결 날짜 : 2023/11/16
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        int numCard = int.Parse(Console.ReadLine()!);
        
        LinkedList<int> list = new LinkedList<int>();

        list.AddFirst(numCard);

        for (int i = numCard - 1; i >= 1 ; i--)
        {
            list.AddFirst(i);

            for (int j = 0; j < i; j++)
            {
                int temp = list.Last();
                list.RemoveLast();
                list.AddFirst(temp);
            }
        }
        
        Console.WriteLine(string.Join(" ", list));
    }
}