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

        int n = input[0];
        int k = input[1];

        List<int> arr = Console.ReadLine().Split().Select(int.Parse).ToList();

        arr.Sort();
        StringBuilder s = new();
        Find(arr, n, k, new List<int>(), s);
        sw.WriteLine(s);
        sw.Flush();
        sw.Close();
    }

    public static void Find(List<int> arr, int n, int remain, List<int> picked, StringBuilder s)
    {
        if (remain == 0)
        {
            s.AppendLine(string.Join(" ", picked));
            return;
        }
        for (int i = 0; i < n; i++)
        {
            picked.Add(arr[i]);
            Find(arr, n, remain - 1, picked, s);
            picked.RemoveAt(picked.Count - 1);
        }
    }
}
