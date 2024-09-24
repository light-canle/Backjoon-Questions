using System;
using System.Linq;
using System.Collections.Generic;

/// <summary>
/// p1672 - DNA 해독, B1
/// 해결 날짜 : 2023/10/30
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        int size = int.Parse(Console.ReadLine()!);
        List<char> input = Console.ReadLine()!.ToCharArray().ToList();

        char B = input[^1];
        for (int i = size - 2; i >= 0; i--) 
        {
            char A = input[i];

            char result = '0';
            switch (A.ToString() + B.ToString())
            {
                case "AA":
                case "AC":
                case "GT":
                case "CA":
                case "TG":
                    result = 'A';
                    break;
                case "AG":
                case "GA":
                case "CC":
                    result = 'C';
                    break;
                case "AT":
                case "GG":
                case "CT":
                case "TA":
                case "TC":
                    result = 'G';
                    break;
                case "GC":
                case "CG":
                case "TT":
                    result = 'T';
                    break;
            }
            B = result;
        }
        Console.WriteLine(B);
    }
}