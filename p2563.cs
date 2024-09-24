using System;
using System.Linq;
using System.Collections.Generic;

/// <summary>
/// p2563 - 색종이, S5
/// 해결 날짜 : 2023/8/31
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());

        int totalArea = 0;
        // 검은 종이가 올려졌는지를 판단하기 위한 배열
        int[,] filled = new int[100, 100];
        for (int i = 0; i < N; i++)
        {
            // 색종이의 위치를 받음
            int[] input = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            // 색종이의 크기는 항상 10이므로, 입력 받은 위치부터 10칸을 1로 바꾼다.
            for (int x = input[0]; x < input[0] + 10; x++)
            {
                for (int y = input[1]; y < input[1] + 10; y++)
                {
                    filled[y, x] = 1;
                }
            }
        }
        // 1의 개수를 센다.
        for (int x = 0; x < 100; x++)
        {
            for (int y = 0; y < 100; y++)
            {
                if (filled[y, x] == 1) totalArea++;
            }
        }

        Console.WriteLine(totalArea);
    }
}
