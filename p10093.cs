#pragma warning disable CS8604, CS8602, CS8600

using System;
using System.IO;
using System.Collections.Generic;

// p10093 - 숫자 (B2)
// #구현
// 2025.12.5 solved

public class Program
{
    public static void Main(string[] args)
    {
        StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput()));
        long[] range = Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
        // 큰 수, 작은 수 찾기
        long min = Math.Min(range[0], range[1]);
        long max = Math.Max(range[0], range[1]);
        // 두 수 사이(두 수 자체는 제외) 수의 개수
        long count = max - min - 1 > 0 ? max - min - 1 : 0;
        List<long> list = new();
        for (long k = min + 1; k < max; k++)
        {
            list.Add(k);
        }
        sw.WriteLine(count);
        sw.WriteLine(string.Join(" ", list));
        sw.Flush();
        sw.Close();
    }
}
