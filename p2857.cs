using System;
using System.Collections.Generic;

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
