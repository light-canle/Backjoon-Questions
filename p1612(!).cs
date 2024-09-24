using System;
using System.Numerics;

/// <summary>
/// p1612 - 가지고 노는 1, G5
/// 시작 날짜 : 2023/9/3
/// </summary>

/*
시간 초과로 인한 미해결 문제
*/

public class Program
{
    public static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());

        if (N % 2 == 0 || N % 5 == 0)
        {
            Console.WriteLine("-1");
        }
        else
        {
            int digit = 1;
            while (!IsMultipler(digit, N)) digit++;
            Console.WriteLine(digit);
        }
    }

    public static bool IsMultipler(int digit, int n)
    {
        BigInteger bigNum = BigInteger.Parse(new String('1', digit));
        return bigNum % n == 0;
    }
}
