#pragma warning disable CS8604, CS8602, CS8600

using System;
using System.Linq;

// p18353 - 병사 배치하기 (S2)
// #LIS(O(n^2)) #DP
// 2025.11.28 solved

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int[] power = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        int[] LDSLength = new int[n]; // 처음부터 현재 원소까지 가장 긴 감소하는 수열의 길이
        LDSLength[0] = 1; // 1번째 원소는 당연히 1이다.
        for (int i = 1; i < n; i++)
        {
            int prevMax = 0;
            for (int j = 0; j < i; j++)
            {
                // 감소하는 수열이므로, 이전 원소가 큰 경우에만 prevMax를 업데이트 한다.
                if (power[j] > power[i])
                    prevMax = Math.Max(prevMax, LDSLength[j]);
            }
            // 구한 가장 긴 감소하는 수열에 현재 원소를 이어 붙인다.
            LDSLength[i] = prevMax + 1;
        }

        int maxLDS = LDSLength.Max();
        Console.WriteLine(n - maxLDS);
    }
}
