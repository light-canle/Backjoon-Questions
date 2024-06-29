using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        string s = Console.ReadLine();

        Stack<char> stack = new Stack<char>();

        int maxScore = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '(' || s[i] == '{' || s[i] == '[')
            {
                stack.Push(s[i]);
            }
            else if (s[i] == ')' || s[i] == '}' || s[i] == ']')
            {
                stack.Pop();
            }
            else
            {
                var list = stack.ToList();
                int cur = 0;
                for (int j = 0; j < list.Count; j++)
                {
                    if (list[j] == '(')
                    {
                        cur++;
                    }
                    else if (list[j] == '{')
                    {
                        cur += 2;
                    }
                    else if (list[j] == '[')
                    {
                        cur += 3;
                    }
                }
                if (cur > maxScore)
                {
                    maxScore = cur;
                }
            }
        }
        Console.WriteLine(maxScore);
    }
}
