using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        int T = int.Parse(Console.ReadLine());

        List<int> list = Enumerable.Range(2, 9999).ToList();
        
        List<int> prime = new List<int>();

        while (true)
        {
            int p = list[0];

            if (p * p > 10000)
                break;

            prime.Add(p);
            list.RemoveAll(x => x % p == 0);
        }
        prime.AddRange(list);
        
        for (int i = 0; i < T; i++)
        {
            int N = int.Parse(Console.ReadLine());

            int c = prime.Count;
            int a = 0, b = 0;
            int diff = 99999;

            for (int j = 0; j < c; j++)
            {
                if (Contain(prime, N - prime[j]))
                {
                    int k = N - prime[j];
                    if (diff > Math.Abs(k - prime[j]))
                    {
                        diff = Math.Abs(k - prime[j]);
                        a = Math.Min(prime[j], k);
                        b = Math.Max(prime[j], k);
                    }
                }
            }
            
            Console.WriteLine($"{a} {b}");
        }
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
