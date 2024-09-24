using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

/// <summary>
/// p18111 - 마인크래프트, S2
/// 해결 날짜 : 2023/8/29
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));

        int[] input = sr.ReadLine().Split().Select(x => int.Parse(x)).ToArray();

        List<List<int>> list = new List<List<int>>();
        int fieldBlock = 0;
        for (int i = 0; i < input[0]; i++)
        {
            list.Add(new List<int>());
            list[i] = sr.ReadLine().Split().Select(x => int.Parse(x)).ToList();
            fieldBlock += list[i].Sum();
        }

        // 높이 0 ~ 256을 현재 상태에서 만드는 것이 가능한지,
        // 그렇다면 시간은 얼마나 걸리는 지를 체크한다.

        int desiredHeight = 0;
        int minTime = 987654321; // 작업의 최대 시간은 128,000,000초이다.

        int area = input[0] * input[1];
        int havingBlock = input[2];

        for (int h = 0; h <= 256; h++)
        {
            int currentTime = 0;
            // 가진 블록 + 필드에 있는 블록이 해당 높이를 만들기 위해 필요한 수보다
            // 작다면 만들 수 없는 것이다.
            if (havingBlock + fieldBlock < area * h) { continue; }

            // 현재 블록을 해당 높이로 만들기 위해 걸리는 시간을 측정한다.
            for(int i  = 0; i < input[0]; i++)
            {
                for (int j = 0; j < input[1]; j++)
                {
                    // 높이가 높음 -> 1칸 낮출 때마다 2초
                    if (h < list[i][j]) currentTime += (list[i][j] - h) * 2;
                    // 높이가 낮음 -> 1칸 높일 때마다 1초
                    else if (h > list[i][j]) currentTime += (h - list[i][j]);
                }
            }

            // 걸리는 시간이 minTime보다 낮거나 같은 경우 이 높이를
            // 가장 시간이 적게 걸리는 높이로 계산한다.
            if (currentTime <= minTime)
            {
                desiredHeight = h;
                minTime = currentTime;
            }
        }

        Console.WriteLine($"{minTime} {desiredHeight}");

        sr.Close();
    }
}
