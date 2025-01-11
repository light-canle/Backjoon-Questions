using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int[] a = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        List<int> list = new List<int>();

        int reject = 0;
        for (int i = 0; i < n; i++)
        {
            if (list.Contains(a[i]))
            {
                reject++;
            }
            else
            {
                list.Add(a[i]);
            }
        }
        Console.WriteLine(reject);
    }
}
