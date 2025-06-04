using System;
using System.Numerics;

// p1560 - 비숍 (S3)
// #애드 혹
// 2025.6.4 solved

public class Program
{
    public static void Main(string[] args)
    {
        /*
        N x N 체스보드 위에 비숍을 최대로 놓는 방법은
        1. 맨 윗 행에 N개의 비숍을 배치한다.
        2. 맨 아래 행에 맨 끝 2칸을 제외하고 N - 2개의 비숍을 배치한다.
        BBBB
        ....
        ....
        .BB. <- 4x4 배치때의 예시
        이렇게 하면 서로 잡히지 않게 비숍을 배치할 수 있고,
        총 개수는 2N - 2개가 된다.
        단, N = 1일 때는 칸 1개에 비숍을 배치하면 되므로 1이 정답이다.
        */
        BigInteger n = BigInteger.Parse(Console.ReadLine());
        Console.WriteLine(n == 1 ? 1 : 2 * (n - 1));
    }
}
