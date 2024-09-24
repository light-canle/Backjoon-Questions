using System;

/// <summary>
/// p1476 - 날짜 계산, S5
/// 해결 날짜 : 2023/9/4
/// </summary>

/*
이 문제의 경우에는 수의 범위가 크지 않아 반복문으로 해결 할 수 있었다.
*/

public class Program
{
    public static void Main(string[] args)
    {
        int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
        (int E, int S, int M) = (input[0], input[1], input[2]);

        int year = 1;
        while (true)
        {
            int value_E = (year % 15 == 0) ? 15 : year % 15;
            int value_S = (year % 28 == 0) ? 28 : year % 28;
            int value_M = (year % 19 == 0) ? 19 : year % 19;
            if (value_E == E && value_S == S && value_M == M)
            {
                break;
            }
            year++;            
        }

        Console.WriteLine(year);
    }
}
