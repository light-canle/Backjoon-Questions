using System;
using System.Linq;
using System.Collections.Generic;

/// <summary>
/// 유틸컵 Chapter2 - S번(2), Slice String
/// p30034 - B1
/// 해결 날짜 : 2023/9/16
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        char[] split_char = Console.ReadLine().Split().Select(char.Parse).ToArray();
        int M = int.Parse(Console.ReadLine());
        char[] split_num = Console.ReadLine().Split().Select(char.Parse).ToArray();
        int K = int.Parse(Console.ReadLine());
        char[] combiner = Console.ReadLine().Split().Select(char.Parse).ToArray();
        int S = int.Parse(Console.ReadLine());
        string input = Console.ReadLine();

        List<string> output = new List<string>();

        int start = 0;
        for (int i = 0; i < S; i++)
        {
            if (input[i] == ' ' || 
                ( ( split_char.Contains(input[i]) || split_num.Contains(input[i]) ) &&
                !combiner.Contains(input[i]) ) ) 
            {
                if (i - start > 0) output.Add(input.Substring(start, i - start));
                start = i + 1;
            }
        }
        if (S - start > 0) output.Add(input.Substring(start, S - start));
        foreach (string s in output)
        {
            Console.WriteLine(s);
        }
    }
}