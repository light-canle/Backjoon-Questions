using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// 유틸컵 Chapter2 - K번(5), K-Words Problem
/// p30037 - G3
/// 해결 날짜 : 2023/9/17
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        StringBuilder output = new StringBuilder();
        int N = int.Parse(sr.ReadLine());

        List<List<string>> list = new List<List<string>>();
        
        for (int i = 0; i < N; i++)
        {
            list.Add(sr.ReadLine().Split().ToList());
        }

        
        for (int i = 0; i < list.Count; i++) 
        {
            // 2번 규칙 우선 적용
            for (int j = 1; j < list[i].Count; j++)
            {
                if (list[i][j] == "of" 
                    && j != list[i].Count - 1 && 
                    (list[i][j + 1] == "Korea" || 
                    list[i][j + 1].Substring(0, list[i][j + 1].Length - 1) == "Korea"))
                {
                    if (!PunMark(list[i][j - 1]))
                    {
                        list[i][j - 1] = list[i][j - 1].Substring(0, 1).ToUpper() 
                            + list[i][j - 1].Substring(1);
                        string result = "K-" + list[i][j - 1] +
                            (PunMark(list[i][j + 1].Substring(list[i][j + 1].Length - 1)) ? list[i][j + 1].Substring(list[i][j + 1].Length - 1) : "");
                        list[i].RemoveAt(j - 1);
                        list[i].RemoveAt(j - 1);
                        list[i].RemoveAt(j - 1);
                        list[i].Insert(j - 1, result);
                        j--;
                    }
                }
            }

            // 1번 규칙 적용
            for (int j = list[i].Count - 1; j >= 0; j--)
            {
                if (list[i][j] == "Korea" &&
                    j != list[i].Count - 1)
                {
                    list[i][j + 1] = list[i][j + 1].Substring(0, 1).ToUpper()
                        + list[i][j + 1].Substring(1);
                    string result = "K-" + list[i][j + 1];
                    list[i].RemoveAt(j);
                    list[i].RemoveAt(j);
                    list[i].Insert(j, result);
                }
            }
        }

        foreach (var l in list)
        {
            output.AppendLine(string.Join(" ", l));
        }
        Console.WriteLine(output);
        sr.Close();
    }

    public static bool PunMark(string str)
    {
        return str.Contains('!') || str.Contains('?') ||
            str.Contains(',') || str.Contains('.');
    }
}