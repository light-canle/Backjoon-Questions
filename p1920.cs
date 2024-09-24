using System;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections.Generic;

/// <summary>
/// p1920 - 수 찾기, S4
/// 해결 날짜 : 2023/8/24
/// </summary>
/// 
public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput()));
        StringBuilder output = new StringBuilder();

        int listSize = int.Parse(sr.ReadLine());
        List<int> list = sr.ReadLine().Split().Select(x => int.Parse(x)).ToList();
        list.Sort();

        int numberCount = int.Parse(sr.ReadLine());
        List<int> candidate = sr.ReadLine().Split().Select(x => int.Parse(x)).ToList();

        for (int i = 0; i < numberCount; i++)
        {
            if (list.BinarySearch(candidate[i]) >= 0)
            {
                output.Append('1' +"\n");
            }
            else 
            {
                output.Append('0' + "\n");
            }
        }
        sw.WriteLine(output.ToString());

        sw.Flush();
        sw.Close();
        sr.Close();
    }
}
