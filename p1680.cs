using System;
using System.IO;
using System.Collections.Generic;

// p1680 - 쓰레기 수거 (S3)
// #시뮬레이션
// 2025.3.3 solved

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        int t = int.Parse(sr.ReadLine());
        for (int i = 0; i < t; i++)
        {
            int[] info = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
            int w = info[0];
            int n = info[1];
            List<(int, int)> points = new();
            for (int j = 0; j < n; j++)
            {
                int[] point = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
                points.Add((point[0], point[1]));
            }

            int toGo = 0;
            int curWeight = 0;
            int totalDist = 0;
            int curPos = 0;
            while (toGo < n)
            {
                // 쓰레기 가득 참
                if (curWeight == w)
                {
                    curWeight = 0;
                    totalDist += curPos;
                    curPos = 0;
                    
                }
                else
                {
                    // 가야하는 다음 지점으로 이동
                    totalDist += points[toGo].Item1 - curPos;
                    curPos = points[toGo].Item1;
                    // 현재 지점에서의 쓰레기가 많아 용량이 초과되면 쓰레기장에 가서 비우고 돌아온다.
                    if (curWeight + points[toGo].Item2 > w)
                    {
                        curWeight = 0;
                        totalDist += 2 * curPos;
                    }
                    // 쓰레기를 채우고 다음 지점으로 목표 변경
                    else
                    {
                        curWeight += points[toGo].Item2;
                        toGo++;
                    }
                }
            }
            // 마지막 지점에서 쓰레기장으로 복귀
            totalDist += curPos;
            Console.WriteLine(totalDist);
        }
        sr.Close();
    }
}
