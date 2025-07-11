using System;

// p24464 - 득수 밥 먹이기 (S1)
// #dp
// 2025.7.11 solved

public class Program
{
    public static long K = 1_000_000_007;
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        // 마지막 날에 굶거나 1~4번 식당에 가는 경우의 수
        long[] dp = new long[5];
        // 처음에는 모두 1이다.
        for (int i = 0; i < 5; i++)
        {
            dp[i] = 1;
        }

        for (int i = 2; i <= n; i++)
        {
            // 가장 마지막 날을 기준으로 다음 날에 할 수 있는 행동들의 경우의 수를 구했을 때 굶거나 1~4번 식당에 가는 경우의 수
            long[] toAdd = new long[5];
            for (int j = 0; j < 5; j++)
            {
                switch (j)
                {
                // 전 날에 굶은 경우 아무 식당에 가야 한다.
                case 0:
                    for (int k = 1; k <= 4; k++)
                    {
                        // 전 날 경우의 수만큼 추가
                        toAdd[k] += dp[j];
                    }
                    break;
                // 전 날에 식당에 간 경우 굶거나 인접하지 않은 다른 식당에 갈 수 있다.
                case 1:
                    toAdd[0] += dp[j];
                    toAdd[3] += dp[j];
                    toAdd[4] += dp[j];
                    break;
                case 2:
                    toAdd[0] += dp[j];
                    toAdd[4] += dp[j];
                    break;
                case 3:
                    toAdd[0] += dp[j];
                    toAdd[1] += dp[j];
                    break;
                case 4:
                    for (int k = 0; k <= 2; k++)
                    {
                        toAdd[k] += dp[j];
                    }
                    break;
                }
            }
            // 데이터를 갱신
            for (int j = 0; j < 5; j++)
            {
                dp[j] = toAdd[j];
                dp[j] %= K;
            }
        }
        long result = 0;
        for (int i = 0; i < 5; i++)
        {
            result += dp[i];
            result %= K;
        }
        Console.WriteLine(result);     
    }
}
