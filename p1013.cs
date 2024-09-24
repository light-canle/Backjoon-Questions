using System;
using System.IO;
using System.Text.RegularExpressions;

/// <summary>
/// p1013 - Contact, G5
/// 해결 날짜 : 2023/9/21
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        Regex regex = new Regex(@"^(100+1+|01)+$");
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));

        int T = int.Parse(sr.ReadLine());
        for (int i = 0; i < T; i++)
        {
            string str = sr.ReadLine();
            Match m = regex.Match(str);
            if (m.Success)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
        sr.Close();
    }
}