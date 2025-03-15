using System;

// p1592 - 영식이와 친구들 (B2)
// #시뮬레이션
// 2025.3.15 solved

public class Program
{
    public static void Main(string[] args)
    {
        int[] input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

        int n = input[0];
        int m = input[1];
        int k = input[2];

        int[] catchTime = new int[n];
        int cur = 0;
        int totalCatch = 0;
        while (true)
        {
            catchTime[cur]++;
            if (catchTime[cur] == m)
            {
                break;
            }
            totalCatch++;
            if (catchTime[cur] % 2 == 0)
            {
                cur += k;
                cur %= n;
            }
            else
            {
                cur -= k;
                cur += n;
                cur %= n;
            }
        }
        Console.WriteLine(totalCatch);
    }
}
