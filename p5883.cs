using System;
using System.Collections.Generic;

// p5883 - 아이폰 9S (S4)
// #완전 탐색
// 2025.5.5 solved

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        List<int> nums = new();

        for (int i = 0; i < n; i++)
        {
            nums.Add(int.Parse(Console.ReadLine()));
        }
        int maxStack = 0;
        for (int i = 0; i < n; i++)
        {
            int skip = nums[i];
            int curStack = 0;
            int curMax = 0;
            int prev = -1;
            for (int j = 0; j < n; j++)
            {
                // 줄에서 빼버린 수는 세지 않음
                if (nums[j] == skip)
                {
                    continue;
                }
                if (prev != nums[j])
                {
                    curMax = Math.Max(curMax, curStack);
                    curStack = 1;
                }
                else
                {
                    curStack++;
                }
                prev = nums[j];
            }
            // 최댓값 갱신
            curMax = Math.Max(curMax, curStack);
            maxStack = Math.Max(maxStack, curMax);
        }
        Console.WriteLine(maxStack);
    }
}
