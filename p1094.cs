using System;

/// <summary>
/// p1094 - 막대기, S5
/// 해결 날짜 : 2023/9/1
/// </summary>

/*
64 이하의 지연수를 몇 개의 2의 거듭제곱수(1, 2, 4, 8, ...)의
합으로 나타낼 수 있는지를 구하는 문제
*/

public class Program
{
    public static void Main(string[] args)
    {
        int X = int.Parse(Console.ReadLine());

        int count = 0;
        int barLength = 64;

        while (barLength >= 1)
        {
            if ((barLength & X) != 0) count++;
            barLength >>= 1;
        }
        barLength = 1;
        Console.WriteLine(count);
    }
}
