using System;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections.Generic;

/// <summary>
/// p10814 - 나이순 정렬, S5
/// 해결 날짜 : 2023/8/24
/// </summary>

public class Information
{
    public string Name { get; set; }
    public int Age { get; set; }
}

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput()));
        StringBuilder output = new StringBuilder();

        int listSize = int.Parse(sr.ReadLine());
        List<Information> list = new List<Information>();
        for (int i = 0; i < listSize; i++)
        {
            string[] info = sr.ReadLine().Split();
            list.Add(new Information { Age = int.Parse(info[0]), Name = info[1] });
        }
        // C#의 orderby는 안정 정렬이다.
        list = list.OrderBy(x => x.Age).ToList();

        foreach (Information info in list)
        {
            output.AppendLine($"{info.Age} {info.Name}");
        }
        sw.WriteLine(output.ToString());

        sw.Flush();
        sw.Close();
        sr.Close();
    }
}
