using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Numerics;

/// <summary>
/// p1711 - 직각삼각형, G5
/// 시작 날짜 : 2023/11/14
/// </summary>

// 시간 초과로 인한 미해결 문제

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        int num = int.Parse(sr.ReadLine()!);

        Span<long> px = new long[num];
        Span<long> py = new long[num];

        for (int i = 0; i < num; i++)
        {
            Span<long> input = sr.ReadLine()!.Split().Select(long.Parse).ToArray();
            px[i] = input[0];
            py[i] = input[1];
        }

        long numOfTriangle = 0;
        for (int i = 0; i < num; i++)
        {
            for (int j = i + 1; j < num; j++)
            {
                for (int k = j + 1; k < num; k++)
                {

                    long a = SquareLength(px[i], py[i], px[j], py[j]);
                    long b = SquareLength(px[j], py[j], px[k], py[k]);
                    long c = SquareLength(px[k], py[k], px[i], py[i]);

                    BigInteger sum = (BigInteger)a + b + c;
                    long max_len = Math.Max(Math.Max(a, b), c);

                    if (max_len == sum - max_len)
                    {
                        numOfTriangle++;
                    }
                }
            }
        }

        Console.WriteLine(numOfTriangle);
        sr.Close();
    }

    public static long SquareLength(long x1, long y1, long x2, long y2)
    {
        return (x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1);
    }
}