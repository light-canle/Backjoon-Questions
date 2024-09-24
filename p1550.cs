using System;

/// <summary>
/// p1550 - 16진수, B2
/// 해결 날짜 : 2023/10/16
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        string input = Console.ReadLine();

        int result = 0;
        int mplier = 1;
        for (int i = input.Length - 1; i >= 0; i--)
        {
            if ('A' <= input[i] && input[i] <= 'F')
            {
                result += mplier * (Convert.ToInt32(input[i]) - 65 + 10);
            }
            else
            {
                result += mplier * (Convert.ToInt32(input[i]) - Convert.ToInt32('0'));
            }
            mplier *= 16;
        }
        Console.WriteLine(result);
    }
}