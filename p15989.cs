#pragma warning disable CS8604, CS8602, CS8600

using System;

// p15989 - 1, 2, 3 더하기 4 (G5)
// #DP
// 2025.9.8 solved

public class Program
{
    public static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine()!);

        // 경우의 수 중 3이 단 하나도 없는 경우
        long[] dp_non3 = new long[10001];
        // 경우의 수 중 3이 적어도 1개 이상 있는 경우
        long[] dp_with3 = new long[10001];
        dp_non3[0] = dp_non3[1] = 1;
        dp_non3[2] = 2;

        /*
        3부터 합의 경우의 수에 3이 없는 경우와 있는 경우로 나누어 구한다.
        우선 3이 없는 경우의 수는 dp_non3[i] = floor(i / 2) + 1이다. 1로만 이루어진 경우 하나와 1 두 개를 빼고 2를 하나씩 넣게 되면 총 floor(i / 2)개가 나온다.
        그 후 3을 하나씩 넣은 뒤의 경우의 수를 dp_with3에 누적한다. k개의 3이 있을 때, 나머지 수 i - 3k에 대해 3을 더 추가하지 않는 경우의 수는 dp_non3[i - 3k]이다.
        k = 1, 2, ... , floor(i / 3)에 대해 dp_non3[i - 3k]를 모두 더하여 구할 수 있다.
        */
        for (int i = 3; i <= 10000; i++)
        {
            int div3 = i / 3;
            int div2 = i / 2;
            dp_non3[i] = div2 + 1;
            for (int j = 1; j <= div3; j++)
            {
                dp_with3[i] += dp_non3[i - 3 * j];
            }
        }

        for (int i = 1; i <= t; i++) 
        {
            int n = int.Parse(Console.ReadLine()!);
            Console.WriteLine(dp_non3[n] + dp_with3[n]);
        }
    }
}
