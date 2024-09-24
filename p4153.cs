using System;
using System.Linq;
using System.Collections.Generic;

/// <summary>
/// p4153 - 직각삼각형, B3
/// 해결 날짜 : 2023/8/23
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        List<int> input = new List<int>();
        while (true)
        {
            input.Clear();
            input.AddRange(Console.ReadLine().Split(' ').Select(x => int.Parse(x)));

            if (input[0] * input[1] * input[2] == 0) break;

            input.Sort();
            if (input[0] * input[0] + input[1] * input[1] == input[2] * input[2])
            {
                Console.WriteLine("right");
            }
            else
            {
                Console.WriteLine("wrong");
            }
        } 
    }
}
