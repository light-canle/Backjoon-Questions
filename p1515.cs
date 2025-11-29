#pragma warning disable CS8604, CS8602, CS8600

using System;

// p1515 - 수 이어 쓰기 (S2)
// #완전 탐색 #문자열 #그리디
// 2025.11.29 solved

public class Program
{
    public static void Main(string[] args)
    {
        string line = Console.ReadLine();
        int len = line.Length;
        bool found = false;
        int cur = 0, idx = 0;

        // 1부터 시작해서 각 수를 문자열로 만든 뒤 현재 line의 문자와 비교한다.
        // line의 모든 문자를 찾을 때까지 계속해서 cur을 늘려간다.
        while (!found)
        {
            cur++;
            string part = cur.ToString();
            foreach (char c in part)
            {
                // 모든 문자를 찾음 - 그때의 cur이 우리가 찾는 N의 최솟값이다.
                if (idx == len)
                {
                    found = true;
                    break;
                }
                if (c == line[idx]) idx++;
            }
            if (idx == len) found = true;
        }
        Console.WriteLine(cur);
    }
}
