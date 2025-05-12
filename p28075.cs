using System;
using System.Linq;
using System.Collections.Generic;

// p28075 - 스파이 (S3)
// #재귀
// 2025.5.12 solved

public class Program
{
    public static List<List<int>> score;
    public static void Main(string[] args)
    {
        int[] num = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        int n = num[0], m = num[1];

        score = new List<List<int>>();
        for (int i = 0; i < 2; i++)
        {
            score.Add(Console.ReadLine().Split().Select(int.Parse).ToList());
        }

        int count = 0;
        // n일 동안 모든 임무를 하는 경우의 수를 다 조사해서 기여도가 m이상이 되는 것을 찾는다.
        for (int i = 0; i < 6; i++)
        {
            Recur(n, 0, m, 0, i, -1, ref count);
        }
        // 이유는 잘 모르겠으나 정답의 6을 곱한 수가 나와서 6으로 나누어 줬다.
        Console.WriteLine(count / 6);
    }

    /*
    day : 임무 수행 전체 기간
    curDay : 현재까지 수행한 일 수
    goal : 목표 기여도
    curScore : 현재 기여도
    cur : 현재 임무
    prev : 지난 임무
    count : 경우의 수
    */
    public static void Recur(int day, int curDay, int goal, int curScore, int cur, int prev, ref int count)
    {
        // n일 동안 임무 끝
        if (day == curDay)
        {
            // 기여도가 목표에 도달했는가?
            count += goal <= curScore ? 1 : 0;
            return;
        }
        // 현재 장소에서의 기여도
        int add = score[cur / 3][cur % 3];
        // 임무 장소가 지난 번과 같으면 기여도를 절반만 얻는다.
        add /= (prev != -1) && ((cur % 3) == (prev % 3)) ? 2 : 1;
        for (int i = 0; i < 6; i++)
        {
            Recur(day, curDay + 1, goal, curScore + add, i, cur, ref count);
        }
    }
}
