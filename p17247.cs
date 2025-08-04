using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

// p17247 - 택시 거리 (B1)
// #기하학
// 2025.8.4 solved

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        int n = input[0], m = input[1];
        
        List<List<int>> map = new();
        for (int i = 0; i < n; i++)
        {
            map.Add(sr.ReadLine().Split().Select(int.Parse).ToList());
        }

        // 두 '1'의 위치를 찾는다.
        int x1 = -1, y1 = -1, x2 = -1, y2 = -1;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (map[i][j] == 1)
                {
                    // 1번 점 좌표가 없으면 x1, y1에 대입, 아니면 x2, y2에 대입
                    if (x1 == -1 && y1 == -1)
                    {
                        x1 = j; y1 = i;
                    }
                    else
                    {
                        x2 = j; y2 = i;
                    }
                }
            }
        }
        Console.WriteLine(Math.Abs(x2 - x1) + Math.Abs(y2 - y1));
        sr.Close();
    }
}
