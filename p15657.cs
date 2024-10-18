using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Program
{
    public static void Main(string[] args)
    {
        int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int n = input[0];
        int k = input[1];

        List<int> arr = Console.ReadLine().Split().Select(int.Parse).ToList();

        arr.Sort();
        StringBuilder s = new();
        Find(arr, n, 0, k, new List<int>(), s);
        Console.WriteLine(s);
    }

    public static void Find(List<int> arr, int n, int front, int remain, List<int> picked, StringBuilder s)
    {
        if (remain == 0)
        {
            s.AppendLine(string.Join(" ", picked));
            return;
        }
        for (int i = front; i < n; i++)
        {
            picked.Add(arr[i]);
            Find(arr, n, i, remain - 1, picked, s);
            picked.RemoveAt(picked.Count - 1);
        }
    }
}
