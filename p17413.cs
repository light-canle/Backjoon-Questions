using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput()));

        string s = sr.ReadLine();
        Stack<char> stack = new();
        StringBuilder ret = new();
        int len = s.Length;
        bool tagMode = false;
        for (int i = 0; i < len; i++)
        {
            char c = s[i];
            if (c == '<')
            {
                tagMode = true;
                while (stack.Count > 0)
                {
                    ret.Append(stack.Pop());
                }
                ret.Append(c);
            }
            else if (c == '>')
            {
                tagMode = false;
                ret.Append(c);
            }
            else if (c == ' ')
            {
                if (!tagMode)
                {
                    while (stack.Count > 0)
                    {
                        ret.Append(stack.Pop());
                    }
                }
                ret.Append(c);
            }
            else
            {
                if (!tagMode)
                {
                    stack.Push(c);
                }
                else
                {
                    ret.Append(c);
                }
            }
        }
        
        while (stack.Count > 0)
        {
            ret.Append(stack.Pop());
        }


        Console.WriteLine(ret);
        sw.Flush();
        sr.Close();
        sw.Close();
    }
}
