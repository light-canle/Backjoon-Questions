using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

/// <summary>
/// p12789 - 도키도키 간식드리미, S3
/// 해결 날짜 : 2024/3/29
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));

        int N = int.Parse(sr.ReadLine()!); 
        List<int> line = sr.ReadLine()!.Split().Select(int.Parse).ToList();
        Stack<int> subLine = new Stack<int>();

        int next = 1;
        while (next <= N)
        {
            // 대기줄에 들어가야 하는 사람이 바로 앞에 있음
            if (line.Count > 0 && line[0] == next)
            {
                next++;
                line.RemoveAt(0);
            }
            // 옆 공간의 제일 앞에 들어가야 하는 사람이 있음
            else if (subLine.Count > 0 && subLine.First() == next)
            {
                next++;
                subLine.Pop();
            }
            // 기본 대기 줄에 더 이상 사람이 없음
            else if (line.Count == 0)
            {
                Console.WriteLine("Sad");
                return;
            }
            // 그외에는 대기 줄 앞 사람을 옆 공간에 세움
            else
            {
                subLine.Push(line[0]);
                line.RemoveAt(0);
            }
        }

        Console.WriteLine("Nice");
        sr.Close();
    }
}
