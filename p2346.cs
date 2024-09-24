using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

/// <summary>
/// p2346 - 풍선 터뜨리기, S3
/// 해결 날짜 : 2024/3/29
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));

        int count = int.Parse(sr.ReadLine()!);
        int[] list = sr.ReadLine()!.Split().Select(int.Parse).ToArray();
        int pointer = 0;
        List<int> order = new List<int>(); // 풍선이 터지는 순서
        order.Add(1);

        for (int i = 0; i < count - 1; i++)
        {
            int diff = list[pointer]; // 이동해야 하는 양
            // list에 있는 값을 0으로 바꾼다는 뜻은 그 자리의 풍선이 터졌다는 뜻이다.
            list[pointer] = 0;

            int cur = 0;

            while (cur != diff)
            {
                if (diff < 0)
                {
                    pointer = (pointer == 0) ? count - 1 : pointer - 1;
                    // 풍선이 터지지 않은 경우에만 이동값을 바꿈
                    if (list[pointer] != 0) cur--;
                }
                else
                {
                    pointer = (pointer == count - 1) ? 0 : pointer + 1;
                    if (list[pointer] != 0) cur++;
                }
            }
            // 해당 위치의 풍선을 터지는 순서에 넣음
            order.Add(pointer + 1);
        }

        Console.WriteLine(string.Join(" ", order));
        sr.Close();
    }
}