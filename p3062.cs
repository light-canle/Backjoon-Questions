using System;
using System.Linq;

// p3062 - 수 뒤집기 (B2)
// #문자열 #사칙연산
// 2025.3.17 solved

public class Program
{
    public static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine());
        for (int i = 0; i < t; i++)
        {
            string line = Console.ReadLine();
            string rev = new string(line.Reverse().ToArray());
            int sum = int.Parse(line) + int.Parse(rev);
            bool p = Palindrome(sum.ToString());
            Console.WriteLine(p ? "YES" : "NO");
        }
    }

    public static bool Palindrome(string s)
    {
        int l = 0;
        int r = s.Length - 1;
        while (l < r)
        {
            if (s[l] != s[r])
            {
                return false;
            }
            l++; r--;
        }
        return true;
    }
}
