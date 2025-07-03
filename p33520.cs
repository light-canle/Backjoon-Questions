using System;
using System.IO;

// p33520 - 초코바 만들기 (S5)
// #그리디
// 2025.7.3 solved

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        int n = int.Parse(sr.ReadLine());

        // 가로, 세로 중 짧은 쪽 길이의 최대, 긴 쪽 길이의 최대
        long minTop = 0, maxTop = 0;
        for (int i = 0; i < n; i++)
        {
            long[] size = Array.ConvertAll(sr.ReadLine().Split(), long.Parse);
            long a = size[0], b = size[1];
            // a가 짧은 쪽, b가 긴 쪽이 되도록 배치
            if (a > b)
            {
                long t = a;
                a = b;
                b = t;
            }
            // 값 갱신
            minTop = Math.Max(a, minTop);
            maxTop = Math.Max(b, maxTop);
        }
        // 둘의 곱(넓이)을 반환
        Console.WriteLine(minTop * maxTop);
        sr.Close();
    }
}
