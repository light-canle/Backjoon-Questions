using System;
using System.Linq;
using System.IO;
using System.Text;

/// <summary>
/// p1934 - 최소공배수, B1
/// 해결 날짜 : 2023/11/16 (solved.ac 기준 11/15)
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        StringBuilder output = new StringBuilder();
        int numCase = int.Parse(sr.ReadLine()!);
        
        for (int i = 0; i < numCase; i++)
        {
            int[] n = sr.ReadLine()!.Split().Select(int.Parse).ToArray();
            output.AppendLine(LCM(n[0], n[1]).ToString());
        }
        
        Console.WriteLine(output);
        sr.Close();
    }

    public static long GCD(int n1, int n2)
    {
        int min = (n1 < n2) ? n1 : n2;
        int max = (n1 == min) ? n2 : n1;

        if (min == 0) return max;
        else
        {
            return GCD(max % min, min);
        }
    }

    public static long LCM(int n1, int n2)
    {
        return (long)n1 * n2 / GCD(n1, n2);
    }
}