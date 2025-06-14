using System;
using System.IO;
using System.Collections.Generic;

// p5874 - 소를 찾아라 (S4)
// #스위핑 #문자열
// 2025.6.15 solved

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        string input = sr.ReadLine();
        int len = input.Length;

        List<int> back = new();
        List<int> front = new();

        // 뒷다리와 앞다리의 위치가 될 수 있는 것을 리스트에 추가
        // 앞에서부터 탐색하므로, back과 front는 오름차순 정렬이 된다.
        for (int i = 0; i < len - 1; i++)
        {
            if (input.Substring(i, 2) == "((")
            {
                back.Add(i);
            }
            else if  (input.Substring(i, 2) == "))")
            {
                front.Add(i);
            }
        }
        int idx = 0;
        int c = front.Count;
        long pairCount = 0;
        // 모든 뒷다리에 위치에 대하여 자신보다 오른쪽에 있는 앞다리 좌표의
        // 개수를 센 뒤 pairCount에 누적한다.
        foreach (var b in back)
        {
            // 현재 idx가 가리키고 있는 앞다리 위치가 뒷다리 위치보다 앞이면 idx를 뒤로 옮긴다.
            while (idx < c && front[idx] <= b)
            {
                idx++;
            }
            // 그 위치부터 뒤에 있는 모든 좌표는 b보다 크다.
            pairCount += c - idx;
        }
        Console.WriteLine(pairCount);
        sr.Close();
    }
}
