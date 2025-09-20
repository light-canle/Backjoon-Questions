#pragma warning disable CS8604, CS8602, CS8600

using System;
using System.Collections.Generic;
using System.Numerics;

// p1287 - 할 수 있다. (P4)
// #사칙연산 #스택 #많은 조건 분기 #문자열(파싱) #큰 수 연산
// 2025.9.20 solved

public class Program
{
    public static void Main(string[] args)
    {
        string expression = Console.ReadLine().Trim();

        // 1. 후위 표기법으로 바꾼다.
        List<string> postfix = new();
        if (!Postfix(expression, postfix))
        {
            Console.WriteLine("ROCK");
            return;
        }

        // 2. 후위 표기법을 이용해서 계산한다.
        BigInteger ret = 0;
        if (Calculate(postfix, ref ret))
        {
            Console.WriteLine(ret);
        }
        else
        {
            Console.WriteLine("ROCK");
        }
    }

    /* 
    주어진 식을 후위 표기법으로 바꾸고 그 결과를 ret에 저장한다.
    ret는 빈 배열이어야 한다.
    괄호의 짝이 맞지 않거나 ()가 존재하는 경우에는 false를 반환하고, 그 외에는 true를 반환한다.
    */
    public static bool Postfix(string input, List<string> ret)
    {
        Stack<char> oper = new(); // 연산자 스택

        string num = "";
        char prev = '!';
        foreach (char c in input)
        {
            // 우선 순위 : () -> *, / -> +, -
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
                    // 스택에 아무것도 없는데 ')'를 넣으려고 한다는 것은 '('가 없다는 뜻이다.
                    if (c == ')')
                    {
                        return false;
                    }
                    oper.Push(c);
                    prev = c;
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
                    case '*':
                    case '/':
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
                    if (prev == '(') return false; // '()' 형태가 있는 것은 올바르지 않은 식이다.
                    while (oper.Count > 0 && !(oper.Peek() == '('))
                    {
                        ret.Add(oper.Pop().ToString());
                    }
                    // 짝이 되는 '('가 존재하지 않음
                    if (oper.Count == 0)
                    {
                        return false;
                    }
                    oper.Pop();
                }
            }
            else
            {
                num += c;
            }
            prev = c;
        }

        if (num != "") ret.Add(num);
        // 스택을 비움
        while (oper.Count > 0)
        {
            char op = oper.Pop();
            // 변환된 후위 표기식에는 괄호가 없어야 한다.
            if (op == '(')
            {
                return false;
            }
            ret.Add(op.ToString());
        }
        return true;
    }

    public static bool IsOperator(char c)
    {
        return c == '+' || c == '-' || c == '*' ||
               c == '/' || c == '(' || c == ')';
    }

    public static bool IsOperator(string c)
    {
        return c == "+" || c == "-" || c == "*" ||
               c == "/" || c == "(" || c == ")";
    }

    /*
    후위 표기식을 계산한 뒤 그 답을 ret에 저장한다.
    postfix가 올바르지 않은 형태인 경우 false를, 계산 가능한 형태이면 true를 반환한다.
    */
    public static bool Calculate(List<string> postfix, ref BigInteger ret)
    {
        // 피연산자 스택
        Stack<BigInteger> numbers = new();

        foreach (string n in postfix)
        {
            // 연산자이면 스택에서 값 2개를 뺀 뒤 연산자에 대응하는 연산을 수행함
            if (IsOperator(n))
            {
                // 수가 2개 미만인 경우 연산을 위한 수가 부족하다는 뜻이다. (4+ 같은 형태)
                if (numbers.Count < 2)
                {
                    return false;
                }
                BigInteger a = numbers.Pop();
                BigInteger b = numbers.Pop();
                switch (n)
                {
                    case "+":
                        numbers.Push(b + a);
                        break;
                    case "-":
                        numbers.Push(b - a);
                        break;
                    case "*":
                        numbers.Push(b * a);
                        break;
                    case "/":
                        // 나누는 수가 0이면 올바르지 않은 식이다.
                        if (a == 0)
                        {
                            return false;
                        }
                        else if (b % a != 0)
                        {
                            return false;
                        }
                        numbers.Push(b / a);
                        break;
                }
            }
            else
            {
                numbers.Push(BigInteger.Parse(n));
            }
        }
        // 수가 1개가 아니라는 뜻은 수가 필요 이상으로 많거나 없다는 뜻이다. ('3(2)' => 이런 형태가 오면 계산이 끝나도 수가 2개 이상 남아있다.)
        if (numbers.Count != 1)
        {
            return false;
        }
        ret = numbers.Pop();
        return true;
    }
}
