#pragma warning disable CS8604, CS8602, CS8600

using System;

// p10995 - 별 찍기 - 20 (B3)
// #구현
// 2025.10.31 solved (10.30)

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            if (i % 2 == 0)
                Console.WriteLine(Repeat("* ", n - 1) + "*");
            else
                Console.WriteLine(Repeat(" *", n));
        }
    }

    public static string Repeat(string s, int time)
    {
        string ret = "";
        for (int i = 0; i < time; i++)
            ret += s;
        return ret;
    }
}
