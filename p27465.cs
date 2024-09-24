using System;

/// <summary>
/// p27465 - 소수가 아닌 수, B3
/// 해결 날짜 : 2023/11/13
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        int num = int.Parse(Console.ReadLine()!);
        if (num == 1)
            Console.WriteLine("4");
        else if (num < 500_000_000)
            Console.WriteLine(num * 2);
        else
            Console.WriteLine((isPrime(num)) ? num+1 : num);
    }

    public static bool isPrime(int m)
    {
        if (m == 0 || m == 1) return false;
        else if (m == 2 || m == 3) return true;
        for (int i = 2; i * i <= m; i++)
            if (m % i == 0) 
                return false;
        return true;
    }
}