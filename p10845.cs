using System;
using System.Text;
using System.Linq;
using System.IO;
using System.Collections.Generic;

// p10845 - 큐, S4
// 해결 날짜 : 2023/8/19

public class Program
{
    public static void Main(string[] args)
    {
        List<int> queue = new List<int>();
        List<string> input = new List<string>();

        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        StringBuilder str = new StringBuilder("");

        int N = int.Parse(sr.ReadLine());
        for (int i = 0; i < N; i++)
        {
            input.Clear();
            input = sr.ReadLine().ToLower().Split(' ').ToList();

            switch(input[0])
            {
                case "push":
                    queue.Add(int.Parse(input[1]));
                    break;
                case "pop":
                    if (queue.Count == 0)
                    {
                        str.AppendLine("-1");
                        break;
                    }
                    str.AppendLine(queue[0].ToString());
                    queue.RemoveAt(0);
                    break;
                case "size":
                    str.AppendLine(queue.Count().ToString());
                    break;
                case "empty":
                    str.AppendLine((queue.Count() == 0) ? "1" : "0");
                    break;
                case "front":
                    str.AppendLine((queue.Count() == 0) ? "-1" : queue[0].ToString());
                    break;
                case "back":
                    str.AppendLine((queue.Count() == 0) ? "-1": queue[queue.Count() - 1].ToString());
                    break;
            }
        }

        Console.WriteLine(str);
    }
}
