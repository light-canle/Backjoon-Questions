#pragma warning disable CS8604, CS8602

using System;
using System.Linq;

// p14912 - 숫자 빈도수 (S5)
// #완전 탐색
// 2025.11.15 solved (11.14)

public class Program
{
    public static void Main(string[] args)
    {
        int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        int max = input[0];
        char digit = Char.Parse(input[1].ToString());

        int count = 0;
        for (int i = 1; i <= max; i++)
        {
            string str = i.ToString();
            foreach (char c in str)
            {
                count += c == digit ? 1 : 0;
            }
        }
        Console.WriteLine(count);
    }
}
