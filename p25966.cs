#pragma warning disable CS8604, CS8602, CS8600

using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Collections.Generic;

// p25966 - 배찬우는 배열을 좋아해 (S5)
// #구현
// 2025.10.9 solved

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput()));
        StringBuilder output = new();

        int[] size = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        int n = size[0], m = size[1], q = size[2];
        List<List<int>> list = new();
        for (int i = 0; i < n; i++)
        {
            list.Add(sr.ReadLine().Split().Select(int.Parse).ToList());
        }

        for (int i = 0; i < q; i++)
        {
            int[] query = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            switch (query[0])
            {
                case 0:
                    list[query[1]][query[2]] = query[3];
                    break;
                case 1:
                    var temp = list[query[1]];
                    list[query[1]] = list[query[2]];
                    list[query[2]] = temp;
                    break;
            }
        }

        for (int i = 0; i < n; i++)
        {
            output.AppendLine(string.Join(" ", list[i]));
        }
        sw.WriteLine(output);
        sw.Flush();
        sr.Close();
        sw.Close();
    }
}
