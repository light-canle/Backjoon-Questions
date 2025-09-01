using System;
using System.Text;
using System.IO;
using System.Collections.Generic;

// p6504 - 킬로미터를 마일로 (S5)
// #수학(진법 변환, 피보나치 수열)
// 2025.9.1 solved

public class Program
{
    public static void Main(string[] args)
    {
        // 피보나치 수열 사전 조성
        List<int> fibonacci = new();
        fibonacci.Add(1);
        fibonacci.Add(2);
        int k = 3;
        while (k <= 25000) // 수의 제한 범위가 3~24999이다.
        {
            fibonacci.Add(k);
            k = fibonacci[^1] + fibonacci[^2];
        }
        int len = fibonacci.Count;

        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput()));
        StringBuilder output = new();
        int t = int.Parse(Console.ReadLine());

        for (int i = 0; i < t; i++)
        {
            int n = int.Parse(Console.ReadLine());

            // 피보나치 진법으로 나타낸다.
            /*
            피보나치 진법은 각 자리의 값이 1, 2, 3, 5, 8, 13, ... 이런식으로 피보나치 수열의 수이고,
            계수는 이진법 처럼 0, 1로 이루어진 이 문제에서 만든 특수한 진법이다.
            예를 들어 7 = 5 + 2이므로, 7 = (1, 0, 1, 0)으로 나타낼 수 있고,
            22 = 21 + 1이므로, 22 = (1, 0, 0, 0, 0, 0, 1)로 나타낼 수 있다.
            */
            bool[] contain = new bool[len]; // true이면 계수가 1, 아니면 0이다.
            int idx = len - 1;
            while (n > 0)
            {
                if (n >= fibonacci[idx])
                {
                    n -= fibonacci[idx];
                    contain[idx] = true;
                }
                idx--;
            }

            // 인덱스를 왼쪽으로 1칸씩 옮긴다. 마지막 인덱스는 false로 둔다.
            for (int j = 1; j < len; j++)
            {
                contain[j - 1] = contain[j];
            }
            contain[len - 1] = false;

            // 변환을 적용시킨 후의 수를 구한다.
            int ret = 0;
            for (int j = 0; j < len; j++)
            {
                ret += contain[j] ? fibonacci[j] : 0;
            }
            output.AppendLine(ret.ToString());
        }
        sw.WriteLine(output);
        sw.Flush();
        sr.Close();
        sw.Close();
    }
}
