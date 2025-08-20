using System;

// p1016 - 제곱 ㄴㄴ 수 (G1)
// #정수론 #에라토스테네스의 체
// 2025.8.20 solved

public class Program
{
    public static void Main(string[] args)
    {
        long[] range = Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
        long a = range[0], b = range[1];
        bool[] divided = new bool[b - a + 1];
        long n = 2;
        while (true)
        {
            long k = n * n;
            if (k > b) break;
            long start = k;
            if (a > k)
            {
                if (a % k == 0)
                    start = a;
                else
                    start = a + k - (a % k);
            }
            for (long j = start; j <= b; j += k)
            {
                divided[j - a] = true;
            }
            n++;
        }
        long count = 0;
        for (int i = 0; i <  divided.Length; i++)
        {
            if (!divided[i]) count++;
        }
        Console.WriteLine(count);
    }
}
