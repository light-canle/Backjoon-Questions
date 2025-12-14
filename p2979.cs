#pragma warning disable CS8604, CS8602, CS8600

using System;

// p2979 - 트럭 주차 (B2)
// #시뮬레이션
// 2025.12.15 solved (12.14)

public class Program
{
    public static void Main(string[] args)
    {
        int[] cost = InputArray();
        int one = cost[0], two = cost[1], three = cost[2];

        int[] aTime = InputArray();
        int[] bTime = InputArray();
        int[] cTime = InputArray();

        int totalCost = 0;
        for (int t = 1; t <= 100; t++)
        {
            int currentTruck = 0;
            if (aTime[0] <= t && t < aTime[1]) currentTruck++;
            if (bTime[0] <= t && t < bTime[1]) currentTruck++;
            if (cTime[0] <= t && t < cTime[1]) currentTruck++;
            switch (currentTruck)
            {
                case 1: totalCost += one; break;
                case 2: totalCost += 2 * two; break;
                case 3: totalCost += 3 * three; break;
            }
        }
        Console.WriteLine(totalCost);
    }
    public static int[] InputArray()
    {
        return Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    }
}
