using System;
using System.IO;

/// <summary>
/// p1439 - 뒤집기, S5
/// 해결 날짜 : 2023/9/24
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        string str = sr.ReadLine();
        int len = str.Length;

        char currentSegment = ' ';
        int seg0Count = 0;
        int seg1Count = 0;
        for (int i = 0; i < len; i++)
        {
            if (str[i] != currentSegment)
            {
                if (currentSegment == '0') { seg0Count++; }
                else if (currentSegment == '1') { seg1Count++; }
                currentSegment = str[i];
            }
        }
        if (currentSegment == '0') { seg0Count++; }
        else if (currentSegment == '1') { seg1Count++; }

        int result = Math.Min(seg0Count, seg1Count);
        Console.WriteLine(result);
        sr.Close();
    }
}