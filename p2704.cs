using System;

// p2704 - 이진법 시계 (B2)
// #구현
// 2025.2.24 solved

public class Program
{
    public static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine());

        for (int i = 0; i < t; i++)
        {
            int[] time = Array.ConvertAll(Console.ReadLine().Split(':'), int.Parse);
            int h = time[0];
            int m = time[1];
            int s = time[2];
            int[,] bit = new int[3, 6];
            int digit = 32;
            // h, m, s를 이진수로 만들어서 각 자리에 넣음
            for (int j = 0; j < 6; j++)
            {
                bit[0, j] = h / digit;
                h %= digit;
                bit[1, j] = m / digit;
                m %= digit;
                bit[2, j] = s / digit;
                s %= digit;
                digit /= 2;
            }
            // 열 기준으로 위에서 아래로 1줄씩
            for (int j = 0; j < 6; j++)
            {
                for (int k = 0; k < 3; k++)
                {
                    Console.Write(bit[k, j]);
                }
            }
            Console.Write(" ");
            // 행 기준으로 왼쪽에서 오른쪽으로 1줄씩
            for (int j = 0; j < 3; j++)
            {
                for (int k = 0; k < 6; k++)
                {
                    Console.Write(bit[j, k]);
                }
            }
            Console.WriteLine();
        }
    }
}
