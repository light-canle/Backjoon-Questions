using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));

        while (true)
        {
            int[] size = Array.ConvertAll(sr.ReadLine().Trim().Split(), int.Parse);
            int n = size[0], m = size[1];
            if (n == 0 && m == 0)
            {
                break;
            }
            int[] arr1 = new int[n];
            int[] arr2 = new int[m];

            for (int i = 0; i < n; i++)
            {
                arr1[i] = int.Parse(sr.ReadLine().Trim());
            }
            for (int i = 0; i < m; i++)
            {
                arr2[i] = int.Parse(sr.ReadLine().Trim());
            }

            int p1 = 0, p2 = 0;

            int count = 0;
            while (p1 < n && p2 < m)
            {
                if (arr1[p1] == arr2[p2])
                {
                    count++; p1++; p2++;
                }
                else if (arr1[p1] > arr2[p2])
                {
                    p2++;
                }
                else
                {
                    p1++;
                }
            }

            Console.WriteLine(count);
        }

        sr.Close();
    }
}
