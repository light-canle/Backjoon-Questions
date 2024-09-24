using System;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections.Generic;

/// <summary>
/// p17219 - 비밀번호 찾기, S4
/// 해결 날짜 : 2023/8/30
/// </summary>

/*
Map(C#에서는 Dictionary)를 이용한 문제
*/

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        StringBuilder output = new StringBuilder();

        int[] input = sr.ReadLine().Split().Select(x => int.Parse(x)).ToArray();

        int allSite = input[0];
        int considerSite = input[1];

        Dictionary<string, string> sitePassword = new Dictionary<string, string>();
        for (int i = 0; i < allSite; i++)
        {
            string[] site_pass = sr.ReadLine().Split();
            sitePassword.Add(site_pass[0], site_pass[1]);
        }
        List<string> siteToFind = new List<string>();
        for (int i = 0; i < considerSite; i++)
        {
            string site_name = sr.ReadLine();
            siteToFind.Add(site_name);
        }

        foreach (string site_name in siteToFind)
        {
            output.AppendLine(sitePassword[site_name]);
        }

        Console.WriteLine(output.ToString());

        sr.Close();
    }
}
