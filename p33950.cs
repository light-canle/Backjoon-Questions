#pragma warning disable CS8604, CS8602, CS8600

using System;

// p33950 - 어게인 포닉스 (B3)
// #문자열
// 2025.7.18 solved

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        
        for (int i = 0; i < n; i++)
        {
            string s = Console.ReadLine();
            s = s.Replace("PO", "PHO");
            Console.WriteLine(s);
        }
    }
}
