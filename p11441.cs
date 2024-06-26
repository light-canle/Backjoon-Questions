using System;
using System.Text;

public class Program
{
    public static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());

        int[] A = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        int[] partSum = new int[N + 1];

        for (int i = 1; i <= N; i++)
        {
            partSum[i] = partSum[i - 1] + A[i - 1];
        }

        int M = int.Parse(Console.ReadLine());

        StringBuilder output = new();
        for (int i = 0; i < M; i++)
        {
            int[] line = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            int left = line[0];
            int right = line[1];

            output.AppendLine((partSum[right] - partSum[left - 1]).ToString());
        }

        Console.WriteLine(output);
    }
}
