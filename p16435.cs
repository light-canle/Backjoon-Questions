#pragma warning disable CS8604, CS8602, CS8600

using System;
using System.Linq;
using System.Collections.Generic;

// p16435 - 스네이크버드 (S5)
// #정렬 #그리디
// 2025.10.20 solved

public class Program
{
    public static void Main(string[] args)
    {
        int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        int n = input[0], l = input[1];

        List<int> heights = Console.ReadLine().Split().Select(int.Parse).ToList();
        heights.Sort();

        int idx = 0;
        // 낮은 높이에 있는 것부터 먹는다.
        while (idx < n && heights[idx] <= l)
        {
            l++; idx++;
        }
        Console.WriteLine(l);
    }
}
