using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

public class Program
{
    public static void Main(string[] args)
    {
        StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
        int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int l = input[0];
        int c = input[1];

        List<string> arr = Console.ReadLine().Split().ToList();

        arr.Sort();
        StringBuilder s = new();
        Find(arr, c, 0, l, 0, 0, "", s);
        sw.WriteLine(s);
        sw.Flush();
        sw.Close();
    }

    public static void Find(List<string> arr, int n, int front, int remain, int con, int vow, string picked, StringBuilder s)
    {
        if (remain == 0)
        {
            if (con >= 2 && vow >= 1)
                s.AppendLine(string.Join(" ", picked));
            return;
        }
        for (int i = front; i < n; i++)
        {
            picked += arr[i];
            if (IsVowel(arr[i]))
                Find(arr, n, i + 1, remain - 1, con, vow + 1, picked, s);
            else
                Find(arr, n, i + 1, remain - 1, con + 1, vow, picked, s);
            picked = picked.Substring(0, picked.Length - 1);
        }
    }

    public static bool IsVowel(string s)
    {
        return s == "a" || s == "e" || s == "i" || s == "o" || s == "u";
    }
}
