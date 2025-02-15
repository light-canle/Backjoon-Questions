using System;
using System.Collections.Generic;

// p3460 - 이진수 (B3)
// #정수론
// 2025.2.16 solved

public class Program
{
    public static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine());

        for (int i = 0; i < t; i++)
        {
            int n = int.Parse(Console.ReadLine());

            // 10 -> 2
            string bin = "";
            while (n > 0)
            {
                bin += (n % 2).ToString();
                n /= 2;
            }

            List<int> ret = new();
            for (int j = 0; j < bin.Length; j++)
            {
                if (bin[j] == '1')
                {
                    ret.Add(j);
                }
            }
            Console.WriteLine(string.Join(" ", ret));
        }
    }
}
