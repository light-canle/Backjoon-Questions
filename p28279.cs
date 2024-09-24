using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections.Generic;

/// <summary>
/// p28279 - 덱 2, S4
/// 해결 날짜 : 2024/3/29
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));

        int command = int.Parse(sr.ReadLine()!);
        int[] deque = new int[2 * command + 1];
        int low = command + 1, high = command;
        StringBuilder output = new StringBuilder();

        for (int i = 0; i < command; i++)
        {
            int[] line = sr.ReadLine()!.Split().Select(int.Parse).ToArray();

            switch (line[0])
            {
                case 1:
                    deque[--low] = line[1]; break;
                case 2:
                    deque[++high] = line[1]; break;
                case 3:
                    if (low > high)
                    {
                        output.AppendLine("-1");
                        break;
                    }
                    output.AppendLine(deque[low].ToString());
                    low++; break;
                case 4:
                    if (low > high)
                    {
                        output.AppendLine("-1");
                        break;
                    }
                    output.AppendLine(deque[high].ToString());
                    high--; break;
                case 5:
                    output.AppendLine((high - low + 1).ToString()); break;
                case 6:
                    output.AppendLine(((low > high) ? 1 : 0).ToString()); break;
                case 7:
                    if (low > high)
                    {
                        output.AppendLine("-1");
                        break;
                    }
                    output.AppendLine(deque[low].ToString()); break;
                case 8:
                    if (low > high)
                    {
                        output.AppendLine("-1");
                        break;
                    }
                    output.AppendLine(deque[high].ToString()); break;
            }
        }

        Console.WriteLine(output);
        sr.Close();
    }
}
