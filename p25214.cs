// p25214 - 크림 파스타 (S4)
// #DP
// 2026.2.22 solved (2.21)

StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput()));
int n = int.Parse(sr.ReadLine());

int[] values = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

int curMin = values[0];

int[] ret = new int[n];
ret[0] = 0;
for (int i = 1; i < n; i++)
{
    // 최솟값 갱신
    curMin = Math.Min(curMin, values[i]);
    // 현재값 - 최소, 이전 최대 차이값 중 큰 것을 선택
    ret[i] = Math.Max(ret[i - 1], values[i] - curMin);
}
sw.WriteLine(string.Join(" ", ret));
sw.Flush();
