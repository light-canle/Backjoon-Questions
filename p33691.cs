#pragma warning disable CS8604, CS8602, CS8600

using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Text;

// p33691 - Arkain 대시보드 (S3)
// #해시와 맵 #정렬
// 2025.10.18 solved

public class Info
{
    public bool important;  // 중요한 컨테이너 인가?
    public int time;        // 최근에 사용된 시간

    public Info(int _time)
    {
        important = false;
        time = _time;
    }
}
public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput()));
        sw.AutoFlush = true;
        StringBuilder output = new();

        int n = int.Parse(sr.ReadLine());
        // 컨테이너를 담는 딕셔너리
        Dictionary<string, Info> containers = new();
        // 해당 컨테이너를 사용한 시간을 저장
        for (int i = 0; i < n; i++)
        {
            containers[sr.ReadLine()] = new Info(i);
        }

        int m = int.Parse(sr.ReadLine());
        // 중요한 컨테이너의 정보를 업데이트
        for (int i = 0; i < m; i++)
        {
            containers[sr.ReadLine()].important = true;
        }

        // 주어진 조건에 따른 정렬
        // 1. 중요한 라이브러리 우선
        // 2. 그 안에서 최근 사용된 시간이 큰 것이 앞에 오도록
        var pairs = containers.ToList();
        pairs = pairs.OrderBy(x => !x.Value.important)
            .ThenBy(x => -x.Value.time).ToList();

        foreach (var pair in pairs)
        {
            output.AppendLine(pair.Key);
        }
        
        sw.WriteLine(output);
        sr.Close();
        sw.Close();
    }
}
