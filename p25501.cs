using System;
using System.Linq;
using System.IO;

/// <summary>
/// p25501 - 재귀의 귀재, B2
/// 해결 날짜 : 2024/3/31
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));

        int N = int.Parse(sr.ReadLine()!);

        for (int i = 0; i < N; i++)
        {
            string input = sr.ReadLine()!;

            (int isPalindrome, int time) = IsPalindrome(input, 0, 0, input.Length - 1);

            Console.WriteLine($"{isPalindrome} {time}");
        }
        
    }

    public static (int, int) IsPalindrome(string s, int time, int lpos, int rpos)
    {
        if (s[lpos] != s[rpos]) { return (0, time + 1); }
        else if (lpos >= rpos) { return (1, time + 1); }
        else return IsPalindrome(s, time + 1, lpos + 1, rpos - 1);
    }
}