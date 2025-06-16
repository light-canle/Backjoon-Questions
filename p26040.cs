using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

// p26040 - 특정 대문자를 소문자로 바꾸기 (B3)
// #문자열
// 2025.6.16 solved

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        string input = sr.ReadLine().Trim();
        List<char> convert = sr.ReadLine().Trim().Split().Select(char.Parse).ToList();

        StringBuilder o = new();
        foreach (char c in input)
        {
            if (convert.Contains(c))
            {
                // 32를 더하면 대응하는 소문자가 된다.
                o.Append(((char)(c + 32)).ToString());
            }
            else
            {
                o.Append(c.ToString());
            }
        }
        Console.WriteLine(o);
        sr.Close();
    }
}
