using System;
using System.Numerics;

// p4375 - 1 (S3)
// #정수론 #완전 탐색
// 2025.2.4 solved

public class Program
{
    public static void Main(string[] args)
    {
        while (true)
        {
            string line = Console.ReadLine();
            if (line == "" || line == null)
            {
                break;
            }
            BigInteger n = BigInteger.Parse(line);

            int digit = 0; // 현재 자릿수(1로만 이루어진 수의 자릿수)
            BigInteger cur = 0; // 현재 수를 n으로 나눈 나머지
            BigInteger toAdd = 1; // 더해갈 자릿수

            // 1, 10, 100, ... 씩 더해가면서
            // n으로 나누었을 때 나머지가 0이 되는 자릿수를 찾는다.
            // (a+b) % r = ((a % r) + (b % r)) % r 임을 이용한다.
            do 
            {
                cur += toAdd;
                cur %= n;
                toAdd *= 10;
                digit++;
            }
            while (cur > 0); // 나머지가 0이 되면 종료
            Console.WriteLine(digit);
        }
    }
}
