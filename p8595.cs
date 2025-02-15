using System;
using System.Numerics;
using System.IO;

// p8595 - 히든 넘버 (B1)
// #문자열 파싱
// 2025.2.15 solved

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new (new BufferedStream(Console.OpenStandardInput()));
        int n = int.Parse(sr.ReadLine());

        string line = sr.ReadLine();

        BigInteger sum = 0;
        string part = "";
        foreach (var c in line)
        {
            if ('0' <= c && c <= '9')
            {
                part += c;
            }
            else
            {
                if (part.Length > 0)
                {
                    sum += BigInteger.Parse(part);
                    part = "";
                }
            }
        }
        
        if (part.Length > 0)

        {
            sum += BigInteger.Parse(part);
        }

        Console.WriteLine(sum);
        sr.Close();
    }
}
