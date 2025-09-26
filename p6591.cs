#pragma warning disable CS8604, CS8602, CS8600

using System;

// p6591 - 이항 쇼다운 (S3)
// #조합론
// 2025.9.26 solved

public class Program
{
    public static void Main(string[] args)
    {
        while (true)
        {
            long[] input = Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
            long a = input[0], b = input[1];
            if (a == 0 && b == 0) return;
            // aCb = aCa-b
            if (b > a - b) b = a - b;
            long ret = 1;
            long toProduct = a;
            // aCb = a * (a-1) * ... * (a-b+1) / (b * (b-1) * ... * 1)
            // a, a-1, ...를 곱하면서 1, 2, ...로 나눈다.
            for (long i = 1; i <= b; i++)
            {
                ret *= toProduct;
                ret /= i;
                toProduct--;
            }
            Console.WriteLine(ret);
        }
    }
}
