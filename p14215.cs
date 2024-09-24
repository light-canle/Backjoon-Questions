using System;
using System.Linq;

/// <summary>
/// p14215 - 세 막대, B3
/// 해결 날짜 : 2024/3/27
/// </summary>

/*
세 막대 중 가장 긴 1개가 다른 2개의 막대 길이를 합친 것 이상이라면, 
가장 긴 것의 길이를 다른 2개 막대의 합 - 1로 바꿔서 가장 둘레가 긴 삼각형을 만들 수 있다.
아닌 경우에는 세 막대를 그대로 써서 삼각형을 만들면 그것이 가장 둘레가 긴 것이다.
*/

public class Program
{
    public static void Main(string[] args)
    {
        int[] pos = Console.ReadLine()!.Split().Select(int.Parse).ToArray();
        (int a, int b, int c) = (pos[0], pos[1], pos[2]);

        // c >= a + b는 2 * c >= a + b + c와 같다.(c가 가장 긴 변이라고 했을 때)
        if (2 * Max(a, b, c) >= a + b + c)
            Console.WriteLine((a + b + c - Max(a, b, c)) * 2 - 1);
        else
        {
            Console.WriteLine(a + b + c);
        }
    }

    public static int Max(int a, int b, int c)
    {
        return Math.Max(Math.Max(a, b), c);
    }
}