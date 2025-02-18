using System;
using System.Collections.Generic;

// p1590 - 캠프가는 영식 (S4)
// #정렬 #완전 탐색
// 2025.2.18 solved

public class Program
{
    public static void Main(string[] args)
    {
        int[] size = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        int n = size[0];
        int t = size[1];

        List<int> busTime = new List<int>();

        for (int i = 0; i < n; i++)
        {
            // 각 버스의 시작, 간격, 대수를 받은 뒤 각 버스의 시작 시간을 배열에 넣음
            // 10 5 4 이면 -> 10 15 20 25를 넣음
            int[] bus = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            int s = bus[0]; // 시작
            int interval = bus[1]; // 간격
            int cars = bus[2]; // 대수
            
            for (int j = 0; j < cars; j++)
            {
                busTime.Add(s);
                s += interval;
            }
        }

        // 정렬한 후 t이상 인 시작시간이 나올 때까지 조사
        busTime.Sort();
        int busCount = busTime.Count;
        int index = 0;
        int minWait = -1;
        while (index < busCount)
        {
            // 가장 먼저 온 버스 (busTime[i] 가 t이상인 것 중 최소)와
            // 온 시간 t의 차이를 출력
            if (busTime[index] >= t)
            {
                minWait = busTime[index] - t;
                break;
            }
            index++;
        }
        Console.WriteLine(minWait);
    }
}
