using System;
using System.Linq;

/// <summary>
/// p1145 - 적어도 대부분의 배수, B1
/// 해결 날짜 : 2023/9/15
/// </summary>

/*
브루트포스 알고리즘을 이용해서 다섯 수 중 
세 수의 최소 공배수 중 최솟값을 구하는 문제
*/ 

public class Program
{
    public static void Main(string[] args)
    {
        int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int min_LCM = int.MaxValue;
        for (int i = 0; i < 3; i++)
        {
            for (int j = i + 1; j < 4; j++)
            {
                for (int k = j + 1; k < 5; k++)
                {
                    min_LCM = Math.Min(min_LCM, 
                        LCM(LCM(input[i], input[j]), input[k]));
                }
            }
        }

        Console.WriteLine(min_LCM);
    }

    public static int GCD(int a, int b)
    {
        int small = (a < b) ? a : b;
        int large = (small == a)? b : a;

        if (large % small == 0) return small;
        else return GCD(large % small, small);
    }

    public static int LCM(int a, int b)
    {
        return a / GCD(a, b) * b;
    }
}