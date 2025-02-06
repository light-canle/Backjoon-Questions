using System;
using System.Collections.Generic;

// p2857 - FBI (B3)
// #문자열
// 2025.2.6 solved

public class Program
{
    public static void Main(string[] args)
    {
        string[] names = new string[5];
        List<int> ret = new();
        for (int i = 0; i < 5; i++)
        {
            names[i] = Console.ReadLine();
            if (names[i].Contains("FBI"))
            {
                ret.Add(i + 1);
            }
        }

        if (ret.Count == 0)
        {
            Console.WriteLine("HE GOT AWAY!");
        }
        else
        {
            Console.WriteLine(string.Join(" ", ret));
        }
    }
}
