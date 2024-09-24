using System;
using System.Linq;
using System.Collections.Generic;

// p3052 - 나머지, B2
// 해결 날짜 : 2023/8/20

public class Program
{
    public static void Main(string[] args)
    {
        List<int> input = new List<int>();

        for (int i = 0; i < 10; i++)
        {
            input.Add(int.Parse(Console.ReadLine()) % 42);
        }

        int count = input.Distinct().Count();

        Console.WriteLine(count);
    }
}
