using System;
using System.Collections.Generic;

// p11656 - 접미사 배열 (S4)
// #문자열 #정렬
// 2025.5.9 solved

public class Program
{
    public static void Main(string[] args)
    {
        string str = Console.ReadLine();
        List<string> suffix = new List<string>();
        int len = str.Length;
        for (int i = 1; i <= len; i++)
        {
            suffix.Add(str.Substring(len - i, i));
        }
        suffix.Sort();
        foreach (string suf in suffix)
        {
            Console.WriteLine(suf);
        }
    }
}
