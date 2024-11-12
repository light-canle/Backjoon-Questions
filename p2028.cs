using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Numerics;

public class Program
{
    public static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine());

        for (int i = 0; i < t; i++)
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(Check(n) ? "YES" : "NO");
        }
    }

    public static bool Check(int n)
    {
        int digit = n.ToString().Length;
        int square = n * n;
        int p = (int)Math.Pow(10, digit);
        return square % p == n;
    }
}
