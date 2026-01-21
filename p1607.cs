#pragma warning disable CS8604, CS8602, CS8600

// p1607 - 원숭이 타워 (G3)
// #DP #재귀
// 2026.1.21 solved

public class Program
{
    public static int[,] dp;
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        // dp[n, 0] -> 막대가 3개일 때 n개 고리를 옮기는 최소 이동 횟수 = 2^n - 1임이 알려져 있다.
        // dp[n, 1] -> 막대가 4개일 때 n개 고리를 옮기는 최소 이동 횟수
        dp = new int[n + 1, 2];
        int cur = 2;
        for (int i = 1; i <= n; i++)
        {
            dp[i, 0] = cur - 1; // dp[i, 0] = (2^i - 1) mod 9901
            dp[i, 1] = -1;
            cur *= 2;
            cur %= 9901;
        }
        dp[1, 1] = 1;
        Console.WriteLine(MinimumMovement(n, 4));
    }

    // https://en.wikipedia.org/wiki/Tower_of_Hanoi#Frame%E2%80%93Stewart_algorithm
    public static int MinimumMovement(int n, int r)
    {
        // 이미 정의된 값은 가져온다.
        if (dp[n, r - 3] != -1) return dp[n, r - 3];
        // r = 4일 때의 k의 최적값
        int k = n - (int)Math.Round(Math.Sqrt(n * 2 + 1)) + 1;
        // Frame–Stewart 알고리즘 사용
        int ret = 2 * MinimumMovement(k, r) + MinimumMovement(n - k, r - 1);
        return dp[n, r - 3] = ret % 9901;
    }
}
