using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        List<int> list = Enumerable.Range(2, 999999).ToList();
        
        List<int> prime = new List<int>();

        while (true)
        {
            int p = list[0];

            if (p * p > 1000000)
                break;

            prime.Add(p);
            list.RemoveAll(x => x % p == 0);
        }
        prime.AddRange(list);

        StringBuilder output = new();
        
        while (true)
        {
            int N = int.Parse(sr.ReadLine());

            if (N == 0)
            {
                break;
            }
            
            int c = prime.Count;

            for (int j = 0; j < c; j++)
            {
                if (Contain(prime, N - prime[j]))
                {
                    int a = Math.Min(prime[j], N - prime[j]);
                    int b = Math.Max(prime[j], N - prime[j]);
                    output.AppendLine($"{N} = {a} + {b}");
                    break;
                }
            }
        }
        Console.WriteLine(output);
        sr.Close();
    }

    public static bool Contain(List<int> sorted, int n)
    {
        int low = 0, high = sorted.Count - 1;
        while (low <= high)
        {
            int mid = (low + high) / 2;
            if (sorted[mid] == n)
                return true;
            else if (sorted[mid] < n)
            {
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }
        return false;
    }
}
