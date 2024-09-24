using System;
using System.Linq;

/// <summary>
/// p9184 - 신나는 함수 실행, S2
/// 해결 날짜 : 2024/4/6
/// </summary>

/*
DP를 사용해서 주어진 재귀함수의 실행을 빠르게 하는 문제
재귀함수의 정의에 의하면 1,1,1 ~ 20,20,20의 값만 필요로 하므로
20x20x20 배열에 계산된 값을 저장하고, 그 값들을 재귀 호출시
가져옴으로써 DP를 사용할 수 있다.
*/

public class Program
{
    public static int[,,] saved;
    public static void Main(string[] args)
    {
        saved = new int[20, 20, 20];
        while (true)
        {
            int[] nums = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

            (int a, int b, int c) = (nums[0], nums[1], nums[2]);

            if (a == -1 && b == -1 && c == -1)
            {
                break;
            }

            Console.WriteLine($"w({a}, {b}, {c}) = {w(a, b, c)}");
        }    
        
    }

    public static int w(int a, int b, int c)
    {
        if (a <= 0 || b <= 0 || c <= 0)
            return 1;
        else if (a > 20 || b > 20 || c > 20)
            return w(20, 20, 20);

        // 저장된 데이터 불러오기
        if (saved[a - 1, b - 1, c - 1] != 0)
        {
            return saved[a - 1, b - 1, c - 1];
        }
        else
        {
            // 값을 반환하면서 saved에 저장
            if (a < b && b < c)
            {
                return saved[a - 1, b - 1, c - 1] = w(a, b, c - 1) + w(a, b - 1, c - 1) - w(a, b - 1, c);
            }
            else
            {
                return saved[a - 1, b - 1, c - 1] = w(a - 1, b, c) + w(a - 1, b - 1, c) +
                       w(a - 1, b, c - 1) - w(a - 1, b - 1, c - 1);
            }
        }
    }
}