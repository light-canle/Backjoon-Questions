#pragma warning disable CS8604, CS8602, CS8600

using System;
using System.Collections.Generic;

// p2118 - 두 개의 탑 (G5)
// #누적 합 #두 포인터
// 2025.11.10 solved

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        int n = int.Parse(sr.ReadLine());

        List<int> list = new List<int>();

        int totalDistance = 0;
        for (int i = 0; i < n; i++)
        {
            int k = int.Parse(sr.ReadLine());
            list.Add(k);
            totalDistance += k;
        }

        // 시작부터 현재 점까지의 누적 거리를 구한다.
        List<int> distSum = new List<int>();
        distSum.Add(0);
        int curSum = 0;
        for (int i = 0; i < n; i++)
        {
            curSum += list[i];
            distSum.Add(curSum);
        }

        // 최대 간격을 구한다.
        int maxInterval = 0, curInterval;
        int left = 0, right = 0; // 두 포인터 - 둘 다 왼쪽 끝에서 시작해서 오른쪽 방향으로 이동
        // 왼쪽 포인터와 오른쪽 포인터가 distSum의 양쪽 끝에서 만날 때까지 반복
        while (left < n)
        {
            curInterval = 0;
            // 오른쪽 포인터가 이미 끝에 도달 - 왼쪽만 움직임
            if (right == n) { left++; }
            // 두 포인터가 만남 - 오른쪽을 움직임
            else if (left == right) { right++; }
            // 그 외 : 왼쪽이 움직였을 때와, 오른쪽 포인터가 움직였을 때 두 점 사이 거리를 구한 뒤
            // 그 거리가 더 큰 쪽의 포인터를 결과적으로 움직인다.
            else
            {
                int leftMove = Interval(distSum[right] - distSum[left + 1], totalDistance);
                int rightMove = Interval(distSum[right + 1] - distSum[left], totalDistance);
                if (leftMove > rightMove) { left++; }
                else { right++; }
            }
            curInterval = Interval(distSum[right] - distSum[left], totalDistance);
            // 최댓값 갱신
            maxInterval = Math.Max(maxInterval, curInterval);   
        }
        Console.WriteLine(maxInterval);
        sr.Close();
    }

    // 두 점 사이의 거리와 전체 길이가 주어졌을 때,
    // 주어진 두 점 사이 거리를 시계 방향 / 반시계 방향 중 더 작은 쪽으로 반환한다. (원형이라고 생각)
    // ex) diff = 22, totalDistance = 30이면, 실질적으로 두 점 사이 거리는 8이 된다.
    public static int Interval(int diff, int totalDistance)
    {
        return Math.Min(diff, totalDistance - diff);
    }
}
