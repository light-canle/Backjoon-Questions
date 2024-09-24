using System;
using System.Linq;
using System.Collections.Generic;

/// <summary>
/// p1431 - 시리얼 번호, S3
/// 해결 날짜 : 2023/10/26
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine()!);
        
        List<string> list = new List<string>();

        for (int i = 0; i < N; i++)
        {
            list.Add(Console.ReadLine()!);
        }

        var sorted = from serial in list
                     orderby serial.Length
                     group serial by serial.Length into sameLength
                     select sameLength.OrderBy(s => DigitSum(s)).ThenBy(s => s).ToList();

        List<string> result = new List<string>();

        foreach (var l in sorted)
        {
            result.AddRange(l);
        }

        foreach (var s in result)
        {
            Console.WriteLine(s);
        }  
    }

    public static int DigitSum(string str)
    {
        int sum = 0;
        foreach (char c in str)
        {
            if (char.IsNumber(c)) sum += Convert.ToInt32(c) - Convert.ToInt32('0');
        }
        return sum;
    }
}