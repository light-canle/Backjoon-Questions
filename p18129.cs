using System;
using System.Collections.Generic;

// p18129 - 이상한 암호코드 (B1)
// #문자열
// 2025.3.22 solved

public class Program
{
    public static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split(' ');
        string conv = input[0].ToLower();
        int k = int.Parse(input[1]);

        char prev = conv[0]; // 구간 구분을 위한 이전 문자
        bool[] alreadyUsed = new bool[26]; // 이미 쓰인 알파벳인가를 저장
        int partLen = 1; // 현재 구간 길이
        int limit = conv.Length; // 전체 문자열 길이
        List<int> parts = new List<int>(); // 각 구간의 길이를 저장
        // 각 구간의 길이 검사
        for (int i = 1; i < limit; i++)
        {
            char curr = conv[i];
            // 서로 다른 구간을 발견
            if (curr != prev)
            {
                // 추가된 적이 없는 알파벳만 추가
                if (!alreadyUsed[prev - 'a'])
                {
                    parts.Add(partLen);
                    alreadyUsed[prev - 'a'] = true;
                }
                
                partLen = 1;
            }
            else
            {
                partLen++;
            }
            prev = curr;
        }
        // 마지막 구간 고려
        if (!alreadyUsed[conv[limit - 1] - 'a'])
        {
            parts.Add(partLen);
        }
      
        string res = "";
        // 구간의 길이에 따라 0, 1추가
        foreach (int part in parts)
        {
            if (part >= k)
            {
                res += "1";
            }
            else
            {
                res += "0";
            }
        }
        Console.WriteLine(res);
    }
}
