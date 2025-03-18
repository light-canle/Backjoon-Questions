using System;
using System.Collections.Generic;

// p9047 - 6174 (S5)
// #사칙연산 #문자열 #정렬
// 2025.3.19 solved

public class Program
{
    public static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine());

        for (int i = 0; i < t; i++)
        {
            int n = int.Parse(Console.ReadLine());
            int step = 0;
            while (n != 6174)
            {
                n = Oper(n);
                step++;
            }
            Console.WriteLine(step);
        }
    }

    public static int Oper(int n)
    {
        string s = n.ToString();
        // 길이가 4보다 짧은 경우 앞에 0을 넣어 자릿수를 맞춘다.
        if (s.Length < 4)
        {
            s = new string('0', 4 - s.Length) + s;
        }
        List<char> digit = new();
        foreach (char c in s)
        {
            digit.Add(c);
        }
        // 현재 가진 자릿수로 만들 수 있는 최소 / 최대의 차이를 구함
        digit.Sort();
        string min = string.Join("", digit);
        digit.Reverse();
        string max = string.Join("", digit);
        return int.Parse(max) - int.Parse(min);
    }
}
