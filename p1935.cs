using System;
using System.Collections.Generic;

// p1935 - 후위 표기식2 (S3)
// #스택
// 2025.5.15 solved

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        string expr = Console.ReadLine();
        int len = expr.Length;
        double[] arr = new double[n];
        for (int i = 0; i < n; i++)
        {
            arr[i] = double.Parse(Console.ReadLine());
        }
        Stack<double> stack = new();
        for (int i = 0; i < len; i++)
        {
            switch (expr[i])
            {
            case '+':
            case '-':
            case '*':
            case '/':
                double a = stack.Pop();
                double b = stack.Pop();
                switch (expr[i])
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
                break;
            default:
                stack.Push(arr[expr[i] - 'A']);
                break;
            }
        }
        Console.WriteLine($"{stack.Pop():F2}");
    }
}
