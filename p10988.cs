using System;

/// <summary>
/// p10988 - 팰린드롬인지 확인하기, B2
/// 해결 날짜 : 2023/12/3
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        string input = Console.ReadLine()!;

        Console.Write(IsPalindrome(input) ? 1 : 0);
    }

    public static bool IsPalindrome(string input)
    {
        return IsPalindrome(input, 0, input.Length - 1);
    }

    public static bool IsPalindrome(string input, int left, int right)
    {
        if (left >= right)
            return true;
        else if (input[left] == input[right])
            return IsPalindrome(input, left + 1, right - 1);
        else 
            return false;
    }
}