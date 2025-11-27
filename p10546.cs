#pragma warning disable CS8604, CS8602, CS8600

using System;
using System.IO;
using System.Collections.Generic;

// p10546 - 배부른 마라토너 (S4)
// #맵 #문자열
// 2025.11.28 solved (11.27)

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        int n = int.Parse(sr.ReadLine());
        Dictionary<string, int> participants = new(); // 전체 참가자의 이름과 수
        Dictionary<string, int> completed = new();    // 완주한 사람
        // 참가자들 이름을 받는다. 동명이인의 경우 수를 늘린다.
        for (int i  = 0; i < n; i++)
        {
            string name = sr.ReadLine();
            if (!participants.ContainsKey(name)) participants[name] = 0;
            participants[name]++;
        }
        // 완주한 사람 목록을 받는다.
        for (int i = 0; i < n - 1; i++)
        {
            string name = sr.ReadLine();
            if (!completed.ContainsKey(name)) completed[name] = 0;
            completed[name]++;
        }
        // 완주하지 못한 1명을 찾는다.
        string result = "";
        foreach (var pair in participants)
        {
            string current = pair.Key;
            // 완주자 목록에 없거나, 참가자와 완주자 수가 다르면 그 사람이 완주하지 못한 것이다.
            if (!completed.ContainsKey(current) || participants[current] != completed[current])
            {
                result = current;
                break;
            }
        }
        Console.WriteLine(result);
        sr.Close();
    }
}
