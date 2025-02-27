using System;
using System.Linq;
using System.IO;

// p22950 - 이진수 나눗셈 (B1)
// #정수론
// 2025.2.27 solved

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new (new BufferedStream(Console.OpenStandardInput()));
        int n = int.Parse(sr.ReadLine());
        string bin = sr.ReadLine().Trim();
        bin = new string(bin.Reverse().ToArray());
        int leastOne = 0;
        while (leastOne < n && bin[leastOne] == '0')
        {
            leastOne++;
        }
        if (leastOne == n)
        {
            Console.WriteLine("YES");
            return;
        }
        int k = int.Parse(sr.ReadLine());
        Console.WriteLine(k <= leastOne ? "YES" : "NO");
    }
}
