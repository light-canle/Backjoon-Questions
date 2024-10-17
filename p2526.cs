using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int n = arr[0];
        int p = arr[1];
        List<int> list = new List<int>();
        list.Add(n);

        int cur = n;
        while (true)
        {
            cur = (cur * n) % p;
            if (list.Contains(cur))
            {
                Console.WriteLine(list.Count - list.IndexOf(cur));
                break;
            }
            list.Add(cur);
        }
    }
}
