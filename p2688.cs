#pragma warning disable CS8604, CS8602, CS8600

using System.Numerics;

// p2688 - 줄어들지 않아 (S1)
// #DP
// 2026.1.24 solved

public class Program
{
    public static void Main(string[] args)
    {
        BigInteger[] digitCount = new BigInteger[10];   // 현재 자리수에서 일의 자리가 0~9인 것의 개수
        BigInteger[] temp = new BigInteger[10];         // 덧셈을 위한 임시 변수 digitCount보다 1자리 더 큰 수의 정보 저장
        BigInteger[] dp = new BigInteger[65];           // n자리 줄어들지 않는 수의 개수

        // 1로 초기화
        for (int i = 0; i < 10; i++)
        {
            digitCount[i] = BigInteger.One;
        }
        dp[1] = 10; // 1자리 수는 모두 줄어들지 않는 수

        // 2부터 64까지 dp를 사용해서 구함
        for (int i = 2; i <= 64; i++)
        {
            // temp 초기화
            for (int j = 0; j < 10; j++)
            {
                temp[j] = 0;
            }
            // 끝자리가 j인 수 뒤에는 j, j+1, ... , 9까지 총 10 - j개의 수가 올 수 있다.
            // n+1자리 수 중 끝자리가 j인 수는 n자리 수 중 끝자리가 0, 1, ... j인 수의 개수의 합이다.
            for (int j = 0; j < 10; j++)
            {
                for (int k = j; k < 10; k++)
                {
                    temp[k] += digitCount[j];
                }
            }
            // temp를 모두 더해 n자리 줄어들지 않는 수를 구하고, digitCount에 넣는다.
            for (int j = 0; j < 10; j++)
            {
                dp[i] += temp[j];
                digitCount[j] = temp[j];
            }
        }

        int t = int.Parse(Console.ReadLine());
        for (int i = 0; i < t; i++)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(dp[n]);
        }
    }
}
