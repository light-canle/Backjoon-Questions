using System;
using System.IO;

/// <summary>
/// p4504 - 배수 찾기, B3
/// 해결 날짜 : 2023/10/24
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        int N = int.Parse(sr.ReadLine()!);

        while (true)
        {
            int cur = int.Parse(sr.ReadLine()!);
            if (cur == 0) break;

            if (cur % N == 0)
            {
                Console.WriteLine($"{cur} is a multiple of {N}.");
            }
            else
            {
                Console.WriteLine($"{cur} is NOT a multiple of {N}.");
            }
        }

        sr.Close();
    }
}