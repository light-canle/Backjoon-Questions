using System;
using System.Collections.Generic;

// p28255 - 3단 초콜릿 아이스크림 (B1)
// #문자열
// 2025.2.25 solved

public class Program
{
    public static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine());

        for (int i = 0; i < t; i++)
        {
            string line = Console.ReadLine();
            int len = line.Length;

            // find S'
            int prefix = (int)Math.Ceiling(len / 3.0);
            string s = line.Substring(0, prefix);

            // get rev(S'), tail(rev(S')) and tail(S')
            string revS = Rev(s);
            string tailS = Tail(s);
            string tailRevS = Tail(revS);

            // 주어진 4개의 조건에 대응하는 문자열 생성 후 비교
            List<string> candidate = new();
            candidate.Add(s + revS + s);
            candidate.Add(s + tailRevS + s);
            candidate.Add(s + revS + tailS);
            candidate.Add(s + tailRevS + tailS);

            bool isTriple = false;
            foreach (string c in candidate)
            {
                if (c == line)
                {
                    isTriple = true;
                    break;
                }
            }
            Console.WriteLine(isTriple ? "1" : "0");
        }
    }

    public static string Rev(string s)
    {
        char[] chars = s.ToCharArray();
        Array.Reverse(chars);
        string ret = "";
        foreach (char c in chars)
        {
            ret += c;
        }
        return ret;
    }

    public static string Tail(string s)
    {
        return s.Substring(1);
    }
}
