using System;
using System.IO;
using System.Text;

/// <summary>
/// p18258 - 큐 2, S4
/// 시작 날짜 : 2020/9/4
/// 해결 날짜 : 2023/10/13
/// </summary>
public class Program
{
    public static void Main(string[] args)
    {
        StringBuilder output = new StringBuilder();
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        int N = int.Parse(sr.ReadLine());
        int[] list = new int[N];
        int start = 0, end = 0;
        for (int i = 0; i < N; i++)
        {
            string[] input = sr.ReadLine().Split();
            switch(input[0])
            {
                case "push":
                    list[end] = int.Parse(input[1]);
                    end++;
                    break;
                case "pop":
                    if (start == end)
                    {
                        output.AppendLine("-1");
                        break;
                    }
                    output.AppendLine(list[start].ToString());
                    start++;
                    break;
                case "size":
                    output.AppendLine((end - start).ToString());
                    break;
                case "empty":
                    output.AppendLine((end - start == 0) ? "1" : "0");
                    break;
                case "front":
                    if (start == end)
                    {
                        output.AppendLine("-1");
                        break;
                    }
                    output.AppendLine(list[start].ToString());
                    break;
                case "back":
                    if (start == end)
                    {
                        output.AppendLine("-1");
                        break;
                    }
                    output.AppendLine(list[end - 1].ToString());
                    break;
            }
        }

        Console.WriteLine(output.ToString());
        sr.Close();
    }
}