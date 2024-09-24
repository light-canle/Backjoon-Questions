using System;
using System.Linq;

/// <summary>
/// p1359 - 복권, S4
/// 해결 날짜 : 2023/9/2
/// </summary>

/*
조합의 수와 여사건을 이용한 문제
자세한 풀이는 풀이 노트의 p1359문제 그림 참고
*/

public class Program
{
    public static void Main(string[] args)
    {
        int[] input = Console.ReadLine().Split().Select(x=>int.Parse(x)).ToArray();

        int N = input[0];
        int M = input[1];
        int K = input[2];

        int deno = Combination(N, M); // 전체 경우의 수

        int num = 1;
        if (M != K)
        {
            num = deno;
            int temp = K - 1;
            while (temp >= 0)
            {
                // 전체에서 여사건의 경우의 수를 뺀다.
                num -= Combination(M, temp) * Combination(N - M, M - temp);
                temp--;
            }
        }

        Console.WriteLine((double)num / deno);
    }

    // 조합의 수를 구하는 메소드
    // 입력이 1<=n<=8로 크지 않으므로 수학적 정의를 이용했다.
    public static int Combination(int n, int k)
    {
        if (n < k) { return 0; }
        return ( Factorial(n) ) / ( Factorial(n - k) * Factorial(k)) ;
    }

    public static int Factorial(int n)
    {
        if (n < 0) { throw new ArgumentException(); }
        if (n == 0 || n == 1) return 1;
        return n * Factorial(n - 1);
    }
}
