using System;
using System.Collections.Generic;

// p13335 - 트럭 (S1)
// #큐 #시뮬레이션
// 2025.4.23 solved

public class Program
{
    public static void Main(string[] args)
    {
        int[] nums = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        int n = nums[0], w = nums[1], L = nums[2];
        int[] truck = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        Queue<int> bridge = new();
        int currentWeight = 0;
        int next = 0;
        int time = 0;
        while (true)
        {
            // 다리에 새 트럭을 올린다. (bridge에 트럭의 인덱스를 넣음)
            // 1. 들어오려는 트럭의 하중 + 현재 다리 위 차 무게의 합이 다리 하중 이하
            // 2. 이번 턴에 앞의 트럭이 나가고 그 트럭이 나갔을 때의 무게 합과 들어오려는 트럭의 무게가 다리 하중 이하
            if (next < n && 
                ((truck[next] + currentWeight <= L) 
                 || (bridge.Count >= w 
                     && bridge.Peek() != -1 
                     && truck[next] + currentWeight - truck[bridge.Peek()] <= L)))
            {
                bridge.Enqueue(next);
                currentWeight += truck[next];
                next++;
            }
            // -1은 공기를 뜻함
            else
            {
                bridge.Enqueue(-1);
            }
            time++;
            // 다리를 다 건넌 트럭을 제거
            if (bridge.Count > w)
            {
                int outNum = bridge.Dequeue();
                // 마지막 트럭 탈출
                if (outNum == n - 1)
                {
                    break;
                }
                if (outNum != -1)
                {
                    currentWeight -= truck[outNum];
                }
            }          
        }
        Console.WriteLine(time);
    }
}
