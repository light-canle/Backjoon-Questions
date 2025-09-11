#pragma warning disable CS8604, CS8602, CS8600

using System;

// p2711 - 오타맨 고창영 (B2)
// #문자열
// 2025.9.12 solved

public class Program
{
    public static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine());
        for (int i = 0; i < t; i++)
        {
            string[] input = Console.ReadLine().Split(' ');
            int wrong = int.Parse(input[0]);
            string str = input[1];
            Console.WriteLine(str.Substring(0, wrong - 1) + str.Substring(wrong));
        }
    }
}
