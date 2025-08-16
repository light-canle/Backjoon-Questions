using System;
using System.Collections.Generic;

// p1337 - 올바른 배열 (S4)
// #정렬
// 2025.8.16 solved

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
        nums.Sort();

        int minNeed = 9;
        /*
        배열의 수 k에 대해 k+1부터 k+4가 배열에 존재하는지 검사한다.
        4개 중에서 없는 만큼이 필요한 양이 된다. 이 필요한 양의 최솟값을 구한다.
        */
        foreach (var i in nums)
        {
            int currentNeed = 0;
            for (int j = i + 1; j <= i + 4; j++)
            {
                if (!nums.Contains(j)) currentNeed++;
            }
            minNeed = Math.Min(minNeed, currentNeed);
        }
        Console.WriteLine(minNeed);
    }
}
