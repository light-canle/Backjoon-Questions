#pragma warning disable CS8604, CS8602, CS8600

using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

// p2371 - 파일 구별하기 (S3)
// #정렬 #완전 탐색
// 2025.12.4 solved (12.3)

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        int n = int.Parse(sr.ReadLine());
        List<List<int>> arrays = new();
        for (int i = 0; i < n; i++)
        {
            arrays.Add(sr.ReadLine().Split().Select(int.Parse).ToList());
            arrays[i].RemoveAt(arrays[i].Count - 1);
        }
        // n = 1일 때는 따로 처리
        if (n == 1)
        {
            Console.WriteLine(1);
            return;
        }
        // 길이가 짧은 리스트가 앞에 오도록 정렬
        arrays = arrays.OrderBy(x => x.Count).ToList();
        int maxLen = arrays[^1].Count;
        // k는 현재 살펴보고 있는 인덱스, firstIdx는 처음으로 살펴볼 배열의 인덱스
        int k = 0, firstIdx = 0;
        // 현재 단계에서의 첫 번째 배열과 다름이 입증 되었는가?
        bool[] isDifferent = new bool[n];
        isDifferent[0] = true;
        while (!AllTrue(isDifferent))
        {
            // k번 인덱스가 있는 배열을 1번째 배열로 잡는다
            while (firstIdx < n && arrays[firstIdx].Count <= k) firstIdx++;
            if (firstIdx == n) break;
            int first = arrays[firstIdx][k];
            for (int i = firstIdx + 1; i < n; i++)
            {
                // 해당 배열에 k번 인덱스 요소가 없으면 기준 배열과 다른 것이다.
                if (arrays[i].Count <= k) isDifferent[i] = true;
                // 해당 배열의 k번 인덱스 요소가 처음 배열과 다른 경우
                else if (arrays[i][k] != first) isDifferent[i] = true;
            }
            k++;
        }
        Console.WriteLine(k);
        sr.Close();
    }

    // 해당 bool 배열의 모든 값이 true이면 true를 반환한다.
    public static bool AllTrue(bool[] arr)
    {
        foreach (bool b in arr)
        {
            if (!b) return false;
        }
        return true;
    }
}
