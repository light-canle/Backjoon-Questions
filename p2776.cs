using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;

// p2776 - 암기왕 (S4)
// #정렬 #이분 탐색
// 2025.2.9 solved

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new (new BufferedStream(Console.OpenStandardInput()));
        StreamWriter sw = new (new BufferedStream(Console.OpenStandardOutput()));
        int t = int.Parse(sr.ReadLine().Trim());

        for (int i = 0; i < t; i++)
        {
            int n = int.Parse(sr.ReadLine().Trim());
            List<int> list = sr.ReadLine().Trim().Split().Select(int.Parse).ToList();
            list.Sort();

            int m = int.Parse(sr.ReadLine().Trim());
            List<int> q = sr.ReadLine().Trim().Split().Select(int.Parse).ToList();

            StringBuilder s = new();
            for (int j = 0; j < m; j++)
            {
                if (IsContain(q[j], list))
                {
                    s.Append("1");
                }
                else
                {
                    s.Append("0");
                }
                s.AppendLine("");
            }

            sw.Write(s);
        }

        sw.Flush();
        sr.Close();
        sw.Close();
    }

    public static bool IsContain(int n, List<int> sorted)
    {
        int left = 0;
        int right = sorted.Count - 1;
        int mid = (left + right) / 2;

        while (left <= right)
        {
            mid = (left + right) / 2;
            if (sorted[mid] == n)
            {
                return true;
            }
            else if (sorted[mid] > n)
            {
                right = mid - 1;
            }
            else
            {
                left = mid + 1;
            }
        }

        return false;
    }
}
