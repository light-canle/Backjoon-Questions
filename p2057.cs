using System;
using System.Numerics;

/// <summary>
/// p2057 - 팩토리얼 분해, S5
/// 해결 날짜 : 2023/11/28
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        BigInteger num = BigInteger.Parse(Console.ReadLine()!);
        // 0은 0! = 1이므로 음이 아닌 정수의 팩토리얼의 합으로 나타낼 수 없다.
        if (num == 0) 
        {
            Console.WriteLine("NO");
            return;
        } 

        for (int i = 20; i >= 0; i--) 
        {
            BigInteger cur = Fact(i);
            if (num >= cur)
            {
                num -= cur;
            }
        }

        Console.WriteLine((num == 0) ? "YES" : "NO");
    }

    public static BigInteger Fact(int n)
    {
        BigInteger result = BigInteger.One;
        for (int i = 2; i <= n; i++)
        {
            result *= i;
        }
        return result;
    }
}