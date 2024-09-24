using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// p2167 - 2차원 배열의 합, S5
/// 해결 날짜 : 2023/10/27
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        StringBuilder output = new StringBuilder();

        string[] size = sr.ReadLine()!.Split();
        // 2차원 배열의 크기
        int N = int.Parse(size[0]);
        int M = int.Parse(size[1]);

        List<List<int>> ints = new List<List<int>>();
        // 2차원 배열 입력
        for (int i = 0; i < N; i++)
        {
            List<int> list = sr.ReadLine()!.Split().Select(int.Parse).ToList();
            ints.Add(list);
        }

        int count = int.Parse(sr.ReadLine()!);

        
        for (int i = 0; i < count; i++)
        {
            // 2차원 배열의 부분합을 구함 - O(n^2)
            long sum = 0;
            int[] part = sr.ReadLine()!.Split().Select(int.Parse).ToArray();
            (int y1, int x1, int y2, int x2) = (part[0], part[1], part[2], part[3]);

            for (int y = y1; y <= y2; y++) 
            {
                for (int x = x1; x <= x2; x++)
                {
                    sum += ints[y - 1][x - 1];
                }
            }
            output.AppendLine(sum.ToString());
        }
        Console.WriteLine(output);
        sr.Close();
    }
}