using System;

// p2935 - 소음 (B3)
// #사칙연산 #문자열
// 2025.4.2 solved

public class Program
{
    public static void Main(string[] args)
    {
        int n1 = Console.ReadLine().Length;
        char oper = Console.ReadLine()[0];
        int n2 = Console.ReadLine().Length;

        switch (oper)
        {
        case '+':
            if (n1 == n2)
            {
                Console.WriteLine("2" + new string('0', n1 - 1));
            }
            else
            {
                int m = Math.Min(n1, n2);
                int M = Math.Max(n1, n2);
                Console.WriteLine("1" + new string('0', M - m - 1) + "1" + new string('0', m - 1));
            }
            break;
        case '*':
            int len = n1 + n2 - 1;
            Console.WriteLine("1" + new string('0', len - 1));
            break;
        }
    }
}
