#pragma warning disable CS8604, CS8602, CS8600

using System;
using System.Collections.Generic;

// p4839 - 소진법 (S3)
// #정수론
// 2025.9.17 solved

public class Program
{
    public static void Main(string[] args)
    {
        long[] primes = { 2, 3, 5, 7, 11, 13, 17, 19, 23 };
        // 1, 2, 2*3, 2*3*5, ... 의 소진법의 자릿수를 넣는다.
        List<long> digit = new();
        digit.Add(1);
        for (int i = 0; i < primes.Length; i++)
        {
            digit.Add(digit[^1] * primes[i]);
        }
        // 출력을 위한 형식 : 2, 2*3, 2*3*5, ...를 문자열 형태로 저장
        List<string> name = new();
        name.Add("2");
        for (int i = 1; i < primes.Length; i++)
        {
            name.Add(name[^1] + "*" + primes[i]);
        }
        
        while (true)
        {
            long n = long.Parse(Console.ReadLine());
            if (n == 0)
            {
                break;
            }
            long m = n;
            // 소진법으로 나타낸 자리에 따른 계수를 구함
            long[] coeff = new long[10]; 
            for (int i = 9; i >= 0; i--)
            {
                coeff[i] = m / digit[i];
                m = m % digit[i];
            }
            // 출력용 문자열 제작
            string ret = n.ToString() + " = ";
            for (int i = 0; i < coeff.Length; i++)
            {
                if (coeff[i] != 0)
                {
                    ret += i == 0 ? coeff[i] : coeff[i]+"*"+name[i - 1];
                    ret += " + ";
                }
            }
            // 맨 뒤 " + "를 자름
            ret = ret.Substring(0, ret.Length - 3);
            Console.WriteLine(ret);
        }
    }
}
