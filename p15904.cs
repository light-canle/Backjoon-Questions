using System;

// p15904 - UCPC는 무엇의 약자일까? (S5)
// #그리디 #문자열
// 2025.4.30 solved

public class Program
{
    public static void Main(string[] args)
    {
        string input = Console.ReadLine();
        int len = input.Length;
        
        int t = 0;
        char[] toCheck = {'U', 'C', 'P', 'C'};
        for (int i = 0; i < len; i++)
        {
            // UCPC에서 현재 찾는 문자가 주어진 문자열에 있으면 다음 문자로 이동
            if (t < 4 && input[i] == toCheck[t])
            {
                t++;
            }
        }
        // U,C,P,C가 모두 있다.
        if (t == 4)
        {
            Console.WriteLine("I love UCPC");
        }
        else
        {
            Console.WriteLine("I hate UCPC");
        }
    }
}
