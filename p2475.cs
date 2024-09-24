using System;
using System.Linq;
using System.Collections.Generic;

// p2475 - 검증수, B5
// 해결 날짜 : 2023/8/20

public class Program
{
    public static void Main(string[] args)
    {
        List<int> input = Console.ReadLine().ToLower().Split(' ').Select(x => int.Parse(x)).ToList();

        int sum = input.Select(x => x * x).Sum(); 

        Console.WriteLine(sum % 10);
    }
}