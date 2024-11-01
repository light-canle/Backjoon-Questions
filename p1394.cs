using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new (new BufferedStream(Console.OpenStandardInput()));
        string union = sr.ReadLine();
        long n = (long)union.Length;
        Dictionary<char, long> dict = new ();
        for (int i = 0; i < union.Length; i++)
        {
            dict[union[i]] = (long)i + 1;
        }
        string code = sr.ReadLine();

        var rev = code.Reverse();
        long k = 0;
        long ans = 0;
        foreach (char c in rev)
        {
            ans += dict[c] * PowMod(n, k, 900528);
            ans %= 900528;
            k++;
        }
        Console.WriteLine(ans);
        sr.Close();
    }

    public static long PowMod(long a, long b, long m)
    {
        if (b == 0) return 1;
        long x = PowMod(a, b / 2, m);
        if (b % 2 == 0)
        {
            return ((x % m) * (x % m)) % m;
        }
        return ((x % m) * (x % m) * (a % m)) % m;
    }
}
