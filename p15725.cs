using System;
using System.Linq;

// p15725 - 다항함수의 미분 (S4)
// #문자열 #파싱
// 2025.2.28 solved

public class Program
{
    public static void Main(string[] args)
    {
        string equation = Console.ReadLine();
        // x가 있는가
        if (equation.Contains("x"))
        {
            // x의 계수가 1인가
            if (equation.IndexOf("x") == 0)
            {
                Console.WriteLine(1);
            }
            else
            {
                // 계수를 가지고 옴
                // 계수가 -1이어서 ret가 '-'일 경우 -1로 출력
                string ret = equation.Split("x").First();
                Console.WriteLine(ret != "-" ? ret : -1);
            }
        }
        // 상수항의 미분은 0
        else
        {
            Console.WriteLine("0");
        }
    }
}
