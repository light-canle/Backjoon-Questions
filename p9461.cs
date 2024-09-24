using System;
using System.IO;
using System.Collections.Generic;

/// <summary>
/// p9461 - 파도반 수열, S3
/// 해결 날짜 : 2023/11/30
/// </summary>

public class Program
{
    public static List<long> list;
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        list = new List<long>();
        long[] temp = { 1, 1, 1, 2, 2 };
        list.AddRange(temp);

        int T = int.Parse(sr.ReadLine()!);

        for (int i = 0; i < T; i++)
        {
            int num = int.Parse(sr.ReadLine()!);

            Console.WriteLine(TriSequence(num));
        }

        sr.Close();
    }

    public static long TriSequence(int num)
    {
        if (list.Count >= num) return list[num - 1];

        int start = list.Count;

        for (int i = start; i < num; i++)
        {
            list.Add(list[i - 1] + list[i - 5]);
        }
        return list[list.Count - 1];
    }
}