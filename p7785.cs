using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections.Generic;

/// <summary>
/// p7785 - 회사에 있는 사람, S5
/// 해결 날짜 : 2024/3/28
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        int T = int.Parse(sr.ReadLine()!);
        
        Dictionary<string, int> member = new Dictionary<string, int>();

        for (int i = 0; i < T; i++)
        {
            string[] input = sr.ReadLine()!.Split();

            if (input[1] == "enter")
            {
                member[input[0]] = 1;
            }
            else
            {
                member[input[0]] = 0;
            }
        }

        var ordered = member.OrderBy(x => x.Key).Reverse();
        StringBuilder output = new StringBuilder();

        foreach (var s in ordered)
        {
            if (s.Value == 1)
                output.AppendLine(s.Key);
        }

        Console.WriteLine(output);
        sr.Close();
    }
}
