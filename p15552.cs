using System;
using System.Linq;
using System.Text;
using System.IO;

/// <summary>
/// p15552 - 빠른 A+B, B4
/// 해결 날짜 : 2023/8/26
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput()));
        StringBuilder output = new StringBuilder();

        int caseNum = int.Parse(sr.ReadLine());

        for (int i = 0; i < caseNum; i++)
        {
            int[] input = sr.ReadLine().Split().Select(x => int.Parse(x)).ToArray();

            output.AppendLine((input[0] + input[1]).ToString());
        }

        sw.WriteLine(output.ToString());

        sw.Flush();

        sr.Close();
        sw.Close();
    }
}
