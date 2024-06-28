using System;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());

        long[] height = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);

        long sum = height.Sum();
        long front = 2 * sum;
        long top = 2 * N;
        long side = height[0] + height[N - 1];

        long diff = 0;
        if (N >= 2)
        {
            for (int i = 0; i < N - 1; i++)
            {
                diff += Math.Abs(height[i] - height[i + 1]);
            }
        }

        Console.WriteLine(front + top + side + diff);
    }
}
