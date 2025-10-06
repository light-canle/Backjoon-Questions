#pragma warning disable CS8604, CS8602, CS8600

using System;
using System.Collections.Generic;

// p14888 - 연산자 끼워넣기 (S1)
// #백트래킹 #완전 탐색
// 2025.10.6 solved

public class Program
{
    public static SortedList<int, int> calculationResult;
    public static bool[] visited;
    public static char[] result;
    public static int[] nums;
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        nums = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        int[] operCounts = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        // 주어진 연산자의 개수를 토대로 연산자 배열을 만든다.
        // 1 2 1 2 -> + - - * / /
        char[] opers = new char[n - 1];
        int idx = 0;
        for (int i = 0; i < 4; i++)
        {
            while (operCounts[i] > 0)
            {
                char cur = '0';
                switch(i)
                {
                case 0:
                    cur = '+'; break;
                case 1:
                    cur = '-'; break;
                case 2:
                    cur = '*'; break;
                case 3:
                    cur = '/'; break;
                }
                opers[idx++] = cur;
                operCounts[i]--;
            }
        }
        calculationResult = new();
        visited = new bool[n - 1];
        result = new char[n - 1];

        GenerateAll(n - 1, 0, opers);

        Console.WriteLine(calculationResult.Keys[^1]);
        Console.WriteLine(calculationResult.Keys[0]);
    }
    // 백트래킹을 하며 나올 수 있는 모든 연산자 순서를 구하고 그 식을 계산한다.
    public static void GenerateAll(int n, int depth, char[] opers)
    {
        if (n == depth)
        {
            int ret = Calculate(n);
            if (!calculationResult.ContainsKey(ret))
            {
                calculationResult.Add(ret, ret);
            }
            return;
        }

        for (int i = 0; i < n; i++)
        {
            if (!visited[i])
            {
                visited[i] = true;
                result[depth] = opers[i];
                GenerateAll(n, depth + 1, opers);
                visited[i] = false;
            }
        }
    }

    // nums, result를 이용해서 주어진 식을 앞에서 부터 계산한다.
    public static int Calculate(int calculateCount)
    {
        int ret = PartCalculate(nums[0], result[0], nums[1]);
        for (int i = 1; i < calculateCount; i++)
        {
            ret = PartCalculate(ret, result[i], nums[i + 1]);
        }
        return ret;
    }
    // a oper b를 수행한다.
    public static int PartCalculate(int a, char oper, int b)
    {
        switch (oper)
        {
        case '+':
            return a + b;
        case '-':
            return a - b;
        case '*':
            return a * b;
        case '/':
            return a / b;
        }
        return 0;
    }
}
