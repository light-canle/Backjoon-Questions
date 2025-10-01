using System;

// p23972 - 악마의 제안 (B2)
// #수학
// 2025.10.1 solved

/*
N, K가 주어질 때
N(X-K) >= X인 최소의 정수 X를 구하는 문제이다.
NX - NK >= X
X(N-1) >= NK
X >= NK / (N-1)
N > 1이어야 하므로 N이 1이면 손해만 보게 된다.
그 외에는 위의 결과처럼 N*K/(N-1)을 구하되
정수가 되어야 하므로 NK를 N-1로 나눈 나머지가 0이 아니면
계산 결과에 1을 더해 반환한다.
*/
public class Program
{
    public static void Main(string[] args)
    {
        long[] input = Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
        long k = input[0], n = input[1];
        long ret = 0;
        if (n == 1) {
            ret = -1;
        }
        else {
            ret = (n * k) % (n - 1) == 0 ? (n * k) / (n - 1) : (n * k) / (n - 1) + 1;
        }
        Console.WriteLine(ret);
    }
}
