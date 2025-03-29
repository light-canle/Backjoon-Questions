using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

// p17829 - 222-풀링 (S3)
// #분할 정복 #재귀
// 2025.3.29 solved

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        int n = int.Parse(sr.ReadLine());

        List<List<short>> list = new();
        for (int i = 0; i < n; i++)
        {
            list.Add(sr.ReadLine().Split().Select(short.Parse).ToList());
        }

        Console.WriteLine(Pulling(n, list));
        sr.Close();
    }

    public static short Pulling(int lv, List<List<short>> list)
    {
        if (lv == 1)
        {
            return list[0][0];
        }

        List<List<short>> pulled = new();
        int half = lv / 2;
        for (int i = 0; i < half; i++)
        {
            pulled.Add(new());
        }
        // 행렬의 2×2부분에 대해 각 부분에서 2번째로 큰 수를 찾는다.
        for (int i = 0; i < lv; i += 2)
        {
            for (int j = 0; j < lv; j += 2)
            {
                short second = Second(list[i][j], list[i][j + 1], list[i + 1][j], list[i + 1][j + 1]);
                pulled[i / 2].Add(second);
            }
        }
        // 절반 크기의 행렬에 대해 재귀 호출
        return Pulling(half, pulled);
    }
    
    public static short Second(short n1, short n2, short n3, short n4)
    {
        List<short> l = new() {n1, n2, n3, n4};
        l.Sort();
        return l[2];
    }
}
