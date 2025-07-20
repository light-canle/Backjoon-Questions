using System;
using System.IO;
using System.Collections.Generic;

// p17608 - 막대기 (B2)
// #구현
// 2025.7.20 solved

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        int n = int.Parse(sr.ReadLine());
        List<int> nums = new();
        for (int i = 0; i < n; i++)
        {
            nums.Add(int.Parse(sr.ReadLine()));
        }
        int curMax = nums[n - 1];
        int canSeen = 1;
        for (int i = n - 2; i >= 0; i--)
        {
            // 자신의 오른쪽에 있는 막대들 중 제일 높은 것보다 
            // 더 높은 막대가 보이게 된다.
            if (curMax < nums[i])
            {
                curMax = nums[i];
                canSeen++;
            }
        }
        Console.WriteLine(canSeen);
        sr.Close();
    }
}
