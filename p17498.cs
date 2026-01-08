#pragma warning disable CS8604, CS8602, CS8600

// p17498 - 폴짝 게임 (G5)
// #DP
// 2026.1.8 solved

/*
d = 4일 때 G 칸에 도달 가능한 칸들의 범위
            rowDiff    columnRange
XXXXOXXXX      4            1
XXXOOOXXX      3            3
XXOOOOOXX      2            5
XOOOOOOOX      1            7
XXXXGXXXX
*/

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));

        int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        int n = input[0], m = input[1], d = input[2];

        List<List<int>> board = new();
        for (int i = 0; i < n; i++)
        {
            board.Add(sr.ReadLine().Split().Select(int.Parse).ToList());
        }

        int[][] dp = new int[n][];
        dp[0] = new int[m]; // 초기 점수가 0이므로 첫 행은 0으로 초기화
        for (int i = 1; i < n; i++)
        {
            dp[i] = new int[m];
            Array.Fill(dp[i], int.MinValue); // 나머지 행은 최솟값으로 초기화 (최종 점수가 음수가 될 수 있음)
        }

        // 두 번째 행부터 해당 칸에 도달했을 때 얻을 수 있는 최대 점수를 구한다.
        for (int i = 1; i < n; i++)
        {
            // 거리가 d일 때, 행 차이의 최댓값은 d이다.
            for (int rowDiff = 1; rowDiff <= d; rowDiff++)
            {
                // 배열 범위를 벗어남
                if (i - rowDiff < 0) break;
                // 해당 행에서 거리 d 이내로 현재 칸에 도달 가능한 칸의 최대 개수
                // rowDiff가 클 수록 당연히 columnRange도 감소한다. (코드 맨 위 주석 참고)
                int columnRange = 2 * (d - rowDiff) + 1;
                for (int j = 0; j < m; j++)
                {
                    // 시작 열 번호 - 예를 들어 현재 칸이 (2, 4)이고, 행은 1칸 떨어져 있고, d = 2이면
                    // 가능한 열은 3, 4, 5가 되고, start는 3이 된다.
                    int start = j - (d - rowDiff);
                    for (int col = 0; col < columnRange; col++)
                    {
                        // 배열 범위를 벗어남
                        if (start + col < 0) continue;
                        if (start + col >= m) break;
                        // 현재 저장된 최댓값과 이전 칸에서 현재 칸으로 올 때 얻게 되는 점수를 이전 칸의 최대 점수와 더한 것을 비교
                        dp[i][j] = Math.Max(dp[i][j], 
                            dp[i - rowDiff][start + col] + board[i - rowDiff][start + col] * board[i][j]);
                    }
                }
            }
        }
        // 마지막 행에서의 최댓값을 출력
        Console.WriteLine(dp[n - 1].Max());
    }
}
