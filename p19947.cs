// p19947 - 투자의 귀재 배주형 (S5)
// #DP
// 2026.2.21 solved

int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int start = input[0], year = input[1];
int[] dp = new int[year + 1]; // dp[y]는 시작 후 y년이 지난 후 얻을 수 있는 수익의 최댓값
dp[0] = start;
for (int cur = 1; cur <= year; cur++)
{
    int y1 = 0;
    int y3 = 0;
    int y5 = 0;
    // 5년 이상 경과한 경우 5년 전 가격의 35% 추가
    if (cur >= 5) y5 = (int)Math.Floor(dp[cur - 5] * 1.35);
    // 3년 이상 경과한 경우 3년 전 가격의 20% 추가
    if (cur >= 3) y3 = (int)Math.Floor(dp[cur - 3] * 1.2);
    // 1년 전 가격의 5% 추가
    y1 = (int)Math.Floor(dp[cur - 1] * 1.05);
    // 셋 중 가장 큰 것을 dp에 저장
    dp[cur] = Math.Max(y1, Math.Max(y3, y5));
}
Console.WriteLine(dp[year]);
