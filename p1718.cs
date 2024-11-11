using System;
using System.Text;
using System.IO;

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new (new BufferedStream(Console.OpenStandardInput()));
        StreamWriter sw = new (new BufferedStream(Console.OpenStandardOutput()));
        
        string s = sr.ReadLine();
        string code = sr.ReadLine();
        int len = s.Length;
        int clen = code.Length;

        string ret = "";
        for (int i = 0; i < len; i++)
        {
            if (s[i] == ' ')
            {
                ret += " ";
                continue;
            }
            char c = (char)(s[i] - Order(code[i % clen]));

            while (c < 'a') c = (char)(c + 26);

            ret += c;
        }

        sw.WriteLine(ret);
        sw.Flush();
        sr.Close();
        sw.Close();
    }

    public static int Order(char c)
    {
        return (int)c - (int)'a' + 1;
    }
}
