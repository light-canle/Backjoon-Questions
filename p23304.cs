using System;
using System.IO;

// p23304 - 아카라카 (S2)
// #문자열 #재귀
// 2025.6.4 solved

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        string s = sr.ReadLine();

        if (Akaraka(s))
        {
            Console.WriteLine("AKARAKA");
        }
        else
        {
            Console.WriteLine("IPSELENTI");
        }
        sr.Close();
    }

    public static bool Akaraka(string s)
    {
        int len = s.Length;
        // 길이가 1인 것은 반드시 아카라카 팰린드롬이다.
        if (len == 1) return true;
        // 팰린드롬인지 판별
        if (!Palindrome(s)) return false;
        // floor(len / 2) 길이의 접두사, 접미사 추출
        string pre = s.Substring(0, len / 2);
        string suf = s.Substring(len % 2 == 0 ? len / 2 : len / 2 + 1);
        // 접두사, 접미사가 둘 다 아카라카 팰린드롬인지 검사
        return Akaraka(pre) && Akaraka(suf);
    }

    public static bool Palindrome(string s)
    {
        int l = 0, r = s.Length - 1;
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
