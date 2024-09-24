using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Numerics;

/// <summary>
/// p21737 - SMUPC 계산기, S1
/// 해결 날짜 : 2024/3/6
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        int count = int.Parse(sr.ReadLine()!);

        string input = sr.ReadLine()!;
        int[] numbers = input.Split(new char[] { 'S', 'M', 'U', 'P', 'C' })
            .Where(x => (x != ""))
            .Select(int.Parse)
            .ToArray();
        char[] opers = input.Where(x => "SMUPC".Contains(x)).ToArray();
        
        StringBuilder sb = new StringBuilder();
        if (!opers.Contains('C'))
        {
            Console.WriteLine("NO OUTPUT");
            return;
        }
        int result = numbers[0];
        int index = 1;

        foreach (char c in opers)
        {
            switch (c)
            {
                case 'C':
                    sb.Append(result + " "); break;
                case 'S':
                    if (index < numbers.Length)
                    {
                        result -= numbers[index];
                        index++;
                    }
                    break;
                case 'M':
                    if (index < numbers.Length)
                    {
                        result *= numbers[index];
                        index++;
                    }
                    break;
                case 'U':
                    if (index < numbers.Length)
                    {
                        result /= numbers[index];
                        index++;
                    }  
                    break;
                case 'P':
                    if (index < numbers.Length)
                    {
                        result += numbers[index];
                        index++;
                    }
                    break;
            }
        }

        Console.WriteLine(sb);
        sr.Close();
    }
}