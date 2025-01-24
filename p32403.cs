using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        int n = input[0], t = input[1];
        List<int> factors = Factor(t);
        
        int[] time = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        int ret = 0;
        for (int i = 0; i < n; i++)
        {
            int minDiff = int.MaxValue;
            foreach (var p in factors)
            {
                minDiff = Math.Min(minDiff, Math.Abs(time[i] - p));
            }
            ret += minDiff;
        }
        Console.WriteLine(ret);
    }

    public static List<int> Factor(int n)
    {
        List<int> factors = new();

        factors.Add(1);
        if (n == 1) return factors;
        factors.Add(n);
        int i = 2;
        while (i * i <= n)
        {
            if (n % i == 0)
            {
                factors.Add(i);
                if (i * i != n) factors.Add(n / i);
            }
            i++;
        }

        return factors;
    }
}
