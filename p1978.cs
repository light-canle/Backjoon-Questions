using System;
using System.Linq;
using System.Collections.Generic;

/// <summary>
/// p1978 - 소수 찾기, B2
/// 해결 날짜 : 2023/8/24
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        int listSize = int.Parse(Console.ReadLine());
        List<int> list = Console.ReadLine().Split().Select(x => int.Parse(x)).ToList();

        int primeCount = 0;
        for (int i = 0; i < listSize; i++)
        {
            if (IsPrime(list[i])) primeCount++;
        }
        Console.WriteLine(primeCount);
    }

    public static bool IsPrime(int num)
    {
        if (num == 1) return false;
        if (num == 2 || num == 3) return true;
        if (num % 6 != 1 && num % 6 != 5) return false;

        for (int i = 2; i * i <= num; i++)
        {
            if (num % i == 0) return false;
        }
        return true;
    }
}
