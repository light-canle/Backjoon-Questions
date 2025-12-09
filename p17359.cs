#pragma warning disable CS8604, CS8602, CS8600

using System;
using System.Collections.Generic;
using System.Linq;

// p17359 - 전구 길만 걷자 (S2)
// #완전 탐색 #백트래킹
// 2025.12.10 solved (12.9)

public class Program
{
    public static List<string> strings;     // 입력 문자열
    public static bool[] visited;           // 방문했는지 여부
    public static string[] done;            // 완성된 순서의 배열
    public static int baseChange;           // 전구가 바뀌는 기본 횟수 (각 묶음 내에서 전구가 바뀌는 것의 횟수)
    public static int minChange;            // 이어 붙였을 때 전구가 바뀌는 최소 횟수
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        strings = new();
        visited = new bool[n];
        done = new string[n];
        minChange = int.MaxValue;
        // 전구의 상태를 받고 각 묶음 안에서 바뀌는 횟수를 센다.
        for (int i = 0; i < n; i++)
        {
            strings.Add(Console.ReadLine());
            baseChange += FlipCount(strings[i]);
        }
        // n!의 모든 경우의 수 고려
        CombineAll(n, 0);
        Console.WriteLine(minChange);
    }

    // 길이 n의 모든 순열을 만들어 낸다.
    public static void CombineAll(int n, int depth)
    {
        if (depth == n)
        {
            CalculateChange();
            return;
        }
        for (int i = 0; i < n; i++)
        {
            if (!visited[i])
            {
                visited[i] = true;
                done[depth] = strings[i];
                CombineAll(n, depth + 1);
                visited[i] = false;
            }
        }
    }

    public static void CalculateChange()
    {
        int len = done.Length - 1;
        // 기본 횟수는 순서에 상관없이 공통
        int changeCount = baseChange;
        for (int i = 0; i < len; i++)
        {
            // 앞 문자열의 끝과 뒷 문자열의 앞이 다르면 횟수 증가
            if (done[i][^1] != done[i + 1][0]) changeCount++;
        }
        minChange = Math.Min(changeCount, minChange);
    }

    // 각 문자열에서 연속된 두 문자가 다른 것의 횟수를 센다.
    public static int FlipCount(string str)
    {
        if (str.Length < 2) return 0;
        char prev = str[0];
        int count = 0;
        for (int i = 1; i < str.Length; i++)
        {
            if (prev != str[i]) count++;
            prev = str[i];
        }
        return count;
    }
}
