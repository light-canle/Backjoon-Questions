#pragma warning disable CS8604, CS8602, CS8600

using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        Dictionary<char, string> compress = new Dictionary<char, string>();
        for (int i = 0; i < N; i++)
        {
            string[] words = Console.ReadLine().Split();
            compress[words[1][0]] = words[0];
        }
        string compressedStr = Console.ReadLine();
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < compressedStr.Length; i++)
        {
            sb.Append(compress[compressedStr[i]]);
        }
        string ret = sb.ToString();
        int[] range = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine(ret.Substring(range[0] - 1, range[1] - range[0] + 1));
    }
}
