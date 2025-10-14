#pragma warning disable CS8604, CS8602, CS8600

using System;

// p1699 - 제곱수의 합 (S2)
// #DP
// 2023.11.22 start
// 2025.10.14 solved

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        // 해당 수를 몇 개의 제곱수의 합으로 나타낼 수 있는지를 저장
        int[] dp = new int[n + 1];
        // 기본값 초기화
        dp[0] = 0;
        dp[1] = 1;
        if (n > 1) dp[2] = 2;
        // 3부터는 dp를 사용해서 찾는다.
        for (int i = 3; i <= n; i++)
        {
            // 초기값은 모두 1^2의 합으로 나타내어져 있다고 가정
            dp[i] = i;
            int j = 1;
            // i - j^2을 최소 개수로 나타낸 것에 1을 더해 i를 제곱수의 합으로 나타낸 것의 개수를 구하고, 최솟값을 갱신한다.
            while (i - j * j >= 0)
            {
                dp[i] = Math.Min(dp[i], dp[i - j * j] + 1);
                j++;
            }
        }
        Console.WriteLine(dp[n]);
    }
}
