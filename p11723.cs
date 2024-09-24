using System;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections.Generic;

/// <summary>
/// p11723 - 집합, S5
/// 해결 날짜 : 2023/8/31
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        StringBuilder output = new StringBuilder();

        int N = int.Parse(sr.ReadLine());

        List<int> S = new List<int>();
        for(int i = 0; i < N; i++)
        {
            string[] input = sr.ReadLine().Split();
            int num;
            switch (input[0])
            {
                
                case "add":
                    num = int.Parse(input[1]);
                    if (!S.Contains(num)) S.Add(num);
                    break;
                case "remove":
                    num = int.Parse(input[1]);
                    if (S.Contains(num)) S.Remove(num);
                    break;
                case "check":
                    num = int.Parse(input[1]);
                    int result = (S.Contains(num) ? 1 : 0);
                    output.AppendLine(result.ToString());
                    break;
                case "toggle":
                    num = int.Parse(input[1]);
                    if (S.Contains(num)) S.Remove(num);
                    else S.Add(num);
                    break;
                case "all":
                    S = Enumerable.Range(1, 20).ToList();
                    break;
                case "empty":
                    S.Clear();
                    break;
            }
        }
        Console.WriteLine(output.ToString());
        sr.Close();
    }
}
