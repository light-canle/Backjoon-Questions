using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        string input = Console.ReadLine();
        int len = input.Length;
        Stack<int> stack = new Stack<int>();
        for (int i = 0; i < len; i++)
        {
            if (IsOperator(input[i]))
            {
                Evaluate(stack, input[i]);
            }
            else
            {
                stack.Push(input[i] - '0');
            }
        }
        Console.WriteLine(stack.Pop());
    }

    public static bool IsOperator(char c)
    {
        return c == '+' || c == '-' || c == '*' || c == '/';
    }

    public static void Evaluate(Stack<int> stack, char oper)
    {
        int a = stack.Pop();
        int b = stack.Pop();

        switch (oper)
        {
        case '+':
            stack.Push(b + a);
            break;
        case '-':
            stack.Push(b - a);
            break;
        case '*':
            stack.Push(b * a);
            break;
        case '/':
            stack.Push(b / a);
            break;
        }
    }
}
