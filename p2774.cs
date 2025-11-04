#pragma warning disable CS8604, CS8602, CS8600

using System;

// p2774 - 아름다운 수 (B2)
// #구현
// 2025.11.5 solved (11.4)

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            int k = int.Parse(Console.ReadLine());
            Console.WriteLine(Beauty(k));
        }
    }

    public static int Beauty(int n)
    {
        string s = n.ToString();
        bool[] digit = new bool[10];
        foreach (char c in s)
        {
            digit[c - '0'] = true;
        }
        int beauty = 0;
        for (int i = 0; i < 10; i++)
        {
            beauty += digit[i] ? 1 : 0;
        }
        return beauty;
    }
}
