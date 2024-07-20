using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());

        if (N == 1)
        {
            Console.WriteLine(0);
            return;
        }
        List<int> list = Enumerable.Range(2, N - 1).ToList();
        
        List<int> prime = new List<int>();

        while (true)
        {
            int p = list[0];

            if (p * p > N)
                break;

            prime.Add(p);
            list.RemoveAll(x => x % p == 0);
        }
        prime.AddRange(list);

        long[] prefix = new long[prime.Count + 1];

        long curSum = 0;
        for (int i = 0; i < prime.Count; i++)
        {
            curSum += prime[i];
            prefix[i + 1] = curSum;
        }

        int s = 0, e = 1;
        int count = 0;
        while (true)
        {
            if (prefix[e] - prefix[s] == N) count++;
            if (prefix[e] - prefix[s] >= N) s++;
            else if (prefix[e] - prefix[s] < N) e++;
            if (e > prime.Count) break;
        }
        Console.WriteLine(count);
    }
}
