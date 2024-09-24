using System;
using System.Linq;
using System.Collections.Generic;

/// <summary>
/// p2579 - 계단 오르기, S3
/// 시작 날짜 : 2023/9/1
/// 시간 초과로 미해결
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        int numStair = int.Parse(Console.ReadLine());

        List<int> list = new List<int>();
        for (int i = 0; i < numStair; i++)
        {
            list.Add(int.Parse(Console.ReadLine()));
        }

        List<int> maxScore = Enumerable.Repeat(0, numStair + 1).ToList();
        maxScore[maxScore.Count - 1] = list[list.Count - 1];
        FindMax(list, ref maxScore, maxScore.Count - 1, false);

        Console.WriteLine(maxScore[0]);
    }

    public static void FindMax(List<int> list, ref List<int> maxlist, int index, bool isBehind)
    {
        if (index == 0) return;
        if (index == 1)
        {
            maxlist[0] = Max(maxlist[0], maxlist[1]);
            FindMax(list, ref maxlist, 0, true);
            return;
        }
        if (index == 2)
        {
            if(!isBehind)
            {
                maxlist[1] = Max(maxlist[1], maxlist[2] + list[0]);
                FindMax(list, ref maxlist, 1, true);
            }
            maxlist[0] = Max(maxlist[0], maxlist[2]);
            FindMax(list, ref maxlist, 0, false);
            return;
        }
        if (!isBehind)
        {
            maxlist[index - 1] = Max(maxlist[index - 1], maxlist[index] + list[index - 2]);
            FindMax(list, ref maxlist, index - 1, true);
        }
        maxlist[index - 2] = Max(maxlist[index - 2], maxlist[index] + list[index - 3]);
        FindMax(list, ref maxlist, index - 2, false);
    }
    public static int Max(int a, int b)
    {
        return (a > b) ? a : b;
    }
}

/*
적은 입력(n ~ 40)에 실행되는 알고리즘

using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        int numStair = int.Parse(Console.ReadLine());

        List<int> list = new List<int>();
        for (int i = 0; i < numStair; i++)
        {
            list.Add(int.Parse(Console.ReadLine()));
        }

        List<int> maxScore = Enumerable.Repeat(0, numStair + 1).ToList();
        maxScore[maxScore.Count - 1] = list[list.Count - 1];
        FindMax(list, ref maxScore, maxScore.Count - 1, false); // 최대 점수를 찾는 재귀 함수

        Console.WriteLine(maxScore[0]);
    }

    // list는 각 계단의 점수, maxlist에는 가장 높은 계단에서 현재 위치 계단까지 내려왔을 때 점수의 최댓값이 들어있다.
    // (문제의 풀이 방식과는 다름) 가장 높은 계단에서 부터 1, 2계단 씩 내려왔을 때, 누적된 점수 합 중
    // 가장 큰 것을 maxlist의 각 항에 저장한다.([0]에 우리가 원하는 답이 들어있고, [i]에는 제일 높은 계단에서 i번째 계단까지
    // 내려 왔을 때 점수의 최댓값이 저장된다.)
    // index는 현재 계단 번호, isBehind는 전 계단을 밟았는지 여부를 담는다.
    public static void FindMax(List<int> list, ref List<int> maxlist, int index, bool isBehind)
    {
        if (index == 0) return;
        if (index == 1)
        {
            // 마지막 계단에서 내려옴
            maxlist[0] = Max(maxlist[0], maxlist[1]);
            FindMax(list, ref maxlist, 0, true);
            return;
        }
        if (index == 2)
        {
            if(!isBehind)
            {
                maxlist[1] = Max(maxlist[1], maxlist[2] + list[0]);
                FindMax(list, ref maxlist, 1, true);
            }
            maxlist[0] = Max(maxlist[0], maxlist[2]);
            FindMax(list, ref maxlist, 0, false);
            return;
        }
        // 전 계단을 밟지 않았다면, 바로 아래 계단으로 내려갈 수 있다.
        if (!isBehind)
        {
            maxlist[index - 1] = Max(maxlist[index - 1], maxlist[index] + list[index - 2]);
            FindMax(list, ref maxlist, index - 1, true);
        }
        // 2칸 뛰기를 한다.
        maxlist[index - 2] = Max(maxlist[index - 2], maxlist[index] + list[index - 3]);
        FindMax(list, ref maxlist, index - 2, false);
    }
    public static int Max(int a, int b)
    {
        return (a > b) ? a : b;
    }
}
*/