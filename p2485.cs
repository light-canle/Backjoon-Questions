using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

/// <summary>
/// p2485 - 가로수, S4
/// 해결 날짜 : 2024/3/28
/// </summary>

/*
이미 심어진 가로수들 사이의 간격을 구한 뒤 그 간격들의 최대 공약수가 새로 심어야 할 
가로수들의 간격이 된다. 새로 심을 가로수의 개수는 (끝 가로수 - 시작 가로수 위치) / 간격 + 1이 된다.
*/

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        int count = int.Parse(sr.ReadLine()!);

        List<int> list = new List<int>();
        for (int i = 0; i < count; i++)
        {
            list.Add(int.Parse(sr.ReadLine()!));
        }

        List<int> interval = new List<int>();
        for (int i = 0; i < count - 1; i++)
        {
            interval.Add(list[i + 1] - list[i]);
        }

        long gcd = GCD(interval[0], interval[1]);
        for (int i = 2; i < count - 1; i++)
        {
            gcd = GCD(gcd, interval[i]);
        }

        Console.WriteLine((list.Last() - list[0]) / gcd - count + 1);
    }

    public static long GCD(long a, long b)
    {
        long m = Math.Min(a, b);
        long n = Math.Max(a, b);

        if (m == 0)
        {
            return n;
        }
        return GCD(n % m, m);
    }
}
