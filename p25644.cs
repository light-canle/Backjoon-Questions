#pragma warning disable CS8604, CS8602, CS8600

using System;

// p25644 - 최대 상승 (S5)
// #그리디 #완전 탐색
// 2025.11.6 solved (11.5)

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        int n = int.Parse(sr.ReadLine());
        int[] array = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

        int[] rightMax = new int[n];
        rightMax[n - 1] = array[n - 1];
        // 자신과 오른쪽에 있는 값 중에서 제일 큰 값을 rightMax에 저장
        for (int i = n - 2; i >= 0; i--)
        {
            rightMax[i] = Math.Max(rightMax[i + 1], array[i]);
        }
        int diffMax = int.MinValue;
        // rightMax와 원래 위치 값의 차이가 최대가 되는 곳을 찾는다.
        for (int i = 0; i < n; i++)
        {
            diffMax = Math.Max(diffMax, rightMax[i] - array[i]);
        }
        Console.WriteLine(diffMax);
        sr.Close();
    }
}
