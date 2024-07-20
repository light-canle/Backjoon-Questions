using System;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int N = input[0], S = input[1];

        int[] list = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);    
        long[] prefix = new long[list.Length + 1];

        long curSum = 0;
        for (int i = 0; i < list.Length; i++)
        {
            curSum += list[i];
            prefix[i + 1] = curSum;
        }

        int s = 0, e = 1;
        int minLen = 987654321;
        while (true)
        {
            if (prefix[e] - prefix[s] >= S) 
            {
                s++;
                if (e - s + 1 < minLen)
                {
                    minLen = e - s + 1;
                }
            }
            else if (prefix[e] - prefix[s] < S) e++;
            if (e > list.Length) break;
        }
        Console.WriteLine(minLen == 987654321 ? 0 : minLen);
    }
}
