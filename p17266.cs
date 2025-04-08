using System;
using System.IO;

// p17266 - 어두운 굴다리 (S4)
// #사칙연산
// 2025.4.8 solved

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        int n = int.Parse(sr.ReadLine());
        int m = int.Parse(sr.ReadLine());
        int[] pos = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        int maxGap = pos[0];
        maxGap = Math.Max(maxGap, n - pos[m - 1]);
        for (int i = 0; i < m - 1; i++)
        {
            int half = pos[i + 1] - pos[i];
            half = half % 2 == 1 ? half + 1 : half;
            half /= 2;
            maxGap = Math.Max(maxGap, half);
        }
        Console.WriteLine(maxGap);
        sr.Close();
    }
}
