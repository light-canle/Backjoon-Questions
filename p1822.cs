using System;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new (new BufferedStream(Console.OpenStandardInput()));
        int[] size = sr.ReadLine().Split().Select(int.Parse).ToArray();
        List<int> a1 = sr.ReadLine().Split().Select(int.Parse).ToList();
        List<int> a2 = sr.ReadLine().Split().Select(int.Parse).ToList();
        a1.Sort();
        a2.Sort();

        List<int> minus = new();

        int a1Size = a1.Count;
        for (int i = 0; i < a1Size; i++)
        {
            if (!Contain(a1[i], a2))
                minus.Add(a1[i]);
        }

        Console.WriteLine(minus.Count);
        if (minus.Count > 0){
            StringBuilder sb = new();
            int m = minus.Count;
            for (int i = 0; i < m; i++)
            {
                sb.Append(minus[i]);
                if (i != m - 1)
                    sb.Append(" ");
            }
            Console.WriteLine(sb);
        }
            
        sr.Close();
    }

    public static bool Contain(int n, List<int> l)
    {
        int low = 0;
        int high = l.Count - 1;
        while (low <= high)
        {
            int mid = (low + high) / 2;
            if (l[mid] == n)
                return true;
            else if (l[mid] > n)
                high = mid - 1;
            else
                low = mid + 1;
        }
        return low < l.Count && l[low] == n;
    }
}
