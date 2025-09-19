#pragma warning disable CS8604, CS8602, CS8600

using System;
using System.Collections.Generic;

// p16228 - GCC의 유산 (G3)
// #스택 #문자열(파싱)
// 2025.9.19 solved

public class Program
{
    public static void Main(string[] args)
    {
        string expression = Console.ReadLine();
        expression = expression.Replace("?", "");
        
        // 1. 후위 표기법으로 바꾼다.
        var postfix = Postfix(expression);

        // 2. 후위 표기법을 이용해서 계산한다.
        Console.Write(Calculate(postfix));
    }

    public static List<string> Postfix(string input)
    {
        Stack<char> oper = new(); // 연산자 스택
        List<string> ret = new(); // 후위 표기식 : 수가 여러 자리여서 구분을 위해 리스트로 정의

        string num = "";
        foreach (char c in input)
        {
            // 우선 순위 : () -> <?, >? -> +, -
            // 넣으려는 연산자가 stack의 top보다 우선 순위가 높아지거나
            // 스택이 비거나 top이 '('가 될 때까지 pop한다.
            if (IsOperator(c))
            {
                if (num != "")
                {
                    ret.Add(num);
                    num = "";
                }
                if (oper.Count == 0)
                {
                    oper.Push(c);
                    continue;
                }
                switch (c)
                {
                    case '+':
                    case '-':
                        while (oper.Count > 0 && !(oper.Peek() == '('))
                        {
                            ret.Add(oper.Pop().ToString());
                        }
                        break;
                    case '>':
                    case '<':
                        while (oper.Count > 0 &&
                            !(oper.Peek() == '+' || oper.Peek() == '-' || oper.Peek() == '('))
                        {
                            ret.Add(oper.Pop().ToString());
                        }
                        break;
                }
                // 연산자를 넣음
                if (c != ')')
                {
                    oper.Push(c);
                }
                // ')'가 나오면 '('가 나올 때까지 연산자를 모두 pop하고, '('도 pop한다.
                else
                {
                    while (!(oper.Peek() == '('))
                    {
                        ret.Add(oper.Pop().ToString());
                    }
                    oper.Pop();
                }
            }
            else
            {
                num += c;
            }
        }

        if (num != "") ret.Add(num);
        // 스택을 비움
        while (oper.Count > 0) ret.Add(oper.Pop().ToString());
        return ret;
    }

    public static bool IsOperator(char c)
    {
        return c == '+' || c == '-' || c == '<' || 
               c == '>' || c == '(' || c == ')';
    }

    public static bool IsOperator(string c)
    {
        return c == "+" || c == "-" || c == "<" ||
               c == ">" || c == "(" || c == ")";
    }

    public static int Calculate(List<string> postfix)
    {
        // 피연산자 스택
        Stack<int> numbers = new();

        foreach (string n in postfix)
        {
            // 연산자이면 스택에서 값 2개를 뺀 뒤 연산자에 대응하는 연산을 수행함
            if (IsOperator(n))
            {
                int a = numbers.Pop();
                int b = numbers.Pop();
                switch (n)
                {
                    case "+":
                        numbers.Push(b + a);
                        break;
                    case "-":
                        numbers.Push(b - a);
                        break;
                    case "<":
                        numbers.Push(Math.Min(b, a));
                        break;
                    case ">":
                        numbers.Push(Math.Max(b, a));
                        break;
                }
            }
            else
            {
                numbers.Push(int.Parse(n));
            }
        }
        return numbers.Pop();
    }
}
