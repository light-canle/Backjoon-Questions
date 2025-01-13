#pragma warning disable CS8604, CS8602, CS8600

using System;
using System.Collections.Generic;

public class Program
{
    public static List<int> timeNumbers;
    public static void Main(string[] args)
    {
        timeNumbers = new List<int>();
        for (int h = 0; h < 24; h++)
        {
            for (int m = 0; m < 60; m++)
            {
                for (int s = 0; s < 60; s++)
                {
                    timeNumbers.Add(h * 10000 + m * 100 + s);
                }
            }
        }
        for (int i = 0; i < 3; i++)
        {
            string[] input = Console.ReadLine().Split(' ');
            string from = input[0], to = input[1];
            Console.WriteLine(Between(TimeToNumber(from), TimeToNumber(to)));
        }
    }

    public static int TimeToNumber(string input)
    {
        string[] part = input.Split(':');
        int h = int.Parse(part[0]);
        int m = int.Parse(part[1]);
        int s = int.Parse(part[2]);
        return h * 10000 + m * 100 + s;
    }

    public static int Between(int start, int end)
    {
        if (end < start)
        {
            return Between(start, 235959) + Between(0, end);
        }
        else
        {
            int count = 0;
            int sIndex = timeNumbers.IndexOf(start);
            int eIndex = timeNumbers.IndexOf(end);
            for (int i = sIndex; i <= eIndex; i++)
            {
                if (timeNumbers[i] % 3 == 0)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
