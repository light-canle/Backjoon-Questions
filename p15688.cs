using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// p15688 - 수 정렬하기 5, S5
/// 해결 날짜 : 2023/10/31
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput()));
        StringBuilder output = new StringBuilder();
        int size = int.Parse(sr.ReadLine()!);

        List<int> list = new List<int>();
        for (int i = 0; i < size; i++)
        {
            list.Add(int.Parse(sr.ReadLine()!));
        }

        list.Sort();

        output.AppendLine(string.Join("\n", list));

        sw.WriteLine(output);
        sr.Close();
        sw.Close();
    }
}