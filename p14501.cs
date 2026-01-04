#pragma warning disable CS8604, CS8602, CS8600

// p14501 - 퇴사 (S3)
// #재귀 #완전 탐색
// 2026.1.4 solved

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        List<(int, int)> info = new();
        for (int i = 0; i < n; i++)
        {
            int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            info.Add((input[0], input[1]));
        }
        Console.WriteLine(FindMaxValue(info, n, 0, 0));
    }

    // cur부터 끝까지 할 수 있는 일을 조사해서, 일로 얻을 수 있는 최대 이익을 구한다.
    // info : (걸리는 시간, 수익)으로 이루어진 리스트
    // totalCount : 전체 날의 수
    // cur : 현재 날짜
    // curSum : 지금까지 번 수익
    public static int FindMaxValue(List<(int, int)> info, int totalCount, int cur, int curSum)
    {
        if (cur >= totalCount)
        {
            return curSum;
        }
        int doWork = curSum;
        // 퇴사 전까지 할 수 있는 일인지 조사한 후 수행
        if (cur + info[cur].Item1 <= totalCount)
        {
            // 일을 마친 후 날짜로 이동하고, 일로 얻은 수익을 추가
            doWork = FindMaxValue(info, totalCount, cur + info[cur].Item1, curSum + info[cur].Item2);
        }
        // 일을 하지 않은 경우 다음 날로 이동
        int doNotWork = FindMaxValue(info, totalCount, cur + 1, curSum);
        // 둘 중 수익이 높은 것을 반환
        return Math.Max(doWork, doNotWork);
    }
}
