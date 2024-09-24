using System;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections.Generic;

/// <summary>
/// p10866 - 덱, S4
/// 해결 날짜 : 2023/8/22
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        List<int> deque = new List<int>();
        List<string> input = new List<string>();

        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        StringBuilder str = new StringBuilder("");

        int N = int.Parse(sr.ReadLine());
        for (int i = 0; i < N; i++)
        {
            input.Clear();
            input = sr.ReadLine().ToLower().Split(' ').ToList();

            switch (input[0])
            {
                case "push_front":
                    deque.Insert(0, int.Parse(input[1]));
                    break;
                case "push_back":
                    deque.Add(int.Parse(input[1]));
                    break;
                case "pop_front":
                    if (deque.Count == 0)
                    {
                        str.AppendLine("-1");
                        break;
                    }
                    str.AppendLine(deque[0].ToString());
                    deque.RemoveAt(0);
                    break;
                case "pop_back":
                    if (deque.Count == 0)
                    {
                        str.AppendLine("-1");
                        break;
                    }
                    str.AppendLine(deque[deque.Count - 1].ToString());
                    deque.RemoveAt(deque.Count - 1);
                    break;
                case "size":
                    str.AppendLine(deque.Count().ToString());
                    break;
                case "empty":
                    str.AppendLine((deque.Count() == 0) ? "1" : "0");
                    break;
                case "front":
                    str.AppendLine((deque.Count() == 0) ? "-1" : deque[0].ToString());
                    break;
                case "back":
                    str.AppendLine((deque.Count() == 0) ? "-1" : deque[deque.Count() - 1].ToString());
                    break;
                default:
                    throw new ArgumentException();
            }
        }

        Console.WriteLine(str);
    }
}
