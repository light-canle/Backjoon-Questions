using System;
using System.Linq;

/// <summary>
/// p24313 - 알고리즘 수업 - 점근적 표기 1, S5
/// 해결 날짜 : 2024/3/27
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        int[] coeff = Console.ReadLine()!.Split().Select(int.Parse).ToArray();
        int c = int.Parse(Console.ReadLine()!);
        int n0 = int.Parse(Console.ReadLine()!);

        // 1. a1 > c인 경우 - f(n)이 증가하는 속도가 cg(n)보다 크므로 정의에 만족하지 않음
        if (coeff[0] > c)
        {
            Console.WriteLine(0);
        }
        // 2. a1 <= c인 경우 - f(n0) <= cg(n0)인 경우 정의 만족, 아니면 만족하지 않음
        else
        {
            Console.WriteLine(coeff[0] * n0 + coeff[1] <= c * n0 ? 1 : 0);
        }
    }
}