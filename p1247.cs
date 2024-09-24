using System;
using System.Numerics;

/// <summary>
/// p1247 - 부호, B3
/// 해결 날짜 : 2023/9/20
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        for (int i = 0; i < 3; i++)
        {
            int N = int.Parse(Console.ReadLine());
            BigInteger sum = 0;
            for (int j = 0; j < N; j++)
            {
                sum += long.Parse(Console.ReadLine());
            }
            if (sum == 0)
                Console.WriteLine(0);
            else if (sum > 0)
                Console.WriteLine('+');
            else
                Console.WriteLine('-');
        }
    }

}