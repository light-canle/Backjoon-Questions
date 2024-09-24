using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

/// <summary>
/// p2693 - N번째 큰 수, B1
/// 해결 날짜 : 2024/3/14(solved.ac : 3/13)
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        // input
        int testCase = int.Parse(sr.ReadLine()!);

        for (int i = 0; i < testCase; i++)
        {
            List<int> input = sr.ReadLine()!.Split().Select(int.Parse).ToList();
            input.Sort();
            Console.WriteLine(input[^3]);
        }
    }
}
