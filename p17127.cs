#pragma warning disable CS8604, CS8602, CS8600
using System;

// p17127 - 벚꽃이 정보섬에 피어난 이유 (S5)
// #완전 탐색
// 2025.5.28 solved

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int[] count = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        int maxValue = 0;
        // 네 구간의 경계를 옮기면서 구간 곱의 합이 최대가 되는 것을 찾음 - k의 제한 범위는 n-2까지이다.
        // 1구간 : 0 ~ i, 2구간 : i + 1 ~ j, 3구간 : j + 1 ~ k, 4구간 : k ~ n-1
        for (int i = 0; i < n - 3; i++)
        {
            for (int j = i + 1; j < n - 2; j++)
            {
                for (int k = j + 1; k < n - 1; k++)
                {
                    int cur = Product(count, 0, i);
                    cur += Product(count, i + 1, j);
                    cur += Product(count, j + 1, k);
                    cur += Product(count, k + 1, n - 1);
                    maxValue = Math.Max(maxValue, cur);
                }
            }
        }
        Console.WriteLine(maxValue);
    }

    // 인덱스가 start부터 end사이인 원소의 곱을 반환 (start, end 둘다 포함)
    public static int Product(int[] arr, int start, int end)
    {
        int ret = arr[start];
        for (int i = start + 1; i <= end; i++)
        {
            ret *= arr[i];
        }
        return ret;
    }
}
