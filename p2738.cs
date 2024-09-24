using System;
using System.Linq;

/// <summary>
/// p2738 - 행렬 덧셈, B5
/// 해결 날짜 : 2023/9/20
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();

        (int N, int M) = (size[0], size[1]);
        int[,] matrix1 = new int[N, M];
        int[,] matrix2 = new int[N, M];
        for (int i = 0; i < N; i++)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            for (int j = 0; j < M; j++)
            {
                matrix1[i, j] = input[j];
            }
        }
        for (int i = 0; i < N; i++)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            for (int j = 0; j < M; j++)
            {
                matrix2[i, j] = input[j];
            }
        }
        int[,] sum = new int[N, M];
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < M; j++)
            {
                sum[i, j] = matrix1[i, j] + matrix2[i, j];
            }
        }
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < M; j++)
                Console.Write(sum[i, j] + " ");
            Console.WriteLine();
        }
    }

}