#pragma warning disable CS8604, CS8602, CS8600

using System;
using System.Collections.Generic;

// p27891 - 특별한 학교 이름 암호화 (B2)
// #문자열
// 2025.3.28 solved

public class Program
{
    public static void Main(string[] args)
    {
        Dictionary<string, string> name = new Dictionary<string, string>();
        name["northlondo"] = "NLCS";
        name["branksomeh"] = "BHA";
        name["koreainter"] = "KIS";
        name["stjohnsbur"] = "SJA";
        string input = Console.ReadLine();

        for (int i = 0; i < 26; i++)
        {
            string cur = "";
            foreach (char c in input)
            {
                cur += Next(c);
            }
            if (name.ContainsKey(cur))
            {
                Console.WriteLine(name[cur]);
                return;
            }
            input = cur;
        }
    }

    public static char Next(char c)
    {
        if ('a' <= c && c <= 'z')
        {
            return c == 'z' ? 'a' : (char)(c + 1);
        }
        return c;
    }
}
