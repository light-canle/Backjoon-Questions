using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

/// <summary>
/// p11478 - 서로 다른 부분 문자열의 개수, S3
/// 해결 날짜 : 2024/3/28
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        string str = sr.ReadLine()!;
        int len = str.Length;
        List<string> substrings = new List<string>();

        for (int i = 1; i <= len; i++)
        {
            int index = 0;
            
            while (index + i - 1 < len)
            {
                substrings.Add(str.Substring(index, i));
                index++;
            }
        }

        var ans = substrings.Distinct();

        Console.WriteLine(ans.Count());
        sr.Close();
    }
}