using System;

/// <summary>
/// p1356 - 유진수, B1
/// 해결 날짜 : 2024/4/4
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        string N = Console.ReadLine()!;
        bool isAns = false;

        for (int i = 1; i < N.Length; i++)
        {
            long left = DigitMultiply(N.Substring(0, i));
            long right = DigitMultiply(N.Substring(i, N.Length - i));
            if (left == right) { isAns = true; }
        }
        Console.WriteLine((isAns) ? "YES" : "NO");
    }

    public static long DigitMultiply(string s)
    {
        long ans = 1;
        for (int i = 0; i < s.Length; i++)
        {
            ans *= int.Parse(s[i].ToString());
        }
        return ans;
    }
}