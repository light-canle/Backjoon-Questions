using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections.Generic;

/// <summary>
/// p28278 - 스택 2, S4
/// 해결 날짜 : 2024/3/29
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));

        int command = int.Parse(sr.ReadLine()!);
        List<int> stack = new List<int>();
        StringBuilder output = new StringBuilder();

        for (int i = 0; i < command; i++)
        {
            int[] line = sr.ReadLine()!.Split().Select(int.Parse).ToArray();

            switch (line[0])
            {
                case 1:
                    stack.Add(line[1]); break;
                case 2:
                    if (stack.Count == 0)
                    {
                        output.AppendLine("-1");
                        break;
                    }
                    output.AppendLine(stack.Last().ToString());
                    stack.RemoveAt(stack.Count - 1); break;
                case 3:
                    output.AppendLine(stack.Count.ToString()); break;
                case 4:
                    output.AppendLine(((stack.Count == 0) ? 1 : 0).ToString()); break;
                case 5:
                    if (stack.Count == 0)
                    {
                        output.AppendLine("-1");
                        break;
                    }
                    output.AppendLine(stack.Last().ToString()); break;
            }
        }

        Console.WriteLine(output);
        sr.Close();
    }
}
