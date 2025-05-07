using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

// p21918 - 전구 (B2)
// #시뮬레이션
// 2025.5.7 solved

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        int n = input[0], m = input[1];

        // 전구의 상태 : 0은 꺼짐, 1은 켜짐
        List<int> light = sr.ReadLine().Split().Select(int.Parse).ToList();
        for (int i = 0; i < m; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int op = line[0], l = line[1], r = line[2];
            switch (op)
            {
                case 1: // l번 전구를 r 상태로 바꿈
                    light[l - 1] = r;
                    break;
                case 2: // l번 ~ r번 전구의 상태를 뒤바꿈
                    for (int num = l - 1; num < r; num++)
                    {
                        light[num] = light[num] == 0 ? 1 : 0;
                    }
                    break;
                case 3: // l번 ~ r번 전구를 끔
                    for (int num = l - 1; num < r; num++)
                    {
                        light[num] = 0;
                    }
                    break;
                case 4: // l번 ~ r번 전구를 켬
                    for (int num = l - 1; num < r; num++)
                    {
                        light[num] = 1;
                    }
                    break;
            }
        }
        Console.WriteLine(string.Join(" ", light));
        sr.Close();
    }
}
