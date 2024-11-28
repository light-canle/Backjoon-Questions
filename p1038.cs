using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    public static List<long> list;
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        list = new List<long>();
        for (int i = 0; i < 10; i++)
        {
            Generate(i, "");
        }
        list.Sort();
        int len = list.Count;
        if (n > len - 1)
        {
            Console.WriteLine(-1);
        }
        else
        {
            Console.WriteLine(list[n]);
        }
    }

    public static void Generate(int left, string current)
    {
        if (left == -1)
        {
            list.Add(long.Parse(current));
            return;
        }
        for (int i = left - 1; i >= -1; i--)
        {
            Generate(i, current + left);
        }
    }
}
