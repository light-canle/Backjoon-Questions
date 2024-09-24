using System;
using System.Linq;
using System.IO;
using System.Text;

/// <summary>
/// p11880 - 개미, B2
/// 해결 날짜 : 2023/11/12
/// </summary>

// 가장 긴변 ^ 2 + 다른 두 변 길이 합 ^ 2을 구하는 문제

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        StringBuilder output = new StringBuilder();
        int num = int.Parse(sr.ReadLine()!);

        for (int i = 0; i < num; i++)
        {
            long[] input = sr.ReadLine()
                .Split()
                .Select(long.Parse)
                .OrderBy(x => x)
                .ToArray();

            (long a, long b, long c) = (input[0], input[1], input[2]);
            output.AppendLine((c * c + (long)Math.Pow(a + b, 2)).ToString());
            
        }
        Console.WriteLine(output);
        sr.Close();
    }
}