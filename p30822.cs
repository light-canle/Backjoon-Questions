#pragma warning disable CS8604, CS8602, CS8600

using System;

// p30822 - UOSPC 세기 (B3)
// #문자열
// 2025.3.24 sovled

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        string s = Console.ReadLine();
        int[] count = new int[5]; // u,o,s,p,c의 개수
        foreach (char c in s)
        {
            switch (c)
            {
                case 'u':
                    count[0]++; break;
                case 'o':
                    count[1]++; break;
                case 's':
                    count[2]++; break;
                case 'p':
                    count[3]++; break;
                case 'c':
                    count[4]++; break;
            }
        }
        int min = count[0];
        for (int i = 1; i < 5; i++)
        {
            min = Math.Min(min, count[i]);
        }
        Console.WriteLine(min);
    }
}
