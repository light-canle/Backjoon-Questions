using System;
using System.Linq;

/// <summary>
/// p2581 - 소수, B2
/// 해결 날짜 : 2024/3/27
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        int A = int.Parse(Console.ReadLine()!);
        int B = int.Parse(Console.ReadLine()!);

        List<int> primeList = new List<int>();
        for (int i = A; i <= B; i++)
        {
            if (IsPrime(i))
            {
                primeList.Add(i);
            }
        }

        if (primeList.Count == 0) 
        {
            Console.WriteLine(-1);
            return;
        }

        Console.WriteLine(primeList.Sum(x => x));
        Console.WriteLine(primeList[0]);
    }

    public static bool IsPrime(int n)
    {
        if (n == 1) return false;
        if (n == 2 || n == 3) return true;

        for (int i = 2; i * i <= n; i++)
        {
            if (n % i == 0) return false;
        }

        return true;
    }
}