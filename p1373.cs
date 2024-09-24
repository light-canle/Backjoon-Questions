using System;
using System.Text;

/// <summary>
/// p1373 - 2진수 8진수, B1
/// 해결 날짜 : 2023/9/16
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        string input = Console.ReadLine();
        StringBuilder result = new StringBuilder();
        int start = 0;
        if (input.Length % 3 == 1)
        {
            result.Append(Con8(input.Substring(0, 1)));
            start = 1;
        }
        else if (input.Length % 3 == 2)
        {
            result.Append(Con8(input.Substring(0, 2)));
            start = 2;
        }
        for (int i = start; i < input.Length; i += 3)
        {
            result.Append(Con8(input.Substring(i, 3)));
        }
        Console.WriteLine(result.ToString());
    }

    public static int Con8(string input)
    {
        if (input.Length == 1)
        {
            return Toint(input[0]);
        }
        else if (input.Length == 2)
        {
            return Toint(input[0]) * 2 + Toint(input[1]);
        }
        else
        {
            return Toint(input[0]) * 4 + 
                Toint(input[1]) * 2 + Toint(input[2]);
        }
    }

    public static int Toint(char c)
    {
        return Convert.ToInt32(c) - Convert.ToInt32('0');
    }
}