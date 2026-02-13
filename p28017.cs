// p28017 - 게임을 클리어하자 (G5)
// #DP
// 2026.2.13 solved

StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
int n = input[0], m = input[1];

List<List<int>> time = new();
for (int i = 0; i < n; i++)
{
    time.Add(sr.ReadLine().Split().Select(int.Parse).ToList());
}
// dp[i, j]는 처음부터 i번째 도전까지의 최소 클리어 시간에 i+1번째 도전에 j+1번째 무기를 골랐을 때의 클리어 시간이다.
int[,] dp = new int[n, m];
for (int i = 0; i < n; i++)
{
    for (int j = 0; j < m; j++)
    {
        // 첫 행은 그 무기를 골랐을 때의 클리어 시간이다.
        if (i == 0)
        {
            dp[i, j] = time[i][j];
            continue;
        }
        // 이전 시도의 클리어 타임 합에서 직전 무기를 고르는 것을 제외한 나머지 경우들 중 최소 시간을 구한다.
        int minTime = int.MaxValue;
        for (int k = 0; k < m; k++)
        {
            if (k == j) continue;
            minTime = Math.Min(minTime, dp[i - 1, k]);
        }
        // 이번 무기의 클리어 시간을 합친다.
        dp[i, j] = minTime + time[i][j];
    }
}
// 전체 최솟값은 마지막 도전까지 수행한 뒤 각 무기의 클리어 시간 중 가장 작은 시간이다.
int minClearTime = int.MaxValue;
for (int i = 0; i < m; i++)
{
    minClearTime = Math.Min(minClearTime, dp[n - 1, i]);
}
Console.WriteLine(minClearTime);
