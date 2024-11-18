using System;
using System.IO;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        int n = int.Parse(sr.ReadLine());

        for (int i = 0; i < n; i++)
        {
            int g = int.Parse(sr.ReadLine());
            int[] a = new int[g];
            for (int j = 0; j < g; j++)
            {
                a[j] = int.Parse(sr.ReadLine());
            }
            int m = 1;
            while (!NotOverlaped(a, m)) m++;
            Console.WriteLine(m);
        }
        sr.Close();
    }

    public static bool NotOverlaped(int[] a, int m)
    {
        List<int> remainder = new();
        bool check = true;
        for (int i = 0; i < a.Length; i++)
        {
            int r = a[i] % m;
            if (!remainder.Contains(r))
            {
                remainder.Add(r);
            }
            else
            {
                check = false;
                break;
            }
        }
        return check;
    }
}
