using System;
using System.Linq;
using System.Collections.Generic;

/// <summary>
/// p9506 - 약수들의 합, B1
/// 해결 날짜 : 2024/3/27
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        while (true)
        {
            int T = int.Parse(Console.ReadLine()!);

            if (T == -1)
                break;

            List<int> list = FindDivisor(T);

            list = list.GetRange(0, list.Count - 1);

            if (list.Sum(x => x) == T)
            {
                Console.WriteLine($"{T} = {string.Join(" + ", list)}");
            }
            else
            {
                Console.WriteLine($"{T} is NOT perfect.");
            }
        }
    }

    public static List<int> FindDivisor(int N)
    {
        List<int> result = new List<int>();

        for (int i = 1; i * i <= N; i++)
        {
            if (N % i == 0)
            {
                result.Add(i);
                if (i * i != N) result.Add(N / i);
            }
        }

        result.Sort();
        return result;
    }
}
