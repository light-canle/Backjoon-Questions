using System;
using System.Text;
using System.IO;

public class Program
{
    public static long[] arr;
    public static void Main(string[] args)
    {
        arr = new long[] {1, 26, 676, 17576, 456976, 11881376, 308915776, 8031810176};
        StreamReader sr = new (new BufferedStream(Console.OpenStandardInput()));
        StreamWriter sw = new (new BufferedStream(Console.OpenStandardOutput()));
        StringBuilder output = new();
        while (true)
        {
            string cell = sr.ReadLine();
            if (cell == "R0C0")
            {
                break;
            }
            long r = long.Parse(cell.Split('C')[0].Substring(1));
            long c = long.Parse(cell.Split('C')[1]);
            output.AppendLine($"{FindCol(c)}{r}");
        }
        sw.WriteLine(output);
        sw.Flush();
        sr.Close();
        sw.Close();
    }

    public static string FindCol(long c)
    {
        string ans = "";
        int len = 1;
        while (arr[len + 1] / 25 < c + 1)
        {
            len++;
        }

        c -= (arr[len] - 1) / 25;
        for (int i = 0; i < len; i++)
        {
            long digit = arr[len - i - 1];
            long num = c / digit;
            ans += (char)(num + 'A');
            c -= num * digit;
        }
        return ans;
    }
}
