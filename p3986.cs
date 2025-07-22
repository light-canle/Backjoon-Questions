#pragma warning disable CS8604, CS8602, CS8600

using System;
using System.IO;
using System.Collections.Generic;

// p3986 - 좋은 단어 (S4)
// #스택
// 2025.7.22 solved

/*
좋은 단어의 조건을 만족하는 지 보려면
각 문자들을 스택에 아래 규칙에 따라 넣는다.
1. 스택이 비었거나 스택의 맨 위쪽 문자가 넣으려는 문자와 다르면 그 문자를 스택에 넣는다.
2. 스택의 맨 위쪽 문자가 넣으려는 문자와 같으면, 스택의 맨 위 문자를 꺼내고, 넣으려는 문자는 넣지 않는다.
모든 문자에 대해 규칙을 수행한 후 스택이 비었으면 좋은 단어가 된다.
*/
public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        int n = int.Parse(sr.ReadLine());

        int goodWords = 0;
        for (int i = 0; i < n; i++)
        {
            string s = sr.ReadLine();
            int len = s.Length;
            Stack<char> stack = new Stack<char>();

            for (int j = 0; j < len; j++)
            {
                if (stack.Count == 0)
                {
                    stack.Push(s[j]);
                }
                else
                {
                    if (stack.Peek() != s[j])
                    {
                        stack.Push(s[j]);
                    }
                    else
                    {
                        stack.Pop();
                    }
                }
            }

            goodWords += stack.Count == 0 ? 1 : 0;
        }
        Console.WriteLine(goodWords);
        sr.Close();
    }
}
