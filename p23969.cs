using System;
using System.Linq;
using System.Collections.Generic;

// p23969 - 알고리즘 수업 - 버블 정렬 2 (B1)
// #시뮬레이션 #정렬
// 2025.3.6 solved


public class Program
{
    public static void Main(string[] args)
    {
        int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        int n = input[0];
        int k = input[1];

        List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();

        // 버블 소트를 수행하면서 교환이 발생할 때마다 +1
        int swap = 0;
        for (int i = n - 1; i > 0; i--)
        {
            for (int j = 0; j < i; j++)
            {
                if (nums[j] > nums[j + 1])
                {
                    int temp = nums[j];
                    nums[j] = nums[j + 1];
                    nums[j + 1] = temp;
                    swap++;
                }
                // k번 교환이 이루어지면 현재 상태를 출력
                if (swap == k)
                {
                    Console.WriteLine(string.Join(" ", nums));
                    return;
                }
            }
        }
        Console.WriteLine(-1);
    }
}
