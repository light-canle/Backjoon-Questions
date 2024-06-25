using System;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        int M = int.Parse(Console.ReadLine());

        int[] counts = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int N = counts.Sum();

        int K = int.Parse(Console.ReadLine());

        double prob = 0;

        for (int i = 0; i < M; i++)
        {
            if (counts[i] < K)
                continue;
            int same = counts[i];
            int total = N;
            double curProb = same / (double)total;
            for (int j = 1; j < K; j++)
            {
                same--;
                total--;
                curProb *= same / (double)total;
            }
            prob += curProb;
        }

        Console.WriteLine(prob);
    }
}
