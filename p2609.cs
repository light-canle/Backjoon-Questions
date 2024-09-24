using System;
using System.Linq;
using System.Collections.Generic;

/// <summary>
/// p2609 - 최대공약수와 최소공배수, B1
/// 해결 날짜 : 2023/8/21
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        
        int[] input = Console.ReadLine().Trim().Split(' ').Select(x => int.Parse(x)).ToArray();

        Console.WriteLine(GCD(input[0], input[1]));
        Console.WriteLine(LCM(input[0], input[1]));
    }

    public static int GCD(int a, int b)
    {
        int large = (a > b) ? a : b;
        int small = (a < b) ? a : b;

        if (large % small == 0)
        {
            return small;
        }
        return GCD(small, large % small);
    }

    public static int LCM(int a, int b)
    {
        return (a * b) / GCD(a, b);
    }
}
