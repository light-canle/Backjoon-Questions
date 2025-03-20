using System;

// p2847 - 게임을 만든 동준이 (S4)
// #그리디
// 2025.3.20 solved

public class Program
{
    public static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine());

        int[] list = new int[t];
        for (int i = 0; i < t; i++)
        {
            list[i] = int.Parse(Console.ReadLine());
        }

        int decreaseCount = 0;
        // 상한을 오른쪽 값-1로 두고 그것보다 크면
        // 상한이 되도록 점수를 줄이면 된다.
        int limit = list[t - 1] - 1;
        for (int i = t - 2; i >= 0; i--)
        {
            if (list[i] > limit)
            {
                int diff = list[i] - limit;
                decreaseCount += diff;
                list[i] -= diff;
            }
            limit = list[i] - 1;
        }
        Console.WriteLine(decreaseCount);
    }
}
