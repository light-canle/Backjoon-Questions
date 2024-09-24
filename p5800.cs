using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// p5800 - 성적 통계, S5
/// 해결 날짜 : 2023/10/14
/// 100번째 실버 문제
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        StringBuilder output = new StringBuilder();
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        int N = int.Parse(sr.ReadLine());
        int max, min, max_gap;
        for (int i = 0; i < N; i++)
        {
            var input = sr.ReadLine().Split().Select(int.Parse).ToList();
            int len = input[0];
            var sorted = input.GetRange(1, len).OrderBy(x => x).ToArray();
            max = sorted[len - 1];
            min = sorted[0];
            max_gap = 0;
            for (int j = 0; j < len - 1; j++)
            {
                int current_gap = sorted[j + 1] - sorted[j];
                if (current_gap > max_gap) max_gap = current_gap;
            }
            output.AppendLine($"Class {i+1}");
            output.AppendLine($"Max {max}, Min {min}, Largest gap {max_gap}");
        }

        Console.WriteLine(output.ToString());
        sr.Close();
    }
}