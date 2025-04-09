using System;

// p32289 - Max-Queen (S5)
// #그리디
// 2025.4.9 solved

public class Program
{
    public static void Main(string[] args)
    {
        long[] size = Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
        long n = size[0], m = size[1];
        /*
        가장 많은 순서쌍이 나오려면 n*m 격자 모든 칸에 퀸을 배치하면 된다.
        이렇게 되면 순서쌍의 개수는 상하좌우와 대각선으로 인접한 모든 퀸을 연결한 수와 같다.
        우선 상하좌우로 연결한 순서쌍의 개수는 가로로 길이가 m - 1, 세로로 n - 1이며 각각 행과 열의 개수 만큼 있으므로 n(m - 1) + m(n - 1) = 2mn - m - n개 있다.
        대각선으로 연결된 것은 x자 형태로 (n - 1)(m - 1)개 있으므로 2(m-1)(n-1) = 2mn - 2(n + m) + 2개 있다.
        모두 합하면 4mn - 3(m+n) + 2개가 된다.
        */
        Console.WriteLine(4 * m * n - 3 * (m + n) + 2);
    }
}
