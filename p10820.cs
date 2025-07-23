#pragma warning disable CS8604, CS8602, CS8600

using System;

// p10820 - 문자열 분석 (B2)
// #문자열
// 2025.7.24 solved (7.23)

public class Program
{
    public static void Main(string[] args)
    {
        while (true) 
        {
            string s = Console.ReadLine();
            if (s == null)
            {
                break;
            }
            int low = 0, up = 0, num = 0, blank = 0;
            for (int i = 0; i < s.Length; i++)
            {
                int code = s[i];
                if (code == 32)
                {
                    blank++;
                }
                if (65 <= code && code <= 90)
                {
                    up++;
                }
                if (97 <= code && code <= 122)
                {
                    low++;
                }
                if (48 <= code && code <= 57)
                {
                    num++;
                }
            }
            Console.WriteLine($"{low} {up} {num} {blank}");
        }
    }
}
