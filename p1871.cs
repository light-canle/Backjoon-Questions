#pragma warning disable CS8604, CS8602, CS8600

using System;

// p1871 - 좋은 자동차 번호판 (B2)
// #문자열
// 2025.9.16 solved

public class Program
{
    public static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine());

        for (int i = 0; i < t; i++)
        {
            string name = Console.ReadLine();
            int left = 0;
            for (int j = 0; j < 3; j++)
            {
                left += (name[j] - 'A') * (int)Math.Pow(26, 2 - j);
            }
            int right = int.Parse(name.Substring(4));

            Console.WriteLine(Math.Abs(left - right) <= 100 ? "nice" : "not nice");
        }
    }
}
