#pragma warning disable CS8604, CS8602, CS8600

using System;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        int T = int.Parse(Console.ReadLine());

        for (int i = 0; i < T; i++)
        {
            int N = int.Parse(Console.ReadLine());
            int[] list = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int[] prefix = new int[list.Length + 1];

            int curSum = 0;
            for (int j = 1; j < N + 1; j++)
            {
                curSum += list[j - 1];
                prefix[j] = curSum;
            }

            int maxPart = -987654321;

            for (int j = 0; j < N; j++)
            {
                for (int k = j + 1; k < N + 1; k++)
                {
                    int curPart = prefix[k] - prefix[j];
                    if (curPart > maxPart) maxPart = curPart;
                }
            }

            Console.WriteLine(maxPart);
        }
    }
}
