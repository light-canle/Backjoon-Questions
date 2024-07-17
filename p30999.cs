using System;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int N = input[0];
        int M = input[1];

        int half = M / 2 + 1;
        int valid = 0;
        for (int i = 0; i < N; i++)
        {
            string vote = Console.ReadLine();
            int count = 0;
            for (int j = 0; j < M; j++)
            {
                if (vote[j] == 'O')
                {
                    count++;
                }
            }
            if (count >= half) valid++;
        }

        Console.WriteLine(valid);
    }
}
