using System;
using System.Linq;

/// <summary>
/// p1500 - 최대 곱, S2
/// 해결 날짜 : 2023/9/5
/// </summary>

/*
합이 a인 b개의 수의 곱이 최대가 되려면 b개의 수의 값들이 최대한 균등하면 된다.
예를 들어 a = 30, b = 7일때,
5개의 4와 2개의 5는 합을 30을 이루고, 곱은 최대가 된다.
그러면 어떻게 이를 구할 수 있을까?
우선 a / b를 한다. 이 경우 4가 나온다.
그리고 a / b를 b를 분모로 하는(즉, 기약분수가 아닌) 대분수로 나타낸다. 여기서는 4 2/7이 나온다.
여기서 2가 아까 구한 4보다 1 큰 수인 5의 개수, 5가 4의 개수가 된다.
*/
public class Program
{
    public static void Main(string[] args)
    {
        long[] list = Console.ReadLine().Split().Select(long.Parse).ToArray();
        long a = list[0];
        long b = list[1];

        long small = a / b;

        long result = Pow(small, b - a + (small * b)) * Pow(small + 1, a - (small * b));
        Console.WriteLine(result);
    }

    public static long Pow(long a, long b)
    {
        long result = 1;
        for (int i = 0; i < b; i++)
        {
            result *= a;
        }
        return result;
    }
}