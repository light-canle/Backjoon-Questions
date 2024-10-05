using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        List<int> nums = Enumerable.Range(2, 200).ToList();
        List<int> primes = new List<int>();

        while (nums.Count > 0)
        {
            int p = nums[0];
            primes.Add(p);
            nums.RemoveAll(x => x % p == 0);
        }

        int i = 0;
        int k = primes[i] * primes[i + 1];
        while (k <= n)
        {
            i++;
            k = primes[i] * primes[i + 1];
        }
        Console.WriteLine(k);
    }
}
