using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    public static List<int> primes;
    public static void Main(string[] args)
    {
        primes = new List<int>();
        List<int> list = Enumerable.Range(2, 99999).ToList();

        while (true)
        {
            int p = list[0];

            if (p * p > 100000)
                break;

            primes.Add(p);
            list.RemoveAll(x => x % p == 0);
        }
        primes.AddRange(list);
        int n = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());

        int count = 0;
        for (int i = 1; i <= n; i++)
        {
            int m = MaxFactor(i);
            if (m <= k) count++;
        }
        Console.WriteLine(count);
    }

    public static int MaxFactor(int n)
    {
        if (n == 1) return 1;
        int i = 0;
        int p = primes[i];
        while (n > 1)
        {
            if (n % p == 0)
            {
                n /= p;
            }
            else
            {
                i++;
                p = primes[i];
            }
        }
        return p;
    }
}
