// p1965 - 상자넣기 (S2)
// #DP #LIS
// 2026.2.16 solved

int n = int.Parse(Console.ReadLine());
int[] value = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int[] dp = new int[n]; // dp[i]는 i번 인덱스의 요소를 끝으로 하는 LIS의 길이이다.
dp[0] = 1;
for (int i = 1; i < n; i++)
{
    int maxChain = 0;
    for (int j = 0; j < i; j++)
    {
        // 자신 이전 요소의 LIS 중 제일 긴 것을 찾는다.
        // 단, 그 LIS를 이루는 요소의 끝 값이 자신보다 작아야 한다.
        if (value[j] < value[i])
        {
            maxChain = Math.Max(maxChain, dp[j]);
        }
    }
    // 찾은 LIS에 자신을 연결
    dp[i] = maxChain + 1;
}
Console.WriteLine(dp.Max());
