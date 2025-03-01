using System;

// p14654 - 스테판 쿼리 (S4)
// #시뮬레이션
// 2025.3.1 solved

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int[] team1 = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        int[] team2 = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        int curWinStack = 0;
        int maxWinStack = 0;
        int prevWin = 0;
        for (int i = 0; i < n; i++)
        {
            // 게임 결과 도출
            // 3번 인자에는 지난 판에 패배한 팀의 번호가 들어감
            int curWin = GameResult(team1[i], team2[i], prevWin == 2 ? 1 : 2);
            if (curWin == prevWin)
            {
                curWinStack++;
            }
            else
            {
                maxWinStack = Math.Max(maxWinStack, curWinStack);
                curWinStack = 1;
            }
            prevWin = curWin;
        }
        // 마지막까지 이긴 연승의 결과를 반영
        maxWinStack = Math.Max(maxWinStack, curWinStack);
        Console.WriteLine(maxWinStack);
    }

    // 1 가위 2 바위 3 보
    // 1 < 2 < 3 < 1
    // 무승부인 경우 newPlayer가 승리
    public static int GameResult(int t1, int t2, int newPlayer)
    {
        int d = newPlayer;
        // 가위바위보를 했을 때 승리하는 팀의 번호
        // retTable[t1 - 1, t2 - 1]은 팀1이 t1, 팀2가 t2를 냈을 때 이긴 팀의 번호이다.
        int[,] retTable =
        {{d, 2, 1}, {1, d, 2}, {2, 1, d}};
        return retTable[t1 - 1, t2 - 1];
    }
}
