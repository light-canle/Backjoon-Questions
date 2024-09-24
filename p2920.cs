using System;
using System.Linq;
using System.Collections.Generic;

// p2920 - 음계, B2
// 해결 날짜 : 2023/8/20

public class Program
{
    public static void Main(string[] args)
    {
        List<int> input = Console.ReadLine().ToLower().Split(' ').Select(x => int.Parse(x)).ToList();

        List<int> ascending = new List<int>{ 1, 2, 3, 4, 5, 6, 7, 8 };
        List<int> descending = new List<int> { 8, 7, 6, 5, 4, 3, 2, 1 };

        string ans = (Enumerable.SequenceEqual(ascending, input)) ? "ascending" 
            : (Enumerable.SequenceEqual(descending, input)) ? "descending" : "mixed";

        Console.WriteLine(ans);
    }
}
