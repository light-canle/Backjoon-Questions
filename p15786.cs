using System;
using System.IO;
using System.Collections.Generic;

// p15786 - Send me the money (B1)
// #문자열
// 2025.6.10 solved

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        int n = line[0], m = line[1];
        string needle = sr.ReadLine();
        List<string> p = new();

        for (int i = 0; i < m; i++)
        {
            p.Add(sr.ReadLine());
        }

        foreach (var s in p)
        {
            Console.WriteLine(IsPassWord(needle, s) ? "true" : "false");
        }
    }
    public static bool IsPassWord(string needle, string h)
    {
        int nlen = needle.Length;
        int hlen = h.Length;
        int nidx = 0;
        int hidx = 0;
        while (nidx < nlen && hidx < hlen)
        {
            if (needle[nidx] == h[hidx])
            {
                nidx++;
            }
            hidx++;
        }
        return nidx == nlen;
    }
}
