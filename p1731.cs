using System;
using System.Linq;
using System.Collections.Generic;

/// <summary>
/// p1731 - 추론, B2
/// 해결 날짜 : 2023/9/12
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());

        List<int> list = new List<int>();
        for (int i = 0; i < N; i++)
        {
            list.Add(int.Parse(Console.ReadLine()));
        }
        // 처음 세항의 차이를 구함
        int diffa = list[2] - list[1];
        int diffb = list[1] - list[0];
        // 차이가 동일 : 등차수열(물론 등비가 1인 수열일 수도 있으나 등차수열로 볼 수도 있다.)
        if (diffa == diffb) 
        {
            int comDiff = diffa;
            Console.WriteLine(comDiff + list[^1]);
        }
        // 차이가 다름 : 등비수열
        else
        {
            int comRatio = list[1] / list[0];
            Console.WriteLine(comRatio * list[^1]);
        }
    }
}