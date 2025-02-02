using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

// p1092 - 배 (G5)
// #그리디 #정렬
// 2025.1.31 start
// 2025.2.2 solved

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        int n = int.Parse(sr.ReadLine());
        List<int> crane = sr.ReadLine().Split().Select(int.Parse).ToList();

        int m = int.Parse(sr.ReadLine());
        List<int> boxes = sr.ReadLine().Split().Select(int.Parse).ToList();

        // 1. 가장 하중이 큰 크레인이 가장 무거운 박스를 옮길 수 없으면 -1
        if (crane.Max() < boxes.Max())
        {
            Console.WriteLine(-1);
            return;
        }

        // 2. 크레인, 박스 무게를 내림차순으로 정렬
        crane.Sort();
        crane.Reverse();
        boxes.Sort();
        boxes.Reverse();

        int cycle = 1;
        // 3. 가장 무거운 크레인부터 하나씩 상자에 1:1 대응을 시킴
        // 상자가 더 무거운 경우에는 다음 상자 옮기기를 시도
        // 이때 모든 크레인을 한 번씩 다쓰거나 모든 박스에 대해 옮기기를 시도한 경우 사이클 증가
        int curCrane = 0, curBox = 0, movedBox = 0;
        bool[] moved = new bool[m];
        while (movedBox < m)
        {
            // 해당 사이클에 크레인을 다 썼거나 남은 크레인으로 상자를 못 옮김
            if (curCrane == n || curBox == m)
            {
                cycle++;
                curCrane = 0;
                curBox = 0;
            }
            // 이미 옮겨진 상자는 건너뜀
            if (moved[curBox])
            {
                curBox++;
                continue;
            }
            // 상자를 옮길 수 있으면 상자를 옮기고 다음 크레인, 상자로 이동
            if (crane[curCrane] >= boxes[curBox])
            {
                moved[curBox] = true;
                movedBox++;
                curCrane++;
                curBox++;
            }
            // 상자롤 옮길 수 없으면 다음 상자에 대해 시도
            else
            {
                curBox++;
            }
        }
        Console.WriteLine(cycle);
        sr.Close();
    }
}
