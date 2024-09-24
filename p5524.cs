using System;
using System.IO;
using System.Text;

/// <summary>
/// p5524 - 입실 관리, B4
/// 해결 날짜 : 2023/11/10
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        int N = int.Parse(sr.ReadLine()!);
        StringBuilder output = new StringBuilder();

        for (int i = 0; i < N; i++)
        {
            string input = sr.ReadLine()!;
            output.AppendLine(input.ToLower());
        }

        Console.WriteLine(output);
        sr.Close();
    }
}