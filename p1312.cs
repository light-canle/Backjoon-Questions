using System;
using System.Linq;

/// <summary>
/// p1312 - 소수, S5
/// 해결 날짜 : 2023/9/1
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        int[] input = Console.ReadLine().Split().Select(x=>int.Parse(x)).ToArray();

        int A = input[0];
        int B = input[1];
        int N = input[2];
        int div = 0;
        // 소수점 자리 수에만 관심이 있으므로, 답의 정수부를 무시하기 위해
        // A를 B로 나눈 뒤, 그 나머지를 A에 다시 넣는다.
        while (A / B > 0)
        {
            A = A % B;
        }
        // 
        for (int i = 0; i < N; i++)
        {
            A *= 10;
            // 자릿수를 하나 늘려도 B보다 작은 경우 해당 소수점 자리는 0인 것이다.
            if (A / B == 0)
            {
                div = 0;
                continue;
            }
            div = A / B;
            A = A % B;
        }

        Console.WriteLine(div);
    }
}
