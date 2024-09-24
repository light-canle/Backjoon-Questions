using System;
using System.Linq;

/// <summary>
/// p14786 - Ax+Bsin(x)=C, G3
/// 해결 날짜 : 2023/9/11
/// </summary>

/*
x의 범위를 0부터 C+1로 잡고 시작한 뒤
상한과 하한의 평균 m이 Am + Bsin(m) - C < 10^-9를 만족할 때까지
이분 탐색을 해서 적절한 m을 찾는다.
*/

public class Program
{
    public static void Main(string[] args)
    {
        double[] input = Console.ReadLine().Split().Select(double.Parse).ToArray();
        (double a, double b, double c) = (input[0], input[1], input[2]);

        double lower = 0;
        double upper = c + 1;

        double ans = 0;
        while (true)
        {
            double middle = (lower + upper) / 2;
            double lhs = a * middle + b * Math.Sin(middle);
            // 오차가 10^-9보다 작은 지 검사
            if (Math.Abs(lhs - c) < 0.0000000001)
            {
                ans = middle;
                break;
            }
            // 이분 탐색의 범위를 좁힌다.
            if (lhs - c < 0)
            {
                lower = middle;
            }
            else
            {
                upper = middle;
            }
        }
        Console.WriteLine(ans);
    }
}