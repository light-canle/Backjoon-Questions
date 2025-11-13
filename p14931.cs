#pragma warning disable CS8604, CS8602

using System;

// p14931 - 물수제비 (SUJEBI)
// #완전 탐색
// 2025.11.13 solved

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        int n = int.Parse(sr.ReadLine());
        int[] value = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        long maxValue = 0;
        int maxValueInterval = 0;
        // 가치를 최대로 하는 간격을 찾음
        for (int i = 1; i <= n; i++)
        {
            long curValue = 0;
            for (int j = i - 1; j < n; j += i)
            {
                curValue += value[j];
            }
            if (maxValue < curValue)
            {
                maxValue = curValue;
                maxValueInterval = i;
            }
        }
        Console.WriteLine($"{maxValueInterval} {maxValue}");
        sr.Close();
    }
}
